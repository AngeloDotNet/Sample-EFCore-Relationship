using ManyToMany.Context;
using ManyToMany.Entities;
using Microsoft.EntityFrameworkCore;

namespace ManyToMany;

public class Program
{
    public static void Main(string[] args)
    {
        using var context = new AppDbContext();
        context.Database.EnsureDeleted();
        context.Database.EnsureCreated();

        var student1 = new Student { Name = "Alice" };
        var student2 = new Student { Name = "Bob" };

        var course1 = new Course { Title = "Mathematics" };
        var course2 = new Course { Title = "History" };

        student1.Courses = [course1, course2];
        student2.Courses = [course1];

        context.Students.Add(student1);
        context.Students.Add(student2);

        context.SaveChanges();

        var students = context.Students.Include(s => s.Courses).ToList();

        foreach (var student in students)
        {
            Console.WriteLine($"{student.Name} is enrolled in the following courses:");

            foreach (var course in student.Courses)
            {
                Console.WriteLine($" - {course.Title}");
            }

            Console.WriteLine();
        }

        Console.ReadKey();
    }
}
