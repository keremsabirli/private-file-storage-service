using MongoDB.Driver;
using PrivateFileStorageService;
using PrivateFileStorageService.Models;
using System;
using System.Collections.Generic;

namespace PFSS.Services
{
    public class BaseService<T> where T: Shared
    {
        protected readonly IMongoCollection<T> collection;
        protected readonly IMongoDatabase database;
        public BaseService(IDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            database = client.GetDatabase(settings.DatabaseName);
            collection = database.GetCollection<T>(typeof(T).Name);
        }
        public T Add(T entity)
        {
            collection.InsertOne(entity);
            return entity;
        }
        public IList<T> Get()
        {
            return collection.Find(x => true).ToList();
        }
        public T Get(string id)
        {
            return collection.Find(x => x.Id == id).SingleOrDefault();
        }
        public IList<T> Get(FilterDefinition<T> filter)
        {
            return collection.Find(filter).ToList();
        }
        public void Update(T entity)
        {
            collection.ReplaceOne(x => x.Id == entity.Id, entity);
        }
        public void UpdateAndGet(T entity)
        {
            collection.FindOneAndReplace(x => x.Id == entity.Id, entity);
        }
        public void Delete(string id)
        {
            collection.DeleteOne(sub => sub.Id == id);
        }
    }
}
