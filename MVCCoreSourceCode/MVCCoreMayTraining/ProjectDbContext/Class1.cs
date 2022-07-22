using Microsoft.EntityFrameworkCore;
using PatientModel;
using System;

namespace ProjectDbContext
{
    public class PatientDbContext : DbContext
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Patient>().ToTable("tblPatient");
            // Mapping
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-4BSD0GC;Initial Catalog=PatientDB;Integrated Security=True");
        }
        public DbSet<Patient> Patients { get; set; }
    }
}
