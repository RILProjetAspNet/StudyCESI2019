using StudyCESI.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudyCESI.Web.Models
{
    public class CreateOrUpdateExamViewModel 
    {
        public Exam Exam { get; set; }

        public List<Question> Questions { get; set; }

        public List<Subject> Subjects { get; set; }

    }
}
