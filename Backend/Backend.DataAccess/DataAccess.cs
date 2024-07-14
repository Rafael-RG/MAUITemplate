using Azure;
using Azure.Storage;
using Azure.Storage.Blobs;
using Azure.Storage.Sas;
using Backend.Common.Interfaces;
using Backend.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.DataAccess
{
    /// <inheritdoc/>
    public class DataAccess : IDisposable, IDataAccess
    {
        private readonly DatabaseContext context;
        private bool disposed = false;
        private readonly string storageConnectionString;
        private readonly BlobServiceClient blobServiceClient;
       
        
        /// <inheritdoc/>
        public IRepository<Document> Documents { get; }


        /// <summary>
        /// Gets the configuration
        /// </summary>
        public DataAccess(IConfiguration configuration)
        {
            this.context = new DatabaseContext(configuration);
            this.Documents = new Repository<Document>(context);
            this.context.Database.EnsureCreated();
            this.storageConnectionString = configuration["StorageConnectionString"];
            this.blobServiceClient = new BlobServiceClient(this.storageConnectionString);      
        }



        /// <inheritdoc/>
        public Task<int> SaveChangesAsync()
        {
            return context.SaveChangesAsync();
        }



        /// <inheritdoc/>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }


        /// <inheritdoc/>
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed && !disposing)
            {
                context.Dispose();
            }
            this.disposed = true;
        }


        /// <inheritdoc/>
        public string GetSasToken(string container, int expiresOnMinutes)
        {
            // Generates the token for this account
            var accountKey = string.Empty;
            var accountName = string.Empty;
            var connectionStringValues = this.storageConnectionString.Split(';')
                .Select(s => s.Split([ '=' ], 2))
                .ToDictionary(s => s[0], s => s[1]);
            if (connectionStringValues.TryGetValue("AccountName", out var accountNameValue) && !string.IsNullOrWhiteSpace(accountNameValue)
                && connectionStringValues.TryGetValue("AccountKey", out var accountKeyValue) && !string.IsNullOrWhiteSpace(accountKeyValue))
            {
                accountKey = accountKeyValue;
                accountName = accountNameValue;

                var storageSharedKeyCredential = new StorageSharedKeyCredential(accountName, accountKey);
                var blobSasBuilder = new BlobSasBuilder()
                {
                    BlobContainerName = container,
                    ExpiresOn = DateTime.UtcNow + TimeSpan.FromMinutes(expiresOnMinutes)
                };

                blobSasBuilder.SetPermissions(BlobAccountSasPermissions.All);
                var queryParams = blobSasBuilder.ToSasQueryParameters(storageSharedKeyCredential);
                var sasToken = queryParams.ToString();
                return sasToken;
            }
            return string.Empty;
        }

        /// <summary>
        /// Crear un nuevo blob en un contenedor
        /// </summary>
        public async Task<Uri> CreateBlobAsync(Stream content, string filenanem, string containerName)
        {
            try
            {
                var containerClient = this.blobServiceClient.GetBlobContainerClient(containerName);
                var blobClient = containerClient.GetBlobClient(filenanem);

                using (var stream = new MemoryStream())
                {
                    content.CopyTo(stream);
                    stream.Position = 0;
                    await blobClient.UploadAsync(stream, true);
                }

                // Devuelve el URI del blob
                return blobClient.Uri;
            }
            catch
            {
                return null;
            }
        }


    }
}
