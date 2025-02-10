namespace ManyToMany.Entities;

public class Course
{
    public int CourseId { get; set; }
    public string Title { get; set; }

    // Navigation property
    public ICollection<Student> Students { get; set; }
}