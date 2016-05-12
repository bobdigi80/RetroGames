using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace RetroGamesWeb.Data.Entities
{
    public class MongoEntity: IMongoEntity
    {
        [BsonId]
        public ObjectId Id { get; set; }
    }
}
