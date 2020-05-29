using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace StudyCESI.Model.Entities
{
    public class Subject
    {
        public int SubjectId { get; set; }

        [DisplayName("Sujet")]
        public string Name { get; set; }


        [DisplayName("Date de création")]
        public DateTime CreationDate { get; set; }
    }
}
