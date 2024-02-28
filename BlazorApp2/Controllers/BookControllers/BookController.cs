using BlazorApp2.Client.Models.BooksModel;
using BlazorApp2.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BlazorApp2.Controllers.BookControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {

        private readonly ApplicationDbContext _context;

        public BookController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var todo = await _context.BookModel.ToListAsync();
            return Ok(todo);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var todo = await _context.BookModel.FirstOrDefaultAsync(b => b.BookId == id);
            return Ok(todo);
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Post(BookModel bookModel)
        {
            _context.Add(bookModel);
            await _context.SaveChangesAsync();
            return Ok(bookModel.BookId);
        }

        [HttpPut]
        public async Task<IActionResult> Put(BookModel bookModel)
        {
            _context.Entry(bookModel).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBook(int id)
        {
            var book = new BookModel { BookId = id};
            _context.Remove(book);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
