using Data.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Data.Interfaces
{
    public interface IClientRepository
    {
        Task<IEnumerable<Client>> GetAllAsync();
        Task<Client> GetByIdAsync(int id);
        Task<Client> CreateAsync(Client client);
        Task<Client> UpdateAsync(Client client);
        Task DeleteAsync(int id);
    }
} 