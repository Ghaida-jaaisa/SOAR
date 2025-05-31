using Microsoft.EntityFrameworkCore;

namespace WebCourse_FinalProject.Models
{
    public class PersonContext : DbContext
    {
        public PersonContext(DbContextOptions<PersonContext> options) : base(options) { }

        public DbSet<Person> Persons { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //  initial data
            modelBuilder.Entity<Person>().HasData(
                new Person
                {
                    PersonId = 1,
                    FirstName = "yara",
                    LastName = "rabaya",
                    Admin = true,
                    Password = "202110451",
                    Email = "admin1@gmail.com",
                    Location = "jenin"
                },
                new Person
                {
                    PersonId = 2,
                    FirstName = "ghaida",
                    LastName = "Admin",
                    Admin = true,
                    Password = "202110568",
                    Email = "admin2@gmail.com",
                    Location = "jenin"
                }

            );

            modelBuilder.Entity<Person>()
           .HasIndex(p => p.Email)
           .IsUnique();
        }
    }
}
