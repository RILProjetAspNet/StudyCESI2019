﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using StudyCESI.Model.Entities;
using StudyCESI.Web.Data;

namespace StudyCESI.Web.Controllers
{
    public class QuestionsController : Controller
    {
        private readonly StudyCESIWebContext _context;

        public QuestionsController(StudyCESIWebContext context)
        {
            _context = context;
        }

        // GET: Questions
        public async Task<IActionResult> Index()
        {
            var studyCESIWebContext = _context.Question.Include(q => q.Subject).Include(q => q.TypeQuestion);
            return View(await studyCESIWebContext.ToListAsync());
        }

        // GET: Questions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var question = await _context.Question
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
            ViewData["SubjectId"] = new SelectList(_context.Set<Subject>(), "SubjectId", "SubjectId");
            ViewData["TypeQuestionId"] = new SelectList(_context.Set<TypeQuestion>(), "TypeQuestionId", "TypeQuestionId");
            return View();
        }

        // POST: Questions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("QuestionId,Header,Mark,CreationDate,TypeQuestionId,SubjectId,UserId")] Question question)
        {
            if (ModelState.IsValid)
            {
                _context.Add(question);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["SubjectId"] = new SelectList(_context.Set<Subject>(), "SubjectId", "SubjectId", question.SubjectId);
            ViewData["TypeQuestionId"] = new SelectList(_context.Set<TypeQuestion>(), "TypeQuestionId", "TypeQuestionId", question.TypeQuestionId);
            return View(question);
        }

        // GET: Questions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var question = await _context.Question.FindAsync(id);
            if (question == null)
            {
                return NotFound();
            }
            ViewData["SubjectId"] = new SelectList(_context.Set<Subject>(), "SubjectId", "SubjectId", question.SubjectId);
            ViewData["TypeQuestionId"] = new SelectList(_context.Set<TypeQuestion>(), "TypeQuestionId", "TypeQuestionId", question.TypeQuestionId);
            return View(question);
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
            ViewData["SubjectId"] = new SelectList(_context.Set<Subject>(), "SubjectId", "SubjectId", question.SubjectId);
            ViewData["TypeQuestionId"] = new SelectList(_context.Set<TypeQuestion>(), "TypeQuestionId", "TypeQuestionId", question.TypeQuestionId);
            return View(question);
        }

        // GET: Questions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var question = await _context.Question
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
            var question = await _context.Question.FindAsync(id);
            _context.Question.Remove(question);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool QuestionExists(int id)
        {
            return _context.Question.Any(e => e.QuestionId == id);
        }
    }
}
