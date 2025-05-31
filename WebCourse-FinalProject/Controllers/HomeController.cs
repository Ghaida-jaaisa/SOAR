using Microsoft.AspNetCore.Mvc;
using System;
using System.Diagnostics;
using WebCourse_FinalProject.Models;


namespace WebCourse_FinalProject.Controllers
{
    public class HomeController : Controller
    {
        private CourseContext context { get; set; }

        public HomeController(CourseContext ctx) => context = ctx;

        public IActionResult Index()
        {
            return View();
        }
       
        public IActionResult Register()
        {
            return View();
        }

      
        public IActionResult PlayVideo()
        {
            return View();
        }
        public IActionResult IndexLogin()
        {
            return View();  
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return View("Index", "Home");
        }
    }
}
