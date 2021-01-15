using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MicroblogService.Models
{
    public class NotesContext : DbContext
    {
        public DbSet<Note> Notes { get; set; }
        public NotesContext(DbContextOptions<NotesContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Note>().
                HasData(
                new Note {Id = 1,  Title = "First test note", Description = "It is first test note in DB", UserId = 1 },
                new Note {Id = 2,  Title = "Second test note", Description = "It is second test note in DB", UserId = 1 }
                );
        }
    }
}
