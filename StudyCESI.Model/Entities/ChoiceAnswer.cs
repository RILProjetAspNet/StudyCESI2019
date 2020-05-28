﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace StudyCESI.Model.Entities
{
    public class ChoiceAnswer
    {
        public int ChoiceAnswerId { get; set; }

        [DisplayName("Réponse")]
        public string Answer { get; set; }

        [DisplayName("Est vrai")]
        public bool IsRight { get; set; }

        public DateTime CreationDate { get; set; }

        [Column("Question_QuestionId")]
        public int QuestionId { get; set; }
        public Question Question { get; set; }
    }
}
