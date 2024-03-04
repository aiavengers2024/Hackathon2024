using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;

namespace ESGSurvey.Data.BusinessObject
{
    public class BlobServiceBO : IBlobServiceBO
    {
        private readonly IConfigurationSettings _configuration;

        public BlobServiceBO( IConfigurationSettings configuration)
        {
            _configuration = configuration;
        }

        public async Task<Uri> UploadFileBlobAsync(Stream content,  string fileName)
        {
            var containerClient = GetContainerClient(_configuration.AzureStorageBlobContainerName);
            var blobClient = containerClient.GetBlobClient(fileName);
            await blobClient.UploadAsync(content );
            return blobClient.Uri;
        }

        private BlobContainerClient GetContainerClient(string blobContainerName)
        {
            try
            {
                BlobServiceClient _blobServiceClient = new BlobServiceClient(_configuration.AzureStorageConnectionString);
                var containerClient = _blobServiceClient.GetBlobContainerClient(blobContainerName);
                containerClient.CreateIfNotExists(PublicAccessType.Blob);
                return containerClient;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}