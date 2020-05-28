﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace StudyCESI.Model.Entities
{
    public class Subject
    {
        public int SubjectId { get; set; }

        [DisplayName("Nom")]
        public string Name { get; set; }

        public DateTime CreationDate { get; set; }
    }
}
