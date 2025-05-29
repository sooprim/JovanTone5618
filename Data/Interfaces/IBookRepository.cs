using Data.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Data.Interfaces
{
    public interface IBookRepository
    {
        Task<IEnumerable<Book>> GetAllAsync();
        Task<Book> GetByIdAsync(int id);
        Task<Book> CreateAsync(Book book);
        Task<Book> UpdateAsync(Book book);
        Task DeleteAsync(int id);
    }
} 