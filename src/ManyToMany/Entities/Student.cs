namespace ManyToMany.Entities;

public class Student
{
    public int StudentId { get; set; }
    public string Name { get; set; }

    // Navigation property
    public ICollection<Course> Courses { get; set; }
}