using StudyCESI.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudyCESI.Web.Models
{
    public class CreateAnswerViewModel
    {
        public Question Question { get; set; }

        public bool IsBoolAnswer { get; set; }
        public BoolAnswer BoolAnswer { get; set; }
        public IEnumerable<BoolAnswer> ListBoolAnswer { get; set; }

        public bool IsChoiceAnswer { get; set; }
        public ChoiceAnswer ChoiceAnswer { get; set; }
        public IEnumerable<ChoiceAnswer> ListChoiceAnswer { get; set; }

        public bool IsHoleAnswer { get; set; }
        public HoleAnswer HoleAnswer { get; set; }
        public List<HoleAnswer> ListHoleAnswer { get; set; }
    }
}
