using StudyCESI.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudyCESI.Web.Models
{
    public class IndexViewModel
    {
        public List<Exam> Exams { get; set; }

        public List<Question>  Questions { get; set; }
    }
}
