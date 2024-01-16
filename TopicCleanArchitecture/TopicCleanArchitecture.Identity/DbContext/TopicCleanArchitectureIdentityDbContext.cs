using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TopicCleanArchitecture.Identity.Models;

namespace TopicCleanArchitecture.Identity.DbContext
{
    public class TopicCleanArchitectureIdentityDbContext:IdentityDbContext<ApplicationUser>
    {
        public TopicCleanArchitectureIdentityDbContext(DbContextOptions<TopicCleanArchitectureIdentityDbContext> options)
            :base(options) 
        {
            
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(typeof(TopicCleanArchitectureIdentityDbContext).Assembly);
            base.OnModelCreating(builder);
        }
    }
}
