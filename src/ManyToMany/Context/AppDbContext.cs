using ManyToMany.Entities;
using Microsoft.EntityFrameworkCore;

namespace ManyToMany.Context;

public class AppDbContext : DbContext
{
    public DbSet<Student> Students { get; set; }
    public DbSet<Course> Courses { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var pathDatabase = "MY-DATA-FOLDER-PATH";
        optionsBuilder.UseSqlite($"Data Source={pathDatabase}\\DbSample.db");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Student>()
            .HasMany(s => s.Courses)
            .WithMany(c => c.Students)
            .UsingEntity<Dictionary<string, object>>(
                "StudentCourse",
                j => j.HasOne<Course>().WithMany().HasForeignKey("CourseId"),
                j => j.HasOne<Student>().WithMany().HasForeignKey("StudentId"));
    }
}