using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel;

namespace StudyCESI.Model.Entities
{
    public class User : IdentityUser
    {
        [DisplayName("Rôle")]
        public string Role { get; set; }
        [DisplayName("Nom")]
        public string LastName { get; set; }
        [DisplayName("Prénom")]
        public string FirstName { get; set; }
    }
}
