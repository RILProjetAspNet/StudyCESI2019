using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using StudyCESI.Model.Data;
using StudyCESI.Model.Entities;
using Microsoft.AspNetCore.Identity;
using StudyCESI.Web.Models;
using Microsoft.AspNetCore.Authorization;

namespace StudyCESI.Web.Controllers
{
    [Authorize(Policy = "EstEnseignant")]
    public class QuestionsController : Controller
    {
        private readonly StudyCesiContext _context;
        private readonly UserManager<User> _userManager;

        public QuestionsController(StudyCesiContext context, UserManager<User> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: Questions
        public async Task<IActionResult> Index()
        {
            var questions = _context.Questions.Include(q => q.Subject).Include(q => q.TypeQuestion);
            return View(await questions.ToListAsync());
        }

        // GET: Questions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var question = await _context.Questions
                .Include(q => q.Subject)
                .Include(q => q.TypeQuestion)
                .FirstOrDefaultAsync(m => m.QuestionId == id);
            if (question == null)
            {
                return NotFound();
            }

            return View(question);
        }


        // GET: Questions/Create
        public IActionResult Create()
        {
            return View(new CreateOrUpdateQuestionViewModel
            {
                Subjects = _context.Subjects.ToList(),
                TypeQuestions = _context.TypeQuestions.ToList()
            });
        }

        // POST: Questions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("QuestionId,Header,Mark,CreationDate,TypeQuestionId,SubjectId,UserId")] Question question)
        {
            question.UserId = _userManager.GetUserId(User);
            if (ModelState.IsValid)
            {
                _context.Add(question);
                await _context.SaveChangesAsync();

                // Return the right view to fill the answer => TypeQuestion
                question.TypeQuestion = await _context.TypeQuestions.Where(t => t.TypeQuestionId == question.TypeQuestionId).FirstOrDefaultAsync();
                question.Subject = await _context.Subjects.Where(s => s.SubjectId == question.SubjectId).FirstOrDefaultAsync();

                var model = new CreateAnswerViewModel
                {
                    Question = question
                };

                if (question.TypeQuestion.Name == "Multiple" || question.TypeQuestion.Name == "Unique")
                {
                    model.IsChoiceAnswer = true;
                } else if (question.TypeQuestion.Name == "VraiFaux")
                {
                    model.IsBoolAnswer = true;
                    model.ListBoolAnswer = _context.BoolAnswers.Where(a => a.QuestionId == question.QuestionId).ToList();
                } else if (question.TypeQuestion.Name == "Trou")
                {
                    model.IsHoleAnswer = true;
                    model.ListHoleAnswer = _context.HoleAnswers.Where(a => a.QuestionId == question.QuestionId).ToList();
                }

                ViewData["ChoiceAnswersIsRight"] = false;

                return View("CreateAnswer", model);
            }
            ViewData["SubjectId"] = new SelectList(_context.Subjects, "SubjectId", "SubjectId", question.SubjectId);
            ViewData["TypeQuestionId"] = new SelectList(_context.TypeQuestions, "TypeQuestionId", "TypeQuestionId", question.TypeQuestionId);
            return View(question);
        }

        // POST: Questions/CreateChoiceAnswer
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateChoiceAnswer([Bind("ChoiceAnswerId,Answer,IsRight,QuestionId,CreationDate")] ChoiceAnswer choiceAnswer)
        {
            choiceAnswer.Question = await _context.Questions.Where(q => q.QuestionId == choiceAnswer.QuestionId).FirstOrDefaultAsync();
           if (ModelState.IsValid)
            {
                _context.Add(choiceAnswer);
                await _context.SaveChangesAsync();
            }

            var model = new CreateAnswerViewModel
            {
                IsChoiceAnswer = true,
                Question = choiceAnswer.Question,
                ListChoiceAnswer = _context.ChoiceAnswers.Where(a => a.QuestionId == choiceAnswer.QuestionId).ToList()
            };

            // For single choice, check if one answer is already True
            // TODO :: Replace Name by a key value in app config
            var query = from answer in _context.ChoiceAnswers
                        join question in _context.Questions
                            on answer.QuestionId equals question.QuestionId
                        join type in _context.TypeQuestions
                            on question.TypeQuestionId equals type.TypeQuestionId
                        where type.Name == "Unique" && question.QuestionId == choiceAnswer.QuestionId && answer.IsRight
                        select answer ;

            ViewData["ChoiceAnswersIsRight"] = query.Count() > 0 ? true : false;
            
            // Return to the add answer
            return View("CreateAnswer", model);
        }

