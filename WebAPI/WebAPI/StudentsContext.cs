using Microsoft.EntityFrameworkCore;
using WebAPI.Models;

namespace WebAPI
{
    public class StudentsContext : DbContext
    {
        public StudentsContext(DbContextOptions<StudentsContext> options) : base(options) { }

        public DbSet<Student> students { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) 
        {
            modelBuilder.Entity<Student>().ToTable("students");
        }

    }
}
