using System.ComponentModel.DataAnnotations;

namespace BookManagementAPI.Models
{
    public class Book
    {
        [Key]
        public int Id { get; set; } // Unique identifier for the book

        [Required]
        [StringLength(100)]
        public string Title { get; set; } // Title of the book

        [Required]
        [StringLength(100)]
        public string Author { get; set; } // Author of the book

        [StringLength(500)]
        public string Description { get; set; } // Optional description

        public DateTime PublishedDate { get; set; } // Published date
    }
}