        // POST: Questions/CreateBoolAnswer
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateBoolAnswer([Bind("BoolAnswerId,Answer,QuestionId,CreationDate")] BoolAnswer boolAnswer)
        {
            if (ModelState.IsValid)
            {
                _context.Add(boolAnswer);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Details), "Questions", new { id = boolAnswer.QuestionId });
            }

            // Can't add answer we return to the CreateAnswer page
            var model = new CreateAnswerViewModel
            {
                Question = boolAnswer.Question
            };

            return View("CreateAnswer", model);
        }

        // POST: Questions/CreateHoleAnswer
        [HttpPost]
        [ValidateAntiForgeryToken]
        //[Bind("HoleAnswerId,Answer,HoleLimitStart,HoleLimitEnd,QuestionId,CreationDate")] HoleAnswer holeAnswer, string questionHeader
        public async Task<IActionResult> CreateHoleAnswer(Question question)
        {
            HoleAnswer holeAnswer = new HoleAnswer();
            holeAnswer.Question = await _context.Questions.Where(q => q.QuestionId == question.QuestionId).FirstOrDefaultAsync();
     
            holeAnswer.Question.Header = question.Header;

            _context.Update(holeAnswer.Question);
            await _context.SaveChangesAsync();

            for (int i = 0; i < holeAnswer.Question.Header.Length; i++)
            {
                char let = holeAnswer.Question.Header[i];

                if (let == '[')
                {
                    holeAnswer.Answer = "";
                    holeAnswer.HoleLimitStart = i;

                    i++;
                    for (int j = 0; i < holeAnswer.Question.Header.Length; i++)
                    {
                        char letValue = holeAnswer.Question.Header[i];

                        if (letValue == ']')
                        {
                            holeAnswer.HoleLimitEnd = i;

                            _context.Add(new HoleAnswer
                            {
                                HoleAnswerId = 0,
                                QuestionId = question.QuestionId,
                                Answer = holeAnswer.Answer,
                                HoleLimitStart = holeAnswer.HoleLimitStart,
                                HoleLimitEnd = holeAnswer.HoleLimitEnd
                            });
                            await _context.SaveChangesAsync();
                            break;
                        }

                        holeAnswer.Answer += letValue;
                    }
                }
            }

            return RedirectToAction(nameof(Details), "Questions", new { id = question.QuestionId });
        }

        // GET: Questions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var question = await _context.Questions.FindAsync(id);
            if (question == null)
            {
                return NotFound();
            }

            return View(new CreateOrUpdateQuestionViewModel
            {
                Subjects = _context.Subjects.ToList(),
                TypeQuestions = _context.TypeQuestions.ToList()
            });
            /*
            ViewData["SubjectId"] = new SelectList(_context.Subjects, "SubjectId", "SubjectId", question.SubjectId);
            ViewData["TypeQuestionId"] = new SelectList(_context.TypeQuestions, "TypeQuestionId", "TypeQuestionId", question.TypeQuestionId);
            return View(question);*/
        }

        // POST: Questions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("QuestionId,Header,Mark,CreationDate,TypeQuestionId,SubjectId,UserId")] Question question)
        {
            if (id != question.QuestionId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(question);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!QuestionExists(question.QuestionId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["SubjectId"] = new SelectList(_context.Subjects, "SubjectId", "SubjectId", question.SubjectId);
            ViewData["TypeQuestionId"] = new SelectList(_context.TypeQuestions, "TypeQuestionId", "TypeQuestionId", question.TypeQuestionId);
            return View(question);
        }

        // GET: Questions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var question = await _context.Questions
                .Include(q => q.Subject)
                .Include(q => q.TypeQuestion)
                .FirstOrDefaultAsync(m => m.QuestionId == id);
            if (question == null)
            {
                return NotFound();
            }

            return View(question);
        }

        // POST: Questions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var question = await _context.Questions.FindAsync(id);
            _context.Questions.Remove(question);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool QuestionExists(int id)
        {
            return _context.Questions.Any(e => e.QuestionId == id);
        }
    }
}
