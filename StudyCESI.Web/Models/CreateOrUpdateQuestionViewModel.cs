using StudyCESI.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudyCESI.Web.Models
{
    public class CreateOrUpdateQuestionViewModel
    {
        public Question Question { get; set; }

        public List<Subject> Subjects { get; set; }

        public List<TypeQuestion> TypeQuestions { get; set; }

        public List<BoolAnswer> BoolAnswers { get; set; }

        public List<ChoiceAnswer> ChoiceAnswers { get; set; }
    }
}
