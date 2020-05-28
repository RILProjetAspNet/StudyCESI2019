using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudyCESI.Model.Entities
{
    public class User : IdentityUser
    {
        public string Role { get; set; }
    }
}
