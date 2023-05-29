namespace BooksWorker.Models;

public class Book
{
    public int Id { get; set; }
    public string Title { get; set; } = null!;
    public List<string> Subjects { get; set; } = new();
    public List<Person> Authors { get; set; } = new();
    public List<string> Bookshelves { get; set; } = new();
    public List<string> Languages { get; set; } = new();
    public bool? Copyright { get; set; } = new();
    public string MediaType { get; set; } = null!;
    public Dictionary<string, string> Formats { get; set; } = new();
    public int DownloadCount { get; set; }

}