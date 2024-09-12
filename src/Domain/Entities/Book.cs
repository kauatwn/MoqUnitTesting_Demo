namespace Domain.Entities;

public class Book(int id, string title, string author)
{
    public int Id { get; private set; } = id;
    public string Title { get; private set; } = title;
    public string Author { get; private set; } = author;
}