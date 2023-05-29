using BooksWorker.Models;

namespace BooksWorker.Services;

public interface IGutendexService
{
    Task<BooksResponse?> GetAllBooks(CancellationToken ct);
}