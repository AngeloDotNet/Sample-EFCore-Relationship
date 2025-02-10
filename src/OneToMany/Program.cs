using Microsoft.EntityFrameworkCore;
using OneToMany.Context;
using OneToMany.Entities;

namespace OneToMany;

public class Program
{
    public static void Main(string[] args)
    {
        using var context = new AppDbContext();
        context.Database.EnsureDeleted();
        context.Database.EnsureCreated();

        // Aggiungi un autore con alcuni libri
        var author = new Author
        {
            Name = "Stephen King",
            Books = [
                new Book { Title = "The Shining" },
                new Book { Title = "It" }
            ]
        };

        context.Authors.Add(author);
        context.SaveChanges();

        // Recupera i dati
        var authorsWithBooks = context.Authors.Include(a => a.Books).ToList();

        foreach (var a in authorsWithBooks)
        {
            Console.WriteLine($"Autore: {a.Name}");

            foreach (var book in a.Books)
            {
                Console.WriteLine($"  Libro: {book.Title}");
            }
        }

        Console.ReadKey();
    }
}
