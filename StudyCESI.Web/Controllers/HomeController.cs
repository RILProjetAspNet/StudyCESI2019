using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StudyCESI.Web.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using StudyCESI.Model.Data;
using StudyCESI.Model.Entities;
using Microsoft.AspNetCore.Identity;


namespace StudyCESI.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly StudyCesiContext _context;
        private readonly UserManager<User> _userManager;

        public HomeController(StudyCesiContext context, UserManager<User> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            if (User.Identity.IsAuthenticated && User.FindFirst("Role").Value == "Enseignant")
            {
                var exams = from exam in _context.Exams
                            where exam.UserId == _userManager.GetUserId(User)
                            select exam;

                var questions = from question in _context.Questions.Include(e => e.TypeQuestion).Include(s => s.Subject)
                                where question.UserId == _userManager.GetUserId(User)
                                select question;

                return View(new IndexViewModel
                {
                    Exams = exams.ToList(),
                    Questions = questions.ToList()
                });

            }
            else if (User.Identity.IsAuthenticated && User.FindFirst("Role").Value == "Etudiant")
            {
                // Get exams who User can pass
                var exams = from exam in _context.Exams
                            join userExam in _context.UserExams
                                on exam.ExamId equals userExam.ExamId
                            where userExam.NumberTries > 0
                                && userExam.UserId == _userManager.GetUserId(User)
                            select exam;

                return View(new IndexViewModel
                {
                    Exams = exams.ToList()
                });
            }
            else
            {
                return View();
            }
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
