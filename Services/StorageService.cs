using Azure.Storage.Blobs;
using Microsoft.Extensions.Options;

namespace BooksWorker.Services;

public class StorageService : IStorageService
{
    private readonly IOptions<StorageSettings> _storageSettings;

    public StorageService(IOptions<StorageSettings> storageSettings)
    {
        _storageSettings = storageSettings;
    }

    public async Task UploadToStorage(string filename)
    {
        BlobServiceClient blobServiceClient = new BlobServiceClient(_storageSettings.Value.ConnectionString);
        BlobContainerClient containerClient = blobServiceClient.GetBlobContainerClient(_storageSettings.Value.Container);
        BlobClient blobClient = containerClient.GetBlobClient(filename);
        await blobClient.UploadAsync(filename);
    }
}