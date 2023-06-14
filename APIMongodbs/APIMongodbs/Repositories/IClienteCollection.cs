using APIMongodbs.Models;

namespace APIMongodbs.Repositories
{
    public interface IClienteCollection
    {
        Task InsertCliente(Cliente cliente);
        Task UpdateCliente(Cliente cliente);
        Task DeleteCliente(string id);  
        Task<Cliente> GetClienteById(string id);
        Task<List<Cliente>> GetAllCliente();
    }
}
