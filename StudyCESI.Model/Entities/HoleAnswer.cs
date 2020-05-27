using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace StudyCESI.Model.Entities
{
    public class HoleAnswer
    {
        public int HoleAnswerId { get; set; }

        public string Answer { get; set; }

        public int HoleLimitStart { get; set; }

        public int HoleLimitEnd { get; set; }

        public DateTime CreationDate { get; set; }

        [Column("Question_QuestionId")]
        public int? QuestionId { get; set; }
        public Question Question { get; set; }
    }
}
