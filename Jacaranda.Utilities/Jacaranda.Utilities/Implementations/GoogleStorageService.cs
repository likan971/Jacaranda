using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Google.Apis.Auth.OAuth2;
using Google.Cloud.Storage.V1;
using Jacaranda.Utilities.Interfaces;

namespace Jacaranda.Utilities.Implementations
{
    public class GoogleStorageService : ICloudStorage, IDisposable
    {
        private readonly string _projectId;
        private readonly StorageClient _client;

        public GoogleStorageService(string projectId)
        {
            _projectId = projectId;
            var credential = GoogleCredential.GetApplicationDefault();
            _client = StorageClient.Create(credential);
        }

        public Stream GetFileStream(string bucket, string fileName)
        {
            var mStream = new MemoryStream();
            _client.DownloadObjectAsync("yoyo-buket", "jrjy.png", mStream);
            return mStream;
        }

        public void Dispose()
        {
            _client.Dispose();
        }
    }
}
