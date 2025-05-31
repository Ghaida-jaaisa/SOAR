using Microsoft.EntityFrameworkCore;


namespace WebCourse_FinalProject.Models;  

public class CourseContext : DbContext
{
    public CourseContext(DbContextOptions<CourseContext> options): base(options){ }

    public DbSet<Course> Course { get; set; } = null!;
    public DbSet<Category> Category { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>().HasData(
            new Category { CategoryId =  1 , CategoryName = "Art" },
            new Category { CategoryId = 2, CategoryName = "Computer" },
            new Category { CategoryId = 3, CategoryName = "Cooking" },
            new Category { CategoryId = 4, CategoryName = "Language" },
            new Category { CategoryId = 5, CategoryName = "Self-Development" },
            new Category { CategoryId = 6, CategoryName = "Sport" }
        );

        modelBuilder.Entity<Course>().HasData(
            new Course
            {
             CourseId = 1 ,
             CourseName = "HTML & CSS",
             CategoryId = 2 ,
             ComapnyName= "ASAL" , 
             Duration = 16 , 
             Location = "Nablus" , 
             Price = 2500 
            },
            new Course
            {
                CourseId = 2,
                CourseName = "Engineering Drawing",
                CategoryId = 1,
                ComapnyName = "AAUP",
                Duration = 16,
                Location = "Nablus",
                Price = 2500
            },
             new Course
             {
                 CourseId = 3,
                 CourseName = "BasketBall",
                 CategoryId = 6,
                 ComapnyName = "Fitness",
                 Duration = 16,
                 Location = "Nablus",
                 Price = 2500
             }
        );
    }
}