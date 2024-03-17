
using miapi.Configuration;
using miapi.Models;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;

namespace miapi.Services
{
    public class ProyectosServices
    {
        private readonly IMongoCollection<Proyectos> _ProyectosCollection;

        public ProyectosServices(IOptions<DatabaseSettings> databaseSettings)
        {
            var mongoClient = new MongoClient(databaseSettings.Value.ConnectionString);

            var mongoDB = mongoClient.GetDatabase(databaseSettings.Value.DatabaseName);
            _ProyectosCollection = mongoDB.GetCollection<Proyectos>(databaseSettings.Value.CollectionName);//
        }




        public async Task<List<Proyectos>> GetAsync() => await _ProyectosCollection.Find(_ => true).ToListAsync();

        public async Task<Proyectos> GetProyectoById(string Id)
        {
            return await _ProyectosCollection.FindAsync(new BsonDocument { { "_id", new ObjectId(Id) } }).Result.FirstAsync();
        }

        public async Task InsertProyecto(Proyectos proyectos)
        {
            await _ProyectosCollection.InsertOneAsync(proyectos);
        }

        public async Task UpdateProyecto(Proyectos proyectos)
        {
            var filter = Builders<Proyectos>.Filter.Eq(s => s.Id, proyectos.Id);
            await _ProyectosCollection.ReplaceOneAsync(filter, proyectos);
        }

        public async Task DeleteProyecto(string Id)
        {
            var filter = Builders<Proyectos>.Filter.Eq(s => s.Id, Id);
            await _ProyectosCollection.DeleteOneAsync(filter);
        }
    }

}
