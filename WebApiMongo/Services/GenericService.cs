using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using MongoDB.Driver;
using WebApiMongo.Models;

namespace WebApiMongo.Services
{
    public class GenericService<T>
    {
        private readonly IMongoCollection<T> _entity;
        
        public GenericService(IBookstoreDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _entity = database.GetCollection<T>(settings.BooksCollectionName);

        }

        public List<T> Get() =>
            _entity.Find(x => true).ToList();

        public T Get(Expression<Func<T, bool>> filter) =>
            _entity.Find<T>(filter).FirstOrDefault();

        public T Create(T entity)
        {
            _entity.InsertOne(entity);
            return entity;
        }

        public void Update(Expression<Func<T, bool>> filter, T entity) =>
            _entity.ReplaceOne(filter, entity);

        public void Remove(Expression<Func<T, bool>> filter) =>
            _entity.DeleteOne(filter);
    }
}