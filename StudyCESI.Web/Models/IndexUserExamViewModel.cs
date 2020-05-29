using StudyCESI.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudyCESI.Web.Models
{
    public class IndexUserExamViewModel
    {
        public IEnumerable<Exam> Exams { get; set; }

        public IEnumerable<UserExam> UserExams { get; set; }
    }
}
