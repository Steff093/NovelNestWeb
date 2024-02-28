using BlazorApp2.Client.Models.BooksModel;
using BlazorApp2.Client.Models.TodosModel;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BlazorApp2.Data
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext<ApplicationUser>(options)
    {
        public DbSet<TodoModel> TodoModel { get; set; } = default!;
        public DbSet<BookModel> BookModel { get; set; } = default!;     
    }
}
