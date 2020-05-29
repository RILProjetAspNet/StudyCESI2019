using StudyCESI.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudyCESI.Web.Models
{
    public class PassExamViewModel
    {
        public UserExam UserExam { get; set; }
        public Exam Exam { get; set; }
        public IEnumerable<Question> Questions { get; set; }
        public List<ChoiceAnswer> ChoiceAnswers { get; set; }
    }
}
