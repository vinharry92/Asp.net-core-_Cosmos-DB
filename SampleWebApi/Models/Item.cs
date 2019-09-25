using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleWebApi.Models
{
    public class Item
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        [JsonProperty(PropertyName = "name")]
        [BsonElement("name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "description")]
        [BsonElement("description")]
        public string Description { get; set; }

        [JsonProperty(PropertyName = "isComplete")]
        [BsonElement("isComplete")]
        public bool Completed { get; set; }

        [JsonProperty(PropertyName = "Flavor")]
        [BsonElement("Flavor")]
        public string Flavor { get; set; }
    }
}

