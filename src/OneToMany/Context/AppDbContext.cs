using Microsoft.EntityFrameworkCore;
using OneToMany.Entities;

namespace OneToMany.Context;

public class AppDbContext : DbContext
{
    public DbSet<Author> Authors { get; set; }
    public DbSet<Book> Books { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var pathDatabase = "MY-DATA-FOLDER-PATH";
        optionsBuilder.UseSqlite($"Data Source={pathDatabase}\\DbSample.db");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Author>()
            .HasMany(a => a.Books)
            .WithOne(b => b.Author)
            .HasForeignKey(b => b.AuthorId);
    }
}