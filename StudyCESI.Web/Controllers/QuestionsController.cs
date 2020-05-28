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
    [Authorize]
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
            var studyCesiContext = _context.Questions.Include(q => q.Subject).Include(q => q.TypeQuestion);
            return View(await studyCesiContext.ToListAsync());
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
                //return RedirectToAction(nameof(Index));

                // TODO :: Return the right view to fill the answer => TypeQuestion
                question.TypeQuestion = _context.TypeQuestions.Where(t => t.TypeQuestionId == question.TypeQuestionId).FirstOrDefault();
                question.Subject = _context.Subjects.Where(s => s.SubjectId == question.SubjectId).FirstOrDefault();

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
                } else if (question.TypeQuestion.Name == "Trou")
                {
                    model.IsHoleAnswer = true;
                }

                return View("CreateAnswer", model);
            }
            ViewData["SubjectId"] = new SelectList(_context.Subjects, "SubjectId", "SubjectId", question.SubjectId);
            ViewData["TypeQuestionId"] = new SelectList(_context.TypeQuestions, "TypeQuestionId", "TypeQuestionId", question.TypeQuestionId);
            return View(question);
        }

        // POST: Questions/CreateAnswer
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        /*[HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateChoiceAnswer([Bind("QuestionId,Header,Mark,CreationDate,TypeQuestionId,SubjectId,UserId")] ChoiceAnswer answer)
        {
            question.UserId = _userManager.GetUserId(User);
            if (ModelState.IsValid)
            {
                _context.Add(question);
                await _context.SaveChangesAsync();
                //return RedirectToAction(nameof(Index));

                // TODO :: Return the right view to fill the answer => TypeQuestion
                var model = new CreateAnswerViewModel
                {
                    Question = question
                };

                return View("CreateAnswer", model);
            }
            ViewData["SubjectId"] = new SelectList(_context.Subjects, "SubjectId", "SubjectId", question.SubjectId);
            ViewData["TypeQuestionId"] = new SelectList(_context.TypeQuestions, "TypeQuestionId", "TypeQuestionId", question.TypeQuestionId);
            return View(question);
        }
        */
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
