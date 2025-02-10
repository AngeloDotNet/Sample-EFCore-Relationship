namespace OneToMany.Entities;

public class Book
{
    public int BookId { get; set; }
    public string Title { get; set; }
    public int AuthorId { get; set; }

    // Navigation property
    public Author Author { get; set; }
}