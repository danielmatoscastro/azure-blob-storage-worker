using BooksWorker;
using BooksWorker.Services;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((hostContext, services) =>
    {
        services.Configure<StorageSettings>(hostContext.Configuration.GetSection(StorageSettings.Storage));
        services.AddHostedService<Worker>();
        services.AddHttpClient<IGutendexService, GutendexService>();
        services.AddTransient<IStorageService, StorageService>();
    })
    .Build();

host.Run();
