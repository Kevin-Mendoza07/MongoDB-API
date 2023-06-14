using APIMongodbs.Models;
using MongoDB.Bson;
using MongoDB.Driver;

namespace APIMongodbs.Repositories
{
    public class ClienteCollection : IClienteCollection
    {
        internal MongoDBRepository _repository = new MongoDBRepository();
        private IMongoCollection<Cliente> Collection;

        public ClienteCollection()
        {
            Collection = _repository.db.GetCollection<Cliente>("Cliente");
        }
        public async Task DeleteCliente(string id)
        {
            var filter = Builders<Cliente>.Filter.Eq(s => s.id, new ObjectId(id));
            await Collection.DeleteOneAsync(filter);
        }

        public async Task<List<Cliente>> GetAllCliente()
        {
            return await Collection.FindAsync(new BsonDocument()).Result.ToListAsync();
        }

        public async Task<Cliente> GetClienteById(string id)
        {
            return await Collection.FindAsync(new BsonDocument{{ "_id", new ObjectId(id)}}).Result.FirstAsync();
        }

        public async Task InsertCliente(Cliente cliente)
        {
           await Collection.InsertOneAsync(cliente);
        }

        public async Task UpdateCliente(Cliente cliente)
        {
            var filter = Builders<Cliente>.Filter.Eq(s => s.id, cliente.id);

            await Collection.ReplaceOneAsync(filter, cliente);
        }
    }
}
