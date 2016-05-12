using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace RetroGamesWeb.Data.Entities
{
    [BsonIgnoreExtraElements]
    public class Player : MongoEntity
    {
        public Player()
        {
            Scores = new List<Score>();
        }

        public string Name { get; set; }

        [BsonRepresentation(BsonType.String)]
        public Gender Gender { get; set; }

        public List<Score> Scores { get; set; }
    }
}
