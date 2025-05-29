using AutoMapper;
using Data.Entities;
using Data.Interfaces;
using Moq;
using Service.DTOs;
using Service.Services;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Tests.Unit
{
    public class BookServiceTests
    {
        private readonly Mock<IBookRepository> _mockBookRepository;
        private readonly Mock<IMapper> _mockMapper;
        private readonly BookService _bookService;

        public BookServiceTests()
        {
            _mockBookRepository = new Mock<IBookRepository>();
            _mockMapper = new Mock<IMapper>();
            _bookService = new BookService(_mockBookRepository.Object, _mockMapper.Object);
        }

        [Fact]
        public async Task GetAllAsync_ShouldReturnAllBooks()
        {
            // Arrange
            var books = new List<Book>
            {
                new Book { Id = 1, Name = "Book 1" },
                new Book { Id = 2, Name = "Book 2" }
            };

            var bookDtos = new List<BookDto>
            {
                new BookDto { Id = 1, Name = "Book 1" },
                new BookDto { Id = 2, Name = "Book 2" }
            };

            _mockBookRepository.Setup(repo => repo.GetAllAsync())
                .ReturnsAsync(books);

            _mockMapper.Setup(mapper => mapper.Map<IEnumerable<BookDto>>(books))
                .Returns(bookDtos);

            // Act
            var result = await _bookService.GetAllAsync();

            // Assert
            Assert.Equal(2, result.Count());
            _mockBookRepository.Verify(repo => repo.GetAllAsync(), Times.Once);
        }

        [Fact]
        public async Task GetByIdAsync_ShouldReturnBook_WhenBookExists()
        {
            // Arrange
            var book = new Book { Id = 1, Name = "Test Book" };
            var bookDto = new BookDto { Id = 1, Name = "Test Book" };

            _mockBookRepository.Setup(repo => repo.GetByIdAsync(1))
                .ReturnsAsync(book);

            _mockMapper.Setup(mapper => mapper.Map<BookDto>(book))
                .Returns(bookDto);

            // Act
            var result = await _bookService.GetByIdAsync(1);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(bookDto.Id, result.Id);
            Assert.Equal(bookDto.Name, result.Name);
        }

        [Fact]
        public async Task CreateAsync_ShouldReturnCreatedBook()
        {
            // Arrange
            var bookDto = new BookDto { Name = "New Book" };
            var book = new Book { Name = "New Book" };
            var createdBook = new Book { Id = 1, Name = "New Book" };
            var createdBookDto = new BookDto { Id = 1, Name = "New Book" };

            _mockMapper.Setup(mapper => mapper.Map<Book>(bookDto))
                .Returns(book);

            _mockBookRepository.Setup(repo => repo.CreateAsync(book))
                .ReturnsAsync(createdBook);

            _mockMapper.Setup(mapper => mapper.Map<BookDto>(createdBook))
                .Returns(createdBookDto);

            // Act
            var result = await _bookService.CreateAsync(bookDto);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(1, result.Id);
            Assert.Equal("New Book", result.Name);
        }
    }
} 