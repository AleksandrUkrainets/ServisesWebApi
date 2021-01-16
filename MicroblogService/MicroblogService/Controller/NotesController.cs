using MicroblogService.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MicroblogService.Controller
{

    [Route("api/[controller]")]
    [ApiController]
    [EnableCors]
    public class NotesController : ControllerBase
    {
        readonly NotesContext _db;

        public NotesController(NotesContext db)
        {
            _db = db;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Note>>> Get()
        {
            return await _db.Notes.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Note>> Get(int id)
        {
            Note note = await _db.Notes.FirstOrDefaultAsync(x => x.Id == id);
            if (note == null)
            {
                return NotFound();
            }
            return new ObjectResult(note);
        }

        [HttpPost]
        public async Task<ActionResult<Note>> Post(Note note)
        {
            if (note == null)
            {
                return BadRequest();
            }

            _db.Notes.Add(note);
            await _db.SaveChangesAsync();
            return Ok(note);
        }

        [HttpPut]
        public async Task<ActionResult<Note>> Put(Note note)
        {
            if (note == null)
            {
                return BadRequest();
            }
            if (!_db.Notes.Any(x => x.Id == note.Id))
            {
                return NotFound();
            }

            _db.Update(note);
            await _db.SaveChangesAsync();
            return Ok(note);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Note>> Delete(int id)
        {
            Note note = _db.Notes.FirstOrDefault(x => x.Id == id);
            if (note == null)
            {
                return NotFound();
            }
            _db.Notes.Remove(note);
            await _db.SaveChangesAsync();
            return Ok(note);
        }
    }
}
