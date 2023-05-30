using System.Globalization;
using System.Text.Json;
using BooksWorker.Models;
using BooksWorker.Services;
using CsvHelper;

namespace BooksWorker;

public class Worker : BackgroundService
{
    private readonly ILogger<Worker> _logger;
    private readonly IHostApplicationLifetime _hostApplicationLifetime;
    private readonly IGutendexService _gutendexService;
    private readonly IStorageService _storageService;

    public Worker(ILogger<Worker> logger, IHostApplicationLifetime hostApplicationLifetime, IGutendexService gutendexService, IStorageService storageService)
    {
        _logger = logger;
        _hostApplicationLifetime = hostApplicationLifetime;
        _gutendexService = gutendexService;
        _storageService = storageService;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        BooksResponse? booksResponse = await _gutendexService.GetAllBooks(stoppingToken);
        if (booksResponse == null)
        {
            throw new Exception("BooksResponse is null");
        }
        _logger.LogInformation($"BooksResponse has {booksResponse.Results.Count} items.");


        string filename = $"books-{DateTime.Today.ToString("yyyy-MM-dd")}.csv";
        using (StreamWriter st = new StreamWriter(filename))
        using (CsvWriter csvWriter = new CsvWriter(st, CultureInfo.InvariantCulture))
        {
            await csvWriter.WriteRecordsAsync(booksResponse.Results, stoppingToken);
            _logger.LogInformation("CSV done.");
        }

        await _storageService.UploadToStorage(filename);

        _hostApplicationLifetime.StopApplication();
    }
}
