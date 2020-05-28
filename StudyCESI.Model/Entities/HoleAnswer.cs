using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace StudyCESI.Model.Entities
{
    public class HoleAnswer
    {
        public int HoleAnswerId { get; set; }

        [DisplayName("Réponse")]
        public string Answer { get; set; }

        [DisplayName("Trou début")]
        public int HoleLimitStart { get; set; }

        [DisplayName("Trou fin")]
        public int HoleLimitEnd { get; set; }

        [Column("Question_QuestionId")]
        [DisplayName("Question")]
        public int QuestionId { get; set; }
        public Question Question { get; set; }

        [DisplayName("Date de création")]
        public DateTime CreationDate { get; set; }
    }
}
