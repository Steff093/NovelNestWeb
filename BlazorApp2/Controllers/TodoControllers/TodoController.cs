using BlazorApp2.Client.Models.TodosModel;
using BlazorApp2.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BlazorApp2.Controllers.TodoControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public TodoController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var todo = await _context.TodoModel.ToListAsync();
            return Ok(todo);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var todo = await _context.TodoModel.FirstOrDefaultAsync(a => a.TodoId == id);
            return Ok(todo);
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Post(TodoModel todo)
        {
            _context.Add(todo);
            await _context.SaveChangesAsync();
            return Ok(todo.TodoId);
        }

        [HttpPut]
        public async Task<IActionResult> Put(TodoModel todoModel)
        {
            _context.Entry(todoModel).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var todo = new TodoModel { TodoId = id };
            _context.Remove(todo);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
