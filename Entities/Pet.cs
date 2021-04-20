using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.IdGenerators;

namespace VeterinaryСlinic.Entities
{
    public class Pet : IEntity
    {
        public Pet()
        {
            Id = ObjectId.GenerateNewId();
        }
        public ObjectId Id { get; set; }
        public string Name { get; set; }
        public string KindOfAnimal { get; set; }
        public DateTime RegistrationDate { get; set; }
        public Owner Owner { get; set; }
    }
}
