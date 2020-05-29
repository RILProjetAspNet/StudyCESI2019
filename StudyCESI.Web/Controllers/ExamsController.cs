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
using Microsoft.AspNetCore.Rewrite.Internal.UrlMatches;

namespace StudyCESI.Web.Controllers
{
    [Authorize]
    public class ExamsController : Controller
    {
        private readonly StudyCesiContext _context;
        private readonly UserManager<User> _userManager;

        public ExamsController(StudyCesiContext context, UserManager<User> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: Exams
        public async Task<IActionResult> Index()
        {
            if (User.FindFirst("Role").Value == "Enseignant")
            {
                var exams = await _context.Exams.ToListAsync();
                return View("IndexEnseignant", exams);

            }
            else if (User.FindFirst("Role").Value == "Etudiant")
            {
                // Get exams who User can pass
                var exams = from exam in _context.Exams
                            join userExam in _context.UserExams
                                on exam.ExamId equals userExam.ExamId
                            where exam.EndDate > DateTime.Now
                                && userExam.NumberTries < exam.NumberTriesAllow
                                && userExam.UserId == _userManager.GetUserId(User)
                            select exam;

                return View("IndexEtudiant", exams);
            }
            else
            {
                return NotFound();
            }

        }

        // GET: Exams/Details/5
        [Authorize(Policy = "EstEnseignant")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var exam = await _context.Exams
                .FirstOrDefaultAsync(m => m.ExamId == id);
            if (exam == null)
            {
                return NotFound();
            }

            return View(new CreateOrUpdateExamViewModel
            {
                Questions = _context.ExamQuestions.Where(eq => eq.ExamId == exam.ExamId).Select(eq => eq.Question).Include(e => e.TypeQuestion).ToList(),
                Subjects = _context.Subjects.ToList(),
                Exam = exam
            });
        }

        // GET: Exams/Create
        [Authorize(Policy = "EstEnseignant")]
        public IActionResult Create()
        {
            return View(new CreateOrUpdateExamViewModel
            {
                Subjects = _context.Subjects.ToList(),
                Questions = _context.Questions.ToList()
            });
        }

        // POST: Exams/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Policy = "EstEnseignant")]
        public async Task<IActionResult> Create([Bind("ExamId,Name,SubjectId,NumberQuestions,Duration,NumberTriesAllow,EndDate,CreationDate,UserId")] Exam exam)
        {
            exam.UserId = _userManager.GetUserId(User);

            if (ModelState.IsValid)
            {
                _context.Add(exam);

                SelectRandomQuestion(exam);

                //Create userExams for each user
                var users = _context.Users.ToListAsync();

                for (int i = 0; i < users.Result.Count(); i++)
                {
                    _context.Add(new UserExam
                    {
                        UserId = users.Result[i].Id,
                        ExamId = exam.ExamId,
                        NumberTries = 0,
                        BestNote = 0,
                        IsValid = false
                    });
                    await _context.SaveChangesAsync();
                }

                return View(nameof(Details), new CreateOrUpdateExamViewModel
                {
                    Questions = _context.Questions.Include(e => e.TypeQuestion).ToList(),
                    Subjects = _context.Subjects.ToList(),
                    Exam = exam
                });
            }

            return View(new CreateOrUpdateExamViewModel
            {
                Questions = _context.Questions.Include(e => e.TypeQuestion).ToList(),
                Subjects = _context.Subjects.ToList(),
                Exam = exam
            });
        }

        // GET: Exams/Pass
        [Authorize(Policy = "EstEtudiant")]
        public async Task<IActionResult> Pass(int? id)
        {
            var model = new PassExamViewModel
            {
                UserExam = await _context.UserExams.Where(e => e.ExamId == id && e.UserId == _userManager.GetUserId(User)).FirstOrDefaultAsync(),
                Exam = await _context.Exams.Where(e => e.ExamId == id).FirstOrDefaultAsync(),
                Questions = await _context.ExamQuestions.Include(q => q.Question).Where(e => e.ExamId == id).Select(e => e.Question).ToListAsync(),
                ChoiceAnswers = new List<ChoiceAnswer>()
            };

            for (int i = 0; i < model.Questions.Count(); i++)
            {
                // Get question type
                int? typeQuestionId = model.Questions.ElementAt(i).TypeQuestionId;
                model.Questions.ElementAt(i).TypeQuestion = await _context.TypeQuestions.Where(t => t.TypeQuestionId == typeQuestionId).FirstOrDefaultAsync();
                string type = model.Questions.ElementAt(i).TypeQuestion.Name;

                if (type == "Unique" || type == "Multiple")
                {
                    model.ChoiceAnswers.AddRange(await _context.ChoiceAnswers.Where(a => a.QuestionId == model.Questions.ElementAt(i).QuestionId).ToListAsync());
                }

            }

            return View(model);
        }

        // POST: Exams/Pass
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Policy = "EstEtudiant")]
        public async Task<IActionResult> Pass([Bind("UserExamAnswerId,Answer,UserExamId,QuestionId,CreationDate")] List<UserExamAnswer> UserExamAnswer)
        {

            UserExamAnswer.ElementAt(0).UserExamId = await _context.UserExams.Where(u => u.ExamId == 1).Select(u => u.UserExamId).FirstOrDefaultAsync();

            if (ModelState.IsValid)
            {
                // TODO  
                return View(nameof(ResultPass), 1);

            }

            return View();
        }

