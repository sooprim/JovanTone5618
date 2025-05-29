using Service.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Service.Interfaces
{
    public interface IBookService
    {
        Task<IEnumerable<BookDto>> GetAllAsync();
        Task<BookDto> GetByIdAsync(int id);
        Task<BookDto> CreateAsync(BookDto bookDto);
        Task<BookDto> UpdateAsync(int id, BookDto bookDto);
        Task DeleteAsync(int id);
    }
} 