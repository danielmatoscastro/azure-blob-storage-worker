namespace BooksWorker.Services;

public class StorageSettings
{
    public const string Storage = "Storage";

    public string ConnectionString { get; set; } = null!;
    public string Container { get; set; } = null!;
}