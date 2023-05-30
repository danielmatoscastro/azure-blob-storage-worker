using System.Text.Json;
using BooksWorker.Models;

namespace BooksWorker.Services;

public class GutendexService : IGutendexService
{
    private const string GUTENDEX_API_GET_ALL_BOOKS_ENDPOINT = "https://gutendex.com/books/";
    private readonly ILogger<GutendexService> _logger;
    private readonly HttpClient _httpClient;

    public GutendexService(ILogger<GutendexService> logger, HttpClient httpClient)
    {
        _logger = logger;
        _httpClient = httpClient;
    }

    public async Task<BooksResponse?> GetAllBooks(CancellationToken ct)
    {
        HttpResponseMessage response = await _httpClient.GetAsync(GUTENDEX_API_GET_ALL_BOOKS_ENDPOINT, ct);
        response.EnsureSuccessStatusCode();

        Stream payload = await response.Content.ReadAsStreamAsync(ct);

        BooksResponse? result = await JsonSerializer.DeserializeAsync<BooksResponse>(payload, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        }, ct);
        return result;
    }
}