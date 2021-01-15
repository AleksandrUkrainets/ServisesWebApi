using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TokenIssuerService.Models
{
    public class PersonsContext : DbContext
    {
        public DbSet<Person> Persons { get; set; }
        public PersonsContext(DbContextOptions<PersonsContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Person>().
                HasData(
                new Person { Id = 1, Login = "admin@gmail.com", Password = "12345", Role = "admin" },
                new Person { Id = 2, Login = "qwerty@gmail.com", Password = "55555", Role = "user" }
                );
        }
    }
}
