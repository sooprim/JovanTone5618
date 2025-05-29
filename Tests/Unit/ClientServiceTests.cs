using AutoMapper;
using Data.Entities;
using Data.Interfaces;
using Moq;
using Service.DTOs;
using Service.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Tests.Unit
{
    public class ClientServiceTests
    {
        private readonly Mock<IClientRepository> _mockClientRepository;
        private readonly Mock<IMapper> _mockMapper;
        private readonly ClientService _clientService;

        public ClientServiceTests()
        {
            _mockClientRepository = new Mock<IClientRepository>();
            _mockMapper = new Mock<IMapper>();
            _clientService = new ClientService(_mockClientRepository.Object, _mockMapper.Object);
        }

        [Fact]
        public async Task GetAllAsync_ShouldReturnAllClients()
        {
            // Arrange
            var clients = new List<Client>
            {
                new Client { Id = 1, FirstName = "Jovan", LastName = "Tone" },
                new Client { Id = 2, FirstName = "Vangel", LastName = "Tone" }
            };

            var clientDtos = new List<ClientDto>
            {
                new ClientDto { Id = 1, FirstName = "Jovan", LastName = "Tone" },
                new ClientDto { Id = 2, FirstName = "Vangel", LastName = "Tone" }
            };

            _mockClientRepository.Setup(repo => repo.GetAllAsync())
                .ReturnsAsync(clients);

            _mockMapper.Setup(mapper => mapper.Map<IEnumerable<ClientDto>>(clients))
                .Returns(clientDtos);

            // Act
            var result = await _clientService.GetAllAsync();

            // Assert
            Assert.Equal(2, result.Count());
            _mockClientRepository.Verify(repo => repo.GetAllAsync(), Times.Once);
        }

        [Fact]
        public async Task GetByIdAsync_ShouldReturnClient_WhenClientExists()
        {
            // Arrange
            var client = new Client { Id = 1, FirstName = "Jovan", LastName = "Tone" };
            var clientDto = new ClientDto { Id = 1, FirstName = "Jovan", LastName = "Tone" };

            _mockClientRepository.Setup(repo => repo.GetByIdAsync(1))
                .ReturnsAsync(client);

            _mockMapper.Setup(mapper => mapper.Map<ClientDto>(client))
                .Returns(clientDto);

            // Act
            var result = await _clientService.GetByIdAsync(1);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(clientDto.Id, result.Id);
            Assert.Equal(clientDto.FirstName, result.FirstName);
            Assert.Equal(clientDto.LastName, result.LastName);
        }

        [Fact]
        public async Task CreateAsync_ShouldReturnCreatedClient()
        {
            // Arrange
            var clientDto = new ClientDto 
            { 
                FirstName = "Jovan", 
                LastName = "Tone",
                DateOfBirth = new DateTime(2004, 4, 28),
                Address = "Street 21, Temecula",
                MembershipCardNumber = "MC001",
                MembershipCardValidityDate = new DateTime(2024, 12, 31)
            };

            var client = new Client
            {
                FirstName = "Jovan",
                LastName = "Tone",
                DateOfBirth = new DateTime(2004, 4, 28),
                Address = "Street 21, Temecula",
                MembershipCardNumber = "MC001",
                MembershipCardValidityDate = new DateTime(2024, 12, 31)
            };

            var createdClient = new Client
            {
                Id = 1,
                FirstName = "Jovan",
                LastName = "Tone",
                DateOfBirth = new DateTime(2004, 4, 28),
                Address = "Street 21, Temecula",
                MembershipCardNumber = "MC001",
                MembershipCardValidityDate = new DateTime(2024, 12, 31)
            };

            var createdClientDto = new ClientDto
            {
                Id = 1,
                FirstName = "Jovan",
                LastName = "Tone",
                DateOfBirth = new DateTime(2004, 4, 28),
                Address = "Street 21, Temecula",
                MembershipCardNumber = "MC001",
                MembershipCardValidityDate = new DateTime(2024, 12, 31)
            };

            _mockMapper.Setup(mapper => mapper.Map<Client>(clientDto))
                .Returns(client);

            _mockClientRepository.Setup(repo => repo.CreateAsync(client))
                .ReturnsAsync(createdClient);

            _mockMapper.Setup(mapper => mapper.Map<ClientDto>(createdClient))
                .Returns(createdClientDto);

            // Act
            var result = await _clientService.CreateAsync(clientDto);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(1, result.Id);
            Assert.Equal("Jovan", result.FirstName);
            Assert.Equal("Tone", result.LastName);
        }
    }
} 