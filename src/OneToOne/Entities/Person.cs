namespace OneToOne.Entities;

public class Person
{
    public int PersonId { get; set; }
    public string Name { get; set; }

    // Navigation property
    public Passport Passport { get; set; }
}