using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Builders;
using RetroGamesWeb.Data.Entities;

namespace RetroGamesWeb.Data.Services
{
    public abstract class EntityService<T> : IEntityService<T> where T : IMongoEntity
    {
        protected readonly MongoConnectionHandler<T> MongoConnectionHandler;

        public virtual void Create(T entity)
        {
            //// Save the entity with safe mode (WriteConcern.Acknowledged)
            var result = Save(entity);
            if (!result.IsCompleted)
            {
                //// Something went wrong
            }
        }

        public async Task<ReplaceOneResult> Save(T entity)
        {
            var replaceOneResult = await MongoConnectionHandler.MongoCollection.ReplaceOneAsync(
                doc => doc.Id == entity.Id,
                entity,
                new UpdateOptions { IsUpsert = true });
            return replaceOneResult;
        }

        public virtual void Delete(string id)
        {
            var filter = Builders<Game>.Filter.Eq(s => s.Id.ToString(), id);
            var result = MongoConnectionHandler.MongoCollection.FindOneAndDelete(
                Query<T>.EQ(e => e.Id,
                new ObjectId(id)),
                RemoveFlags.None,
                WriteConcern.Acknowledged);

            if (!result.Ok)
            {
                //// Something went wrong
            }
        }
        
        protected EntityService()
        {
            MongoConnectionHandler = new MongoConnectionHandler<T>();
        }

        public virtual T GetById(string id)
        {
            var entityQuery = Query<T>.EQ(e => e.Id, new ObjectId(id));
            return this.MongoConnectionHandler.MongoCollection.FindOne(entityQuery);
        }

        public abstract void Update(T entity);
    }
}
