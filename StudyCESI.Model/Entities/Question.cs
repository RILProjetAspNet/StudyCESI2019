using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace StudyCESI.Model.Entities
{
    public class Question
    {
        public int QuestionId { get; set; }

        public string Header { get; set; }

        public int Mark { get; set; }

        public DateTime CreationDate { get; set; }

        [Column("TypeQuestion_TypeQuestionId")]
        public int? TypeQuestionId { get; set; }
        public TypeQuestion TypeQuestion { get; set; }

        [Column("Subject_SubjectId")]
        public int SubjectId { get; set; }
        public Subject Subject { get; set; }

        [Column("AspNetUsers_Id")]
        public string UserId { get; set; }
        public User User { get; set; }
    }
}
