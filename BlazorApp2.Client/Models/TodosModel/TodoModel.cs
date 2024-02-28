using System.ComponentModel.DataAnnotations;

namespace BlazorApp2.Client.Models.TodosModel
{
    public class TodoModel
    {
        [Key]
        public int TodoId { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }

        public DateTime CreatedDate { get; set; } = DateTime.Now;

        public bool isCompleted { get; set; }

    }
}
