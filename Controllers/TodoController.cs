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
    [Route("api/")]
    [ApiController]
    public class TodoController : ControllerBase
    {
        private readonly TodoContext _context;
        private readonly ILogger<TodoController> _logger;

        public TodoController(TodoContext context, ILogger<TodoController> logger)
        {
            _context = context;
            _logger = logger;
        }

        // GET: api/todos
        [HttpGet("todos")]
        public async Task<ActionResult<IEnumerable<TodoModel>>> GetTodos()
        {
          if (_context.Todos == null)
          {
              return NotFound();
          }
            return await _context.Todos.ToListAsync();
        }

        // POST: api/addTodo
        [HttpPost("addTodo")]
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

        // PUT: api/updateTodo/5
        [HttpPut("updateTodo/{id}")]
        public async Task<ActionResult<TodoModel>> PutTodoModel(long id, TodoModel todoModel)
        {
            if (id != todoModel.id)
            {
                return BadRequest();
            }

            _context.Entry(todoModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
                return Ok(todoModel);
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

        }

        // DELETE: api/deleteTodo/5
        [HttpDelete("deleteTodo/{id}")]
        public async Task<ActionResult<object>> DeleteTodoModel(long id)
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

            try
            {
                _context.Todos.Remove(todoModel);
                await _context.SaveChangesAsync();
                return Ok(new { success = true, id = id });
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

        }

        private bool TodoModelExists(long id)
        {
            return (_context.Todos?.Any(e => e.id == id)).GetValueOrDefault();
        }
    }
}
