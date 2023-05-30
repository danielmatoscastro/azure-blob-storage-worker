using BooksWorker;
using BooksWorker.Services;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {
        services.AddHostedService<Worker>();
        services.AddHttpClient<IGutendexService, GutendexService>(httpClient => httpClient.DefaultRequestHeaders.Add("Accept", "application/json"));
    })
    .Build();

host.Run();
