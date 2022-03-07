using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MusCalendar.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MusCalendar.Services
{
    public class MCServices
    {
        private readonly IMongoCollection<EventModel> _event;

        public MCServices(
            IOptions<DbCSettings> dbcsettings)
        {
            var mongoClient = new MongoClient(dbcsettings.Value.ConnectionString);

            var mongoDB = mongoClient.GetDatabase(dbcsettings.Value.DbName);

            _event = mongoDB.GetCollection<EventModel>(dbcsettings.Value.CollectionName);
        }

        // Find All
        public async Task<List<EventModel>> GetAsync() =>
            await _event.Find(_ => true).ToListAsync();

        // Find by Id
        public async Task<EventModel> GetByIdAsync(string id) =>
            await _event.Find(x => x.Id == id).FirstOrDefaultAsync();

        // Find by Title
        public async Task<EventModel?> GetByTitleAsync(string title) =>
            await _event.Find(x => x.Titulo == title).FirstOrDefaultAsync();

        // Create an event
        public async Task InsertOneAsync(EventModel newModel) =>
            await _event.InsertOneAsync(newModel);
        
        // Delete an event
        public async Task DeleteAsync(string id) =>
            await _event.DeleteOneAsync(x => x.Id == id);

        // Alter an event
        public async Task UpdateOneAsync(string id, EventModel alterEvent) =>
            await _event.ReplaceOneAsync(x => x.Id == id, alterEvent);
    }
}
