using Microsoft.EntityFrameworkCore;
using PatientManageSystemServer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PatientManageSystemServer.EfContext
{
    public class PatientDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-4BSD0GC;Initial Catalog=PatientDB;Integrated Security=True");
            // DB connectionstring
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.
                Entity<Patient>().
                ToTable("tblPatients");
            modelBuilder.Entity<Problem>()
                .ToTable("tblAddress");
        }
        public DbSet<Patient> patients { get; set; }
    }
}
