using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.GridFS;
using PrivateFileStorageService;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace PFSS.Services
{
    public class FileService : BaseService<PFSS.Models.File>
    {
        public GridFSBucket Bucket { get; set; }
        public FileService(IDatabaseSettings settings) : base(settings)
        {
            Bucket = new GridFSBucket(database, new GridFSBucketOptions
            {
                BucketName = "files",
                ChunkSizeBytes = 1048576, // 1MB
                WriteConcern = WriteConcern.WMajority,
                ReadPreference = ReadPreference.Secondary
            });
        }
        public async Task<ObjectId> Upload(Stream fileStream)
        {
            var id = await Bucket.UploadFromStreamAsync("test", fileStream);
            return id;
        }
    }
}
