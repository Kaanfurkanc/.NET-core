using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace RestfullServiceMongoDB.Models
{
    public class MongoDbSettings
    {

        public string? ConnectionURI { get; set; }
        public string? Database { get; set;}
        public string? Collection { get; set; }
    }
}
