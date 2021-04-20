using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.VisualBasic;
using MongoDB.Bson;
using MongoDB.Driver;
using VeterinaryСlinic.Entities;

namespace VeterinaryСlinic.Repositories
{
    public class PetRepository : Repository<Pet>
    {
        public PetRepository(IMongoDatabase database) : base(database)
        {
            collection.Indexes.CreateOne(new CreateIndexModel<Pet>(Builders<Pet>.IndexKeys.Descending(pet => pet.RegistrationDate)));
            collection.Indexes.CreateOne(new CreateIndexModel<Pet>(Builders<Pet>.IndexKeys.Descending(pet => pet.KindOfAnimal)));
        }
        public List<Pet> FindWithLimit(int pageSize, int page)
        {
            var resultFind = collection.Find(p => p.Name != null)
                                                .Sort(Builders<Pet>.Sort.Descending(p => p.RegistrationDate))
                                                .Skip((page - 1) * pageSize)
                                                .Limit(pageSize).ToList();
            return resultFind;
        }

        public List<PetGrouping> Aggregate()
        {
            var aggregation = collection
                .Aggregate(new AggregateOptions {AllowDiskUse = true})
                .Group(pet => pet.KindOfAnimal,
                    (group) => new PetGrouping {KindOfKindOfAnimal = group.Key, Amount = group.Count()})
                .Sort(Builders<PetGrouping>.Sort.Descending(p => p.Amount));

            return aggregation.ToList();
        }
    }
}
