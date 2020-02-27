using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TodoTest.Data;
using TodoTest.Models;

namespace TodoTest.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class TaskController : ControllerBase
  {
    private readonly TodoTestContext _context;

    public TaskController(TodoTestContext context)
    {
      _context = context;
    }

    // GET: api/Task
    [HttpGet]
    public async System.Threading.Tasks.Task<ActionResult<IEnumerable<Task>>> GetTasks()
    {
      return await _context.Tasks.ToListAsync();
    }

    // GET: api/Task/5
    [HttpGet("{id}")]
    public async System.Threading.Tasks.Task<ActionResult<Task>> GetTask(int id)
    {
      var task = await _context.Tasks.FindAsync(id);

      if (task == null)
      {
        return NotFound();
      }

      return task;
    }

    // PUT: api/Task/5
    // To protect from overposting attacks, please enable the specific properties you want to bind to, for
    // more details see https://aka.ms/RazorPagesCRUD.
    [HttpPut("{id}")]
    public async System.Threading.Tasks.Task<IActionResult> PutTask(int id, Task task)
    {
      if (id != task.Id)
      {
        return BadRequest();
      }

      _context.Entry(task).State = EntityState.Modified;

      try
      {
        await _context.SaveChangesAsync();
      }
      catch (DbUpdateConcurrencyException)
      {
        if (!TaskExists(id))
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

    // POST: api/Task
    // To protect from overposting attacks, please enable the specific properties you want to bind to, for
    // more details see https://aka.ms/RazorPagesCRUD.
    [HttpPost]
    public async System.Threading.Tasks.Task<ActionResult<Task>> PostTask(Task task)
    {
      _context.Tasks.Add(task);
      await _context.SaveChangesAsync();

      return CreatedAtAction("GetTask", new { id = task.Id }, task);
    }

    // DELETE: api/Task/5
    [HttpDelete("{id}")]
    public async System.Threading.Tasks.Task<ActionResult<Task>> DeleteTask(int id)
    {
      var task = await _context.Tasks.FindAsync(id);
      if (task == null)
      {
        return NotFound();
      }

      _context.Tasks.Remove(task);
      await _context.SaveChangesAsync();

      return task;
    }

    private bool TaskExists(int id)
    {
      return _context.Tasks.Any(e => e.Id == id);
    }
  }
}
