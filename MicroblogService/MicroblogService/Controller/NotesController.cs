using MicroblogService.Models;
using Microsoft.AspNetCore.Authorization;
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

        //[HttpGet("{hash}")]
        [Route("gethash{hash}")]
        public async Task<ActionResult<IEnumerable<Note>>> GetHash(string hash)
        {
            var notes = await _db.Notes.Where(x => x.Title.Contains(hash)).ToListAsync();
            //var selectedTeam = teams.Where(x => x.ToUpper().Contains('Б')).OrderBy(x => x);
            if (notes == null)
            {
                return NotFound();
            }
            return (notes);
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
        [Authorize(Roles = "admin,user")]
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
        [Authorize(Roles = "admin")]
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
