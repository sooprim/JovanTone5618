using AutoMapper;
using Data.Entities;
using Data.Interfaces;
using Service.DTOs;
using Service.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Service.Services
{
    public class ClientService : IClientService
    {
        private readonly IClientRepository _clientRepository;
        private readonly IMapper _mapper;

        public ClientService(IClientRepository clientRepository, IMapper mapper)
        {
            _clientRepository = clientRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ClientDto>> GetAllAsync()
        {
            var clients = await _clientRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<ClientDto>>(clients);
        }

        public async Task<ClientDto> GetByIdAsync(int id)
        {
            var client = await _clientRepository.GetByIdAsync(id);
            return _mapper.Map<ClientDto>(client);
        }

        public async Task<ClientDto> CreateAsync(ClientDto clientDto)
        {
            var client = _mapper.Map<Client>(clientDto);
            var createdClient = await _clientRepository.CreateAsync(client);
            return _mapper.Map<ClientDto>(createdClient);
        }

        public async Task<ClientDto> UpdateAsync(int id, ClientDto clientDto)
        {
            var client = _mapper.Map<Client>(clientDto);
            client.Id = id;
            var updatedClient = await _clientRepository.UpdateAsync(client);
            return _mapper.Map<ClientDto>(updatedClient);
        }

        public async Task DeleteAsync(int id)
        {
            await _clientRepository.DeleteAsync(id);
        }
    }
} 