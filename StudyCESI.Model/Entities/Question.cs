using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace StudyCESI.Model.Entities
{
    public class Question
    {
        public int QuestionId { get; set; }

        [Column(TypeName = "varchar(255)")]
        [MaxLength(255)]
        public string Header { get; set; }

        [Range(1, 100)]
        public int Mark { get; set; }

        public DateTime CreationDate { get; set; }

        [Column("TypeQuestion_TypeQuestionId")]
        public int? TypeQuestionId { get; set; }
        public TypeQuestion TypeQuestion { get; set; }

        [Column("Subject_SubjectId")]
        public int SubjectId { get; set; }
        public Subject Subject { get; set; }

        [Column("AspNetUsers_Id")]
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
