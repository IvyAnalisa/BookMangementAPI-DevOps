using BookManagementAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private static List<Book> books = new List<Book>();
        private static int nextId = 1; // Auto-incrementing ID tracker

        // GET: api/books
        [HttpGet]
        public ActionResult<IEnumerable<Book>> GetAllBooks()
        {
            return Ok(books); // Return all books
        }

        // POST: api/books
        [HttpPost]
        public ActionResult<Book> CreateBook(Book book)
        {
            book.Id = nextId++; // Assign a new ID to the book
            books.Add(book); // Add the new book to the list
            return CreatedAtAction(nameof(GetAllBooks), new { id = book.Id }, book);
        }

        // PUT: api/books/{id}
        [HttpPut("{id}")]
        public ActionResult UpdateBook(int id, [FromBody] Book updatedBook)
        {
            if (updatedBook == null)
            {
                return BadRequest("Book is null."); // Return 400 if the updated book object is null
            }

            var existingBook = books.FirstOrDefault(b => b.Id == id);
            if (existingBook == null)
            {
                return NotFound(); // Return 404 if book is not found
            }

            // Update the properties of the existing book
            existingBook.Title = updatedBook.Title;
            existingBook.Author = updatedBook.Author;
            existingBook.Description = updatedBook.Description;
            existingBook.PublishedDate = updatedBook.PublishedDate;

            return NoContent(); // Return 204 No Content on successful update
        }

        // DELETE: api/books/{id}
        [HttpDelete("{id}")]
        public ActionResult DeleteBook(int id)
        {
            var existingBook = books.FirstOrDefault(b => b.Id == id);
            if (existingBook == null)
            {
                return NotFound(); // Return 404 if book is not found
            }

            books.Remove(existingBook); // Remove the book from the list
            return NoContent(); // Return 204 No Content on successful deletion
        }
    }
}
