using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace StudyCESI.Model.Entities
{
    public class Subject
    {
        public int SubjectId { get; set; }

        [Column(TypeName = "varchar(255)")]
        [MaxLength(255)]
        public string Name { get; set; }

        public DateTime CreationDate { get; set; }
    }
}
