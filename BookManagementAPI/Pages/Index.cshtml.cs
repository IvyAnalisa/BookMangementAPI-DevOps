using Microsoft.AspNetCore.Mvc.RazorPages;
using BookManagementAPI.Models; // Assuming this is where Book.cs is located
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Net.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Json;

namespace BookManagementAPI.Pages
{
    public class IndexModel : PageModel
    {
        private readonly HttpClient _httpClient;

        // Inject HttpClient in the constructor
        public IndexModel(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public List<Book> Books { get; set; } = new List<Book>();

        // Method to add a new book (used in the form submission)
        public async Task<IActionResult> OnPostAddBookAsync(string Title, string Author, string Description, DateTime PublishedDate)
        {
            var newBook = new Book
            {
                Title = Title,
                Author = Author,
                Description = Description,
                PublishedDate = PublishedDate
            };

            // Make a POST request to the API
            await _httpClient.PostAsJsonAsync("api/books", newBook);
            return RedirectToPage();
        }
    }
}

