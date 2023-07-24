using Azure.Storage.Blobs.Models;
using Azure.Storage.Blobs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IOTSimulator.Interfaces;
using IOTSimulator.Models;
using Newtonsoft.Json;
using System.IO.Compression;
using System.IO;

namespace IOTSimulator.Helpers
{
  
    public class BlobStorage : IBlobStorage
    {
        public async Task<List<string>> GetAllDocuments(string connectionString, string containerName)
        {
            var container = BlobExtensions.GetContainer(connectionString, containerName);

            if (!await container.ExistsAsync())
            {
                return new List<string>();
            }

            List<string> blobs = new();

            await foreach (BlobItem blobItem in container.GetBlobsAsync())
            {
                blobs.Add(blobItem.Name);
            }
            return blobs;
        }

        public async Task UploadDocument(string connectionString, string containerName, string fileName, FileStream fileContent)
        {
            var container = BlobExtensions.GetContainer(connectionString, containerName);
            if (!await container.ExistsAsync())
            {
                BlobServiceClient blobServiceClient = new(connectionString);
                await blobServiceClient.CreateBlobContainerAsync(containerName);
                container = blobServiceClient.GetBlobContainerClient(containerName);
            }

            var bobclient = container.GetBlobClient(fileName);
            if (!bobclient.Exists())
            {
                fileContent.Position = 0;
                await container.UploadBlobAsync(fileName, fileContent);
            }
            else
            {
                fileContent.Position = 0;
                await bobclient.UploadAsync(fileContent, overwrite: true);
            }
        }

        public async Task UploadDocument(string connectionString, string containerName, string fileName, Stream fileContent)
        {
            var container = BlobExtensions.GetContainer(connectionString, containerName);
            if (!await container.ExistsAsync())
            {
                BlobServiceClient blobServiceClient = new(connectionString);
                await blobServiceClient.CreateBlobContainerAsync(containerName);
                container = blobServiceClient.GetBlobContainerClient(containerName);
            }

            var bobclient = container.GetBlobClient(fileName);
            if (!bobclient.Exists())
            {
                fileContent.Position = 0;
                await container.UploadBlobAsync(fileName, fileContent);
            }
            else
            {
                fileContent.Position = 0;
                await bobclient.UploadAsync(fileContent, overwrite: true);
            }
        }
        public async Task< string> GetDocumentStream(string connectionString, string containerName, string fileName)
        {
            BlobServiceClient blobServiceClient = new BlobServiceClient(connectionString);
            BlobContainerClient containerClient = blobServiceClient.GetBlobContainerClient(containerName);
            BlobClient blobClient = containerClient.GetBlobClient(fileName);



            if (await blobClient.ExistsAsync())
            {
                var response = await blobClient.DownloadAsync();
                var streamReader = new StreamReader(response.Value.Content);
                return streamReader.ReadToEndAsync().Result;
            }
            else
            {
                return null;
            }


        }


        public async Task<T> GetDocument<T>(string connectionString, string containerName, string fileName)
        {
            BlobServiceClient blobServiceClient = new BlobServiceClient(connectionString);
            BlobContainerClient containerClient = blobServiceClient.GetBlobContainerClient(containerName);
            BlobClient blobClient = containerClient.GetBlobClient(fileName);
            try
            {
                if ( blobClient.Exists())
                {
                    var response = await blobClient.DownloadAsync();
                    var streamReader = new StreamReader(response.Value.Content);
                    var s=streamReader.ReadToEndAsync().Result;
                    var line = string.Empty;
                    //while (!streamReader.EndOfStream)
                    //{
                    //    line = line + await streamReader.ReadLineAsync();
                    //}
                    //var congurationJsonData = new CongurationJSON();

                    return JsonConvert.DeserializeObject<T>(s);
                    blobClient.DeleteAsync();

                }
                else
                {
                    return JsonConvert.DeserializeObject<T>("");
                }
            }
            catch (Exception e)
            {

                throw new FileNotFoundException();
            }
           
                    //var container = BlobExtensions.GetContainer(connectionString, containerName);
                    //var bobclient = container.GetBlobClient(fileName);
                    //if (!bobclient.Exists())
                    //{ 
                    //    var blobClient = container.GetBlobClient(fileName);
                    //    if (blobClient.Exists())
                    //    {
                    //        var content = await blobClient.DownloadStreamingAsync();
                    //        return content.Value.Content;
                    //    }
                    //    else
                    //    {
                    //        throw new FileNotFoundException();
                    //    }
                    //}
                    //else
                    //{
                    //    throw new FileNotFoundException();
                    //}

                }

                public async Task<bool> DeleteDocument(string connectionString, string containerName, string fileName)
        {
            var container = BlobExtensions.GetContainer(connectionString, containerName);
            if (!await container.ExistsAsync())
            {
                return false;
            }

            var blobClient = container.GetBlobClient(fileName);

            if (await blobClient.ExistsAsync())
            {
                await blobClient.DeleteIfExistsAsync();
                return true;
            }
            else
            {
                return false;
            }
        }
    }

    public static class BlobExtensions
    {
        public static BlobContainerClient GetContainer(string connectionString, string containerName)
        {
            BlobServiceClient blobServiceClient = new(connectionString);
            return blobServiceClient.GetBlobContainerClient(containerName);
        }
    }
}