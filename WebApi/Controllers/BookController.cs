using Microsoft.AspNetCore.Mvc;
using Service.DTOs;
using Service.Interfaces;
using Swashbuckle.AspNetCore.Annotations;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [SwaggerTag("Manage library books")]
    public class BookController : ControllerBase
    {
        private readonly IBookService _bookService;

        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet]
        [SwaggerOperation(Summary = "Get all books", Description = "Retrieves all books from the library")]
        [SwaggerResponse(200, "Successfully retrieved all books")]
        public async Task<ActionResult<IEnumerable<BookDto>>> GetAll()
        {
            var books = await _bookService.GetAllAsync();
            return Ok(books);
        }

        [HttpGet("{id}")]
        [SwaggerOperation(Summary = "Get book by ID", Description = "Retrieves a specific book by its ID")]
        [SwaggerResponse(200, "Successfully retrieved the book")]
        [SwaggerResponse(404, "Book not found")]
        public async Task<ActionResult<BookDto>> GetById(int id)
        {
            var book = await _bookService.GetByIdAsync(id);
            if (book == null)
                return NotFound();

            return Ok(book);
        }

        [HttpPost]
        [SwaggerOperation(Summary = "Create a new book", Description = "Adds a new book to the library")]
        [SwaggerResponse(201, "Successfully created the book")]
        [SwaggerResponse(400, "Invalid input")]
        public async Task<ActionResult<BookDto>> Create([FromBody] BookDto bookDto)
        {
            var createdBook = await _bookService.CreateAsync(bookDto);
            return CreatedAtAction(nameof(GetById), new { id = createdBook.Id }, createdBook);
        }

        [HttpPut("{id}")]
        [SwaggerOperation(Summary = "Update a book", Description = "Updates an existing book's information")]
        [SwaggerResponse(200, "Successfully updated the book")]
        [SwaggerResponse(404, "Book not found")]
        [SwaggerResponse(400, "Invalid input")]
        public async Task<ActionResult<BookDto>> Update(int id, [FromBody] BookDto bookDto)
        {
            var updatedBook = await _bookService.UpdateAsync(id, bookDto);
            if (updatedBook == null)
                return NotFound();

            return Ok(updatedBook);
        }

        [HttpDelete("{id}")]
        [SwaggerOperation(Summary = "Delete a book", Description = "Removes a book from the library")]
        [SwaggerResponse(204, "Successfully deleted the book")]
        [SwaggerResponse(404, "Book not found")]
        public async Task<ActionResult> Delete(int id)
        {
            await _bookService.DeleteAsync(id);
            return NoContent();
        }
    }
} 