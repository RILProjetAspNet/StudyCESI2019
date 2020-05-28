using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using StudyCESI.Model.Data;
using StudyCESI.Model.Entities;

namespace StudyCESI.Web.Controllers
{
    public class TypeQuestionsController : Controller
    {
        private readonly StudyCesiContext _context;

        public TypeQuestionsController(StudyCesiContext context)
        {
            _context = context;
        }

        // GET: TypeQuestions
        public async Task<IActionResult> Index()
        {
            return View(await _context.TypeQuestions.ToListAsync());
        }

        // GET: TypeQuestions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var typeQuestion = await _context.TypeQuestions
                .FirstOrDefaultAsync(m => m.TypeQuestionId == id);
            if (typeQuestion == null)
            {
                return NotFound();
            }

            return View(typeQuestion);
        }

        // GET: TypeQuestions/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TypeQuestions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TypeQuestionId,Name,Wording,CreationDate")] TypeQuestion typeQuestion)
        {
            if (ModelState.IsValid)
            {
                _context.Add(typeQuestion);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(typeQuestion);
        }

        // GET: TypeQuestions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var typeQuestion = await _context.TypeQuestions.FindAsync(id);
            if (typeQuestion == null)
            {
                return NotFound();
            }
            return View(typeQuestion);
        }

        // POST: TypeQuestions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TypeQuestionId,Name,Wording,CreationDate")] TypeQuestion typeQuestion)
        {
            if (id != typeQuestion.TypeQuestionId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(typeQuestion);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TypeQuestionExists(typeQuestion.TypeQuestionId))
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
            return View(typeQuestion);
        }

        // GET: TypeQuestions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var typeQuestion = await _context.TypeQuestions
                .FirstOrDefaultAsync(m => m.TypeQuestionId == id);
            if (typeQuestion == null)
            {
                return NotFound();
            }

            return View(typeQuestion);
        }

        // POST: TypeQuestions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var typeQuestion = await _context.TypeQuestions.FindAsync(id);
            _context.TypeQuestions.Remove(typeQuestion);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TypeQuestionExists(int id)
        {
            return _context.TypeQuestions.Any(e => e.TypeQuestionId == id);
        }
    }
}
