using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace StudyCESI.Model.Entities
{
    public class UserExam
    {
        public int UserExamId { get; set; }

        [DisplayName("Nombre d'essai")]
        public int NumberTries { get; set; }

        [DisplayName("Meilleure note")]
        public int BestNote { get; set; }

        [DisplayName("Est valide")]
        public bool IsValid { get; set; }

        public DateTime CreationDate { get; set; }

        [Column("AspNetUsers_Id")]
        public int? UserId { get; set; }
        public User User { get; set; }

        [Column("Exam_ExamId")]
        public int ExamId { get; set; }
        public Exam Exam { get; set; }
    }
}
