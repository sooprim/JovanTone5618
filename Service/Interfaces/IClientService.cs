using Service.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Service.Interfaces
{
    public interface IClientService
    {
        Task<IEnumerable<ClientDto>> GetAllAsync();
        Task<ClientDto> GetByIdAsync(int id);
        Task<ClientDto> CreateAsync(ClientDto clientDto);
        Task<ClientDto> UpdateAsync(int id, ClientDto clientDto);
        Task DeleteAsync(int id);
    }
} 