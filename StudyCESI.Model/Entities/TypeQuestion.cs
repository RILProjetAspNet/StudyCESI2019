﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace StudyCESI.Model.Entities
{
    public class TypeQuestion
    {
        public int TypeQuestionId { get; set; }

        [DisplayName("Nom")]
        public string Name { get; set; }

        [DisplayName("Libellé")]
        public string Wording { get; set; }


        [DisplayName("Date de création")]
        public DateTime CreationDate { get; set; }
    }
}
