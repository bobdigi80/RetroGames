using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Builders;
using RetroGamesWeb.Data.Entities;

namespace RetroGamesWeb.Data.Services
{
    public class GameService : EntityService<Game>
    {
        public async Task<List<BsonDocument>> GetGamesDetails(int limit, int skip)
        {
            var options = new FindOptions
            {
                MaxTime = TimeSpan.FromMilliseconds(20)
            };
            var gamesCursor = await MongoConnectionHandler.MongoCollection.Find(_ => true, options).Project(Builders<Game>.Projection
                                                    .Include(g => g.Id))
                    .Skip(skip)
                    .Limit(limit)
                    .SortBy(x => x.ReleaseDate)
                    .ToListAsync();
            
            return  gamesCursor;
        }


        public override void Update(Game entity)
        {
            //// Not necessary for the example
        }
    }
}
