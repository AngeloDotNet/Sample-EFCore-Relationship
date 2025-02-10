namespace OneToMany.Entities;

public class Author
{
    public int AuthorId { get; set; }
    public string Name { get; set; }

    // Navigation property
    public ICollection<Book> Books { get; set; }
}