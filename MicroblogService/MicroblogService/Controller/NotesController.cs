using MicroblogService.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MicroblogService.Controller
{

    [Route("api/[controller]")]
    [ApiController]
    public class NotesController : ControllerBase
    {
        readonly NotesContext _db;

        public NotesController(NotesContext db)
        {
            _db = db;
        }

        // GET: api/<ValuesController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Note>>> Get()
        {
            return await _db.Notes.ToListAsync();
        }

        // GET api/<ValuesController>/5
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

        // POST api/<ValuesController>
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

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
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

        // DELETE api/<ValuesController>/5
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
