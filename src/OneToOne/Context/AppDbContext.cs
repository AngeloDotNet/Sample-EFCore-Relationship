using Microsoft.EntityFrameworkCore;
using OneToOne.Entities;

namespace OneToOne.Context;

public class AppDbContext : DbContext
{
    public DbSet<Person> People { get; set; }
    public DbSet<Passport> Passports { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var pathDatabase = "MY-DATA-FOLDER-PATH";
        optionsBuilder.UseSqlite($"Data Source={pathDatabase}\\DbSample.db");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Person>()
            .HasOne(p => p.Passport)
            .WithOne(p => p.Person)
            .HasForeignKey<Passport>(p => p.PersonId);

        base.OnModelCreating(modelBuilder);
    }
}