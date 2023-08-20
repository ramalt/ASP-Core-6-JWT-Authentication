using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TodoAPI.Data;
using TodoAPI.Dtos.Todo;
using TodoAPI.Models;

namespace TodoAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TodoController : ControllerBase
{
    private readonly ApiDbContext _context;

    public TodoController(ApiDbContext dbContext)
    {
        _context = dbContext;
    }
    [HttpGet]
    public async Task<IActionResult> GetTodos()
    {
        List<Todo> todos = await _context.Todos.ToListAsync();

        return Ok(todos);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetTodoById(int id)
    {
        Todo todo = await _context.Todos.FirstOrDefaultAsync(t => t.Id == id);
        if (!todo.Equals(null))
        {
            return Ok(todo);
        }

        return NotFound();
    }

    [HttpPost]
    public async Task<IActionResult> AddTodo(CreateTodoDTO todo)
    {
        if (!todo.Equals(null))
        {
            Todo newTodo = new Todo()
            {
                Title = todo.Title,
                Description = todo.Description,
                IsDone = false
            };
            await _context.Todos.AddAsync(newTodo);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTodoById", new { newTodo.Id }, todo);
        }

        return new JsonResult("Something went wrong") { StatusCode = 500 };
    }

    [HttpPut]
    public async Task<IActionResult> UpdateTodo(int id, UpdateTodoDTO todo)
    {
        Todo existingTodo = await _context.Todos.FirstOrDefaultAsync(t => t.Id == id);

        if (existingTodo.Equals(null)) throw new ArgumentException($"Todo with ID: {id} not found");

        if (ModelState.IsValid)
        {
            existingTodo.Title = todo.Title;
            existingTodo.Description = todo.Description;
            existingTodo.IsDone = todo.IsDone;

            await _context.SaveChangesAsync();

            return Ok(existingTodo);
        }

        return new JsonResult("Something went wrong") { StatusCode = 500 };

    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteTodo(int id)
    {
        Todo existingTodo = await _context.Todos.FirstOrDefaultAsync(t => t.Id == id);

        if (existingTodo.Equals(null)) throw new ArgumentException($"Todo with ID: {id} not found");

        if (ModelState.IsValid)
        {
            _context.Remove(existingTodo);
            await _context.SaveChangesAsync();

            return Ok(existingTodo);
        }
        return new JsonResult("Something went wrong") { StatusCode = 500 };

    }
}
