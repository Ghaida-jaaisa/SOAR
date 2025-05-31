using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;


namespace WebCourse_FinalProject.Models
{
    public class Course
    {
        // EF will instruct the database to automatically generate this value
        [Key]
        public int CourseId { get; set; }
        /*---------------------------------------------------------------------------------*/
        [Required(ErrorMessage = "Please enter Course name.")]
        public string CourseName { get; set; } = string.Empty;
        /*--------------------------------------------------------------------------------*/
        [Required(ErrorMessage = "Please enter a Duration.")]
        [Range(1,52, ErrorMessage = "Duaration Should be greater than 1 week & less than 52 weeks")]
        public int? Duration { get; set; }
        /*----------------------------------------------------------------------------------------*/
        [Required(ErrorMessage = "Please enter a Price.")]
        public int? Price { get; set; }
        /*---------------------------------------------------------------------------------------*/
        [Required(ErrorMessage = "Please Enter Company name .")]
        public string ComapnyName { get; set; } = string.Empty;
        /*---------------------------------------------------------------------------------------*/
        [Required(ErrorMessage = "Please Enter Location .")]
        public string Location { get; set; } = string.Empty;

        /*-----------------------------------------------------------------------------------*/
        [Required(ErrorMessage = "Please enter a Category.")]
        public int CategoryId { get; set; }
        /*----------------------------------------------------------------------------------------*/
        [ValidateNever]
        public Category category { get; set; } = null!;
    }
}
