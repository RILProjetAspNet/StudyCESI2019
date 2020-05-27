using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using StudyCESI.Model.Entities;

namespace StudyCESI.Web.Data
{
    public class StudyCESIWebContext : DbContext
    {
        public StudyCESIWebContext (DbContextOptions<StudyCESIWebContext> options)
            : base(options)
        {
        }

        public DbSet<StudyCESI.Model.Entities.Question> Question { get; set; }
    }
}
