using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace StudyCESI.Model.Entities
{
    public class ExamQuestion
    {
        public int ExamQuestionId { get; set; }


        [Column("Exam_ExamId")]
        public int? ExamId { get; set; }
        public Exam Exam { get; set; }

        [Column("Question_QuestionId")]
        public int QuestionId { get; set; }
        public Question Question { get; set; }

        [DisplayName("Date de création")]
        public DateTime CreationDate { get; set; }
    }
}
