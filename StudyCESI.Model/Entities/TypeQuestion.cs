using System;
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

        public DateTime CreationDate { get; set; }
    }
}
