using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace StudyCESI.Model.Entities
{
    public class Question
    {
        public int QuestionId { get; set; }

        [DisplayName("Question")]
        public string Header { get; set; }

        [DisplayName("Valeur en point")]
        [Range(1, 20)]
        public int Mark { get; set; }

        [Column("TypeQuestion_TypeQuestionId")]
        [DisplayName("Type de question")]
        public int? TypeQuestionId { get; set; }
        [DisplayName("Type de question")]
        public TypeQuestion TypeQuestion { get; set; }

        [Column("Subject_SubjectId")]
        [DisplayName("Sujet")]
        public int SubjectId { get; set; }
        [DisplayName("Sujet")]
        public Subject Subject { get; set; }

        [Column("AspNetUsers_Id")]
        public string UserId { get; set; }
        public User User { get; set; }

        [DisplayName("Date de création")]
        public DateTime CreationDate { get; set; }
    }
}
