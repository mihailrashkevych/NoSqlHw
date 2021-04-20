using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;
using VeterinaryСlinic.Entities;

namespace VeterinaryСlinic.Repositories
{
    public class Repository<TEntity> where TEntity : IEntity

    {
        protected readonly IMongoCollection<TEntity> collection;

        public Repository(IMongoDatabase database)
        {
            collection = database.GetCollection<TEntity>(typeof(TEntity).Name);
        }

        public TEntity Get(ObjectId id)

        {
            var filter = Builders<TEntity>.Filter.Eq(e => e.Id, id);
            return collection.Find(filter).FirstOrDefault();
        }

        public ObjectId Insert(TEntity entity)

        {
            collection.InsertOne(entity);
            return entity.Id;
        }
    }
}
