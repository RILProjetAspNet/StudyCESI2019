﻿using StudyCESI.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudyCESI.Web.Models
{
    public class PassExamViewModel
    {
        public IEnumerable<Question> Questions { get; set; }
        public IEnumerable<ChoiceAnswer> ChoiceAnswers { get; set; }
    }
}
