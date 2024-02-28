using System.ComponentModel.DataAnnotations;

namespace BlazorApp2.Client.Models.BooksModel
{
    public class BookModel
    {
        [Key]
        public int BookId { get; set; }

        [Required]
        [MaxLength(100)]
        public string BookTitle { get; set; } = string.Empty;

        [Required]
        [MaxLength(100)]
        public string BookDescription { get; set; }

        [Required]
        [MaxLength(50)]
        public string BookAuthor { get; set; }

        public DateTime BookDate { get; set; } = DateTime.Now;
    }
}
