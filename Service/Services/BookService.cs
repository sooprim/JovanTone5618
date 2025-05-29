using AutoMapper;
using Data.Entities;
using Data.Interfaces;
using Service.DTOs;
using Service.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Service.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;
        private readonly IMapper _mapper;

        public BookService(IBookRepository bookRepository, IMapper mapper)
        {
            _bookRepository = bookRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<BookDto>> GetAllAsync()
        {
            var books = await _bookRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<BookDto>>(books);
        }

        public async Task<BookDto> GetByIdAsync(int id)
        {
            var book = await _bookRepository.GetByIdAsync(id);
            return _mapper.Map<BookDto>(book);
        }

        public async Task<BookDto> CreateAsync(BookDto bookDto)
        {
            var book = _mapper.Map<Book>(bookDto);
            var createdBook = await _bookRepository.CreateAsync(book);
            return _mapper.Map<BookDto>(createdBook);
        }

        public async Task<BookDto> UpdateAsync(int id, BookDto bookDto)
        {
            var book = _mapper.Map<Book>(bookDto);
            book.Id = id;
            var updatedBook = await _bookRepository.UpdateAsync(book);
            return _mapper.Map<BookDto>(updatedBook);
        }

        public async Task DeleteAsync(int id)
        {
            await _bookRepository.DeleteAsync(id);
        }
    }
} 