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
            return View(await _context.Exams.ToListAsync());
        }

        // GET: Exams/Details/5
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

            return View(exam);
        }

        // GET: Exams/Create
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
        public async Task<IActionResult> Create([Bind("ExamId,Name,SubjectId,NumberQuestions,Duration,NumberTriesAllow,EndDate,CreationDate,UserId")] Exam exam)
        {
            exam.UserId = _userManager.GetUserId(User);
            var ok = _context.Questions.ToList();
            if (ModelState.IsValid)
            {
                _context.Add(exam);

                SelectRandomQuestion(exam);

                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(new CreateOrUpdateExamViewModel
            {
                Questions = _context.Questions.ToList(),
                Subjects = _context.Subjects.ToList(),
                Exam = exam
            }); ;
        }

        private void SelectRandomQuestion(Exam exam)
        {
            int i = 0;
            foreach (var q in _context.Questions.Where(q=>q.SubjectId == exam.SubjectId).ToList())
            {
                if(i == exam.NumberQuestions)
                {
                    break;
                }
                var examQuestion = new ExamQuestion { Exam = exam, Question = q };
                _context.Add(examQuestion);
                i++;
            }
        }

        // GET: Exams/Edit/5
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
                Questions = _context.ExamQuestions.Where(eq => eq.ExamId == exam.ExamId).Select(eq => eq.Question).ToList(),
                Subjects = _context.Subjects.ToList(),
                Exam = exam
            });
        }

        // POST: Exams/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
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
                Questions = _context.ExamQuestions.Where(eq => eq.ExamId == exam.ExamId).Select(eq =>eq.Question).ToList(),
                Subjects = _context.Subjects.ToList(),
                Exam = exam
            });
        }

        // GET: Exams/Delete/5
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
