using BooksWorker;
using BooksWorker.Services;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {
        services.AddHostedService<Worker>();
        services.AddHttpClient<IGutendexService, GutendexService>();
    })
    .Build();

host.Run();
