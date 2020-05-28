using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace StudyCESI.Model.Entities
{
    public class BoolAnswer
    {
        public int BoolAnswerId { get; set; }

        [DisplayName("Réponse")]
        public bool Answer { get; set; }

        public DateTime CreationDate { get; set; }

        [Column("Question_QuestionId")]
        public int QuestionId { get; set; }
        public Question Question { get; set; } //Test du gitignore
    }
}