        // GET: Exams/ResultPass
        [Authorize(Policy = "EstEtudiant")]
        public async Task<IActionResult> ResultPass(int? id)
        {


            return View();
        }

        private async void SelectRandomQuestion(Exam exam)
        {
            //Get list of Questions of this exam subject
            var questions = _context.Questions.Where(q => q.SubjectId == exam.SubjectId).ToList();
            int max = exam.NumberQuestions > questions.Count ? questions.Count : exam.NumberQuestions;

            for (int i = 0; i < max; i++)
            {
                var q = questions.FirstOrDefault();
                var examQuestion = new ExamQuestion { Exam = exam, Question = q };
                _context.Add(examQuestion);
                questions.RemoveAt(0);
            }
        }

        // GET: Exams/Edit/
        [Authorize(Policy = "EstEnseignant")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var exam = await _context.Exams.FindAsync(id);
            if (exam == null)
            {
                return NotFound();
            }

            return View(new CreateOrUpdateExamViewModel
            {
                Questions = _context.ExamQuestions.Where(eq => eq.ExamId == exam.ExamId).Select(eq => eq.Question).Include(e => e.TypeQuestion).ToList(),
                Subjects = _context.Subjects.ToList(),
                Exam = exam
            });
        }

        // POST: Exams/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Policy = "EstEnseignant")]
        public async Task<IActionResult> Edit(int id, [Bind("ExamId,Name,NumberQuestions,Duration,NumberTriesAllow,EndDate,CreationDate,UserId")] Exam exam)
        {
            if (id != exam.ExamId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(exam);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ExamExists(exam.ExamId))
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

            return View(new CreateOrUpdateExamViewModel
            {
                Questions = _context.ExamQuestions.Where(eq => eq.ExamId == exam.ExamId).Select(eq => eq.Question).ToList(),
                Subjects = _context.Subjects.ToList(),
                Exam = exam
            });
        }

        // GET: Exams/Delete/5
        [Authorize(Policy = "EstEnseignant")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var exam = await _context.Exams
                .FirstOrDefaultAsync(m => m.ExamId == id);
            if (exam == null)
            {
                return NotFound();
            }

            return View(exam);
        }

        // POST: Exams/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var exam = await _context.Exams.FindAsync(id);
            _context.Exams.Remove(exam);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ExamExists(int id)
        {
            return _context.Exams.Any(e => e.ExamId == id);
        }
    }
}
