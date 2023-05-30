namespace BooksWorker.Services;

public interface IStorageService
{
    Task UploadToStorage(string filename);
}