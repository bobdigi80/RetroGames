using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace RetroGamesWeb.Data.Entities
{
    [BsonIgnoreExtraElements]
    public class Score
    {
        public ObjectId GameId { get; set; }

        public string GameName { get; set; }

        public int ScoreValue { get; set; }

        public DateTime ScoreDateTime { get; set; }
    }
}
