using MongoDB.Bson;

namespace RetroGamesWeb.Data.Entities
{
    public interface IMongoEntity
    {
        ObjectId Id { get; set; }
    }
}
