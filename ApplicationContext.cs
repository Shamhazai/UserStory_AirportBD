using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using UserStory_Airport.models;

namespace UserStory_Airport
{
    public class ApplicationContext : DbContext
    {
        /// <summary>
        /// Набор сущностей класса Tours
        /// </summary>
        public DbSet<Reisi> AirportDB { get; set; }

        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Reisi>().HasKey(u => u.ID);
        }

    }
}
