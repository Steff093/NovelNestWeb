using System.ComponentModel.DataAnnotations;

namespace BlazorApp2.Models
{
    public class TodoModel
    {
        [Key]
        public int TodoId { get; set; }

        [Required]
        public string Title { get; set; } = string.Empty;

        [Required]
        public string Description { get; set; } = string.Empty;

        public DateTime CreatedDate { get; set; } = DateTime.Now;

        public bool isCompleted { get; set; } = false;

    }
}
