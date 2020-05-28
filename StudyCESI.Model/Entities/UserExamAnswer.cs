using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace StudyCESI.Model.Entities
{
    public class UserExamAnswer
    {
        public int UserExamAnswerId { get; set; }

        public string Answer { get; set; }

        public DateTime CreationDate { get; set; }

        [Column("UserExam_UserExamId")]
        public int? UserExamId { get; set; }
        public UserExam UserExam { get; set; }

        [Column("Question_QuestionId")]
        public int QuestionId { get; set; }
        public Question Question { get; set; }


    }
}
