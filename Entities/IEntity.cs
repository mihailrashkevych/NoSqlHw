using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace VeterinaryСlinic.Entities
{
    public interface IEntity
    {
        public ObjectId Id { get; set; }
    }
}
