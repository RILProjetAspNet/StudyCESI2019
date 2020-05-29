using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using StudyCESI.Model.Data;
using StudyCESI.Model.Entities;
using StudyCESI.Web.Models;

namespace StudyCESI.Web.Controllers
{
    [Authorize(Policy = "EstEnseignant")]
    public class AnswersController : Controller
    {
        private readonly StudyCesiContext _context;

        public AnswersController(StudyCesiContext context)
        {
            _context = context;
        }

        // GET: BoolAnswers
        public async Task<IActionResult> Index()
        {
            var studyCesiContext = _context.BoolAnswers.Include(b => b.Question);
            return View(await studyCesiContext.ToListAsync());
        }

        // GET: BoolAnswers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var boolAnswer = await _context.BoolAnswers
                .Include(b => b.Question)
                .FirstOrDefaultAsync(m => m.BoolAnswerId == id);
            if (boolAnswer == null)
            {
                return NotFound();
            }

            return View(boolAnswer);
        }

        // GET: Answers/Create
        public IActionResult Create(CreateAnswerViewModel model)
        {
            return View(model);
        }


        // POST: Answers/CreateBool
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateBool([Bind("BoolAnswerId,Answer,QuestionId,CreationDate")] BoolAnswer boolAnswer)
        {
            if (ModelState.IsValid)
            {
                _context.Add(boolAnswer);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Details), "Questions", new { id = boolAnswer.QuestionId } );
            }

            return View(boolAnswer);
        }

        // POST: Answers/CreateChoice
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateChoice([Bind("ChoiceAnswerId,Answer,IsRight,QuestionId,CreationDate")] ChoiceAnswer choiceAnswer)
        {
            if (ModelState.IsValid)
            {
                _context.Add(choiceAnswer);
                await _context.SaveChangesAsync();
                // return RedirectToAction(nameof(Crea), "Questions", new { id = choiceAnswer.QuestionId });
            }

            // Return to the add answer
            return RedirectToAction("CreateAnswer", "Answers", choiceAnswer);
        }

        // POST: Answers/CreateHole
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateHole([Bind("HoleAnswerId,Answer,HoleLimitStart,HoleLimitEnd,QuestionId,CreationDate")] HoleAnswer holeAnswer)
        {
            if (ModelState.IsValid)
            {
                _context.Add(holeAnswer);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Details), "Questions", new { id = holeAnswer.QuestionId });
            }

            return View(holeAnswer);
        }

        // GET: BoolAnswers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var boolAnswer = await _context.BoolAnswers.FindAsync(id);
            if (boolAnswer == null)
            {
                return NotFound();
            }
            ViewData["QuestionId"] = new SelectList(_context.Questions, "QuestionId", "QuestionId", boolAnswer.QuestionId);
            return View(boolAnswer);
        }

        // POST: BoolAnswers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("BoolAnswerId,Answer,QuestionId,CreationDate")] BoolAnswer boolAnswer)
        {
            if (id != boolAnswer.BoolAnswerId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(boolAnswer);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BoolAnswerExists(boolAnswer.BoolAnswerId))
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
            ViewData["QuestionId"] = new SelectList(_context.Questions, "QuestionId", "QuestionId", boolAnswer.QuestionId);
            return View(boolAnswer);
        }

        // GET: BoolAnswers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var boolAnswer = await _context.BoolAnswers
                .Include(b => b.Question)
                .FirstOrDefaultAsync(m => m.BoolAnswerId == id);
            if (boolAnswer == null)
            {
                return NotFound();
            }

            return View(boolAnswer);
        }

        // POST: BoolAnswers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var boolAnswer = await _context.BoolAnswers.FindAsync(id);
            _context.BoolAnswers.Remove(boolAnswer);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BoolAnswerExists(int id)
        {
            return _context.BoolAnswers.Any(e => e.BoolAnswerId == id);
        }
    }
}
