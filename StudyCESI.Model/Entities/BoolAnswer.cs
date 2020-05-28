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

        [Column("Question_QuestionId")]
        [DisplayName("Question")]
        public int QuestionId { get; set; }
        public Question Question { get; set; } //Test du gitignore

        [DisplayName("Date de création")]
        public DateTime CreationDate { get; set; }
    }
}
