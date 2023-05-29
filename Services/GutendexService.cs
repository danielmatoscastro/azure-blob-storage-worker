using System.Text.Json;
using BooksWorker.Models;

namespace BooksWorker.Services;

public class GutendexService : IGutendexService
{
    private const string GUTENDEX_API_GET_ALL_BOOKS_ENDPOINT = "http://gutendex.com/books";

    private readonly IHttpClientFactory _httpClientFactory;

    public GutendexService(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    public async Task<BooksResponse?> GetAllBooks(CancellationToken ct)
    {
        HttpClient httpClient = _httpClientFactory.CreateClient("gutendex");
        HttpResponseMessage response = await httpClient.GetAsync(GUTENDEX_API_GET_ALL_BOOKS_ENDPOINT, ct);
        response.EnsureSuccessStatusCode();

        Stream payload = await response.Content.ReadAsStreamAsync(ct);

        BooksResponse? result = await JsonSerializer.DeserializeAsync<BooksResponse>(payload, (JsonSerializerOptions?)null, ct);
        return result;
    }
}