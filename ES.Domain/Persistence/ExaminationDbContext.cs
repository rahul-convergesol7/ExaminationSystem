using ES.Domain.Entity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Domain.Persistence
{
    public class ExaminationDbContext : IdentityDbContext<ApplicationUser,ApplicationRole,int>
    {
        public ExaminationDbContext(DbContextOptions<ExaminationDbContext> options) : base(options) { }

        public DbSet<QuestionMaster> QuestionMasters { get; set; }

        public DbSet<OptionMaster> OptionMasters { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
