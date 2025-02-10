namespace OneToOne.Entities;

public class Passport
{
    public int PassportId { get; set; }
    public string Number { get; set; }

    // Foreign key
    public int PersonId { get; set; }

    // Navigation property
    public Person Person { get; set; }
}