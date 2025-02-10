using Microsoft.EntityFrameworkCore;
using OneToOne.Context;
using OneToOne.Entities;

namespace OneToOne;

public class Program
{
    public static void Main(string[] args)
    {
        using var context = new AppDbContext();
        context.Database.EnsureDeleted();
        context.Database.EnsureCreated();

        var existItem = context.People.Where(p => p.Name == "John Doe").FirstOrDefault();

        if (existItem != null)
        {
            context.People.Remove(existItem);
            context.SaveChanges();
        }

        var person = new Person
        {
            Name = "John Doe",
            Passport = new Passport
            {
                Number = "123456789"
            }
        };

        context.People.Add(person);
        context.SaveChanges();

        var savedPerson = context.People.Include(p => p.Passport).FirstOrDefault(p => p.PersonId == person.PersonId);

        Console.WriteLine($"Person: {savedPerson.Name}, Passport Number: {savedPerson.Passport.Number}");
        Console.ReadKey();
    }
}