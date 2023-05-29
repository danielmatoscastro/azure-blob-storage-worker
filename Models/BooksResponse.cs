namespace BooksWorker.Models;

public class BooksResponse
{
    public int Count { get; set; }
    public string? Next { get; set; }
    public string? Previous { get; set; }
    public List<Book> Results { get; set; }
}