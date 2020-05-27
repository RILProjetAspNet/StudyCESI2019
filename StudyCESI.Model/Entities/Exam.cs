using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace StudyCESI.Model.Entities
{
    public class Exam
    {
        public int ExamId { get; set; }

        public string Name { get; set; }

        public int NumberQuestions { get; set; }

        public DateTime Duration { get; set; }

        public int  NumberTriesAllow { get; set; }

        public DateTime EndDate { get; set; }

        public DateTime CreationDate { get; set; }

        [Column("AspNetUsers_Id")]
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
