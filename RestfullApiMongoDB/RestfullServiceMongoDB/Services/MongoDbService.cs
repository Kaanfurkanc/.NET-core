using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.IdGenerators;
using MongoDB.Driver;
using RestfullServiceMongoDB.Models;

namespace RestfullServiceMongoDB.Services
{
    public class MongoDbService
    {
        private readonly IMongoCollection<PlayList> _playListCollection;

        public MongoDbService(IOptions<MongoDbSettings> mongoDbSettings)
        {
            MongoClient client = new MongoClient(mongoDbSettings.Value.ConnectionURI);
            IMongoDatabase database = client.GetDatabase(mongoDbSettings.Value.Database);
            _playListCollection = database.GetCollection<PlayList>(mongoDbSettings.Value.Collection);
        }

        public async Task CreateAsync(PlayList playList)
        {
            await _playListCollection.InsertOneAsync(playList);
        }

        public async Task<List<PlayList>> GetAllAsync()
        {
            return await _playListCollection.Find(new BsonDocument()).ToListAsync();
        }

        public async Task<PlayList> GetByIdAsync(string id)
        {
            return await _playListCollection.Find(id).FirstOrDefaultAsync();
        }

        public async Task UpdateAsync(string id, string movieId)
        {
            FilterDefinition<PlayList> filter = Builders<PlayList>.Filter.Eq("Id", id);
            UpdateDefinition<PlayList> update = Builders<PlayList>.Update.AddToSet<string>("movieId", movieId);
            await _playListCollection.UpdateOneAsync(filter, update);

        }
        public async Task RemoveManyAsync(string key,string option)
        {
            if (key == "Username")
            {
                var filters = Builders<PlayList>.Filter.Eq(r => r.Username, option);
                await _playListCollection.DeleteManyAsync(filters);
            }
        }
        public async Task RemoveAsync(string id)
        {
            await _playListCollection.FindOneAndDeleteAsync(id);
        }
    }
}
