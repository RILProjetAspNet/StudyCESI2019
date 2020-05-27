using System;
using System.Collections.Generic;
using System.Text;

namespace StudyCESI.Model.Entities
{
    public class TypeQuestion
    {
        public int TypeQuestionId { get; set; }

        public string Name { get; set; }

        public string Wording { get; set; }

        public DateTime CreationDate { get; set; }
    }
}
