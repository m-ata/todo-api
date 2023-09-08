using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TodoApi.Models;

namespace TodoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoController : ControllerBase
    {
        private readonly TodoContext _context;

        public TodoController(TodoContext context)
        {
            _context = context;
        }

        // GET: api/Todo
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TodoModel>>> GetTodos()
        {
          if (_context.Todos == null)
          {
              return NotFound();
          }
            return await _context.Todos.ToListAsync();
        }

        // GET: api/Todo/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TodoModel>> GetTodoModel(long id)
        {
          if (_context.Todos == null)
          {
              return NotFound();
          }
            var todoModel = await _context.Todos.FindAsync(id);

            if (todoModel == null)
            {
                return NotFound();
            }

            return todoModel;
        }

        // PUT: api/Todo/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTodoModel(long id, TodoModel todoModel)
        {
            if (id != todoModel.id)
            {
                return BadRequest();
            }

            _context.Entry(todoModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TodoModelExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Todo
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TodoModel>> PostTodoModel(TodoModel todoModel)
        {
          if (_context.Todos == null)
          {
              return Problem("Entity set 'TodoContext.Todos'  is null.");
          }
            _context.Todos.Add(todoModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTodoModel", new { id = todoModel.id }, todoModel);
        }

        // DELETE: api/Todo/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTodoModel(long id)
        {
            if (_context.Todos == null)
            {
                return NotFound();
            }
            var todoModel = await _context.Todos.FindAsync(id);
            if (todoModel == null)
            {
                return NotFound();
            }

            _context.Todos.Remove(todoModel);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TodoModelExists(long id)
        {
            return (_context.Todos?.Any(e => e.id == id)).GetValueOrDefault();
        }
    }
}
