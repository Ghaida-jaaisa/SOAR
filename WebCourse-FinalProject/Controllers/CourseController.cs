using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebCourse_FinalProject.Models;

namespace WebCourse_FinalProject.Controllers
{
    public class CourseController : Controller
    {

        private CourseContext context { get; set; }

        public CourseController(CourseContext ctx) => context = ctx;

        public IActionResult ShowCourses(int id)
        {
            if ((HttpContext.Session.GetInt32("Aid") != null) || (HttpContext.Session.GetInt32("Uid") != null)) {
                var courses = context.Course.Include(c => c.category).Where(c => c.CategoryId.Equals(id)).ToList();
                ViewBag.CategoryName = context.Category.Find(id).CategoryName;
                return View(courses); }
            else
                return RedirectToAction("Index" , "Home");
        }


        [HttpGet]
        public IActionResult Edit(int id)
        {
            if (HttpContext.Session.GetInt32("Aid") != null)
            {
                ViewBag.Categories = context.Category.OrderBy(c => c.CategoryName).ToList();
                var course = context.Course.Find(id);
                return View(course);
            }
            /* user with session */
            else if (HttpContext.Session.GetInt32("Uid") != null)
                return RedirectToAction("IndexLogin", "Home");
            /* user without sesssion */
            else
                return RedirectToAction("Index", "Home");
        }
        [HttpPost]
        public IActionResult Edit(Course course)

        {
            /* just for admin */
          if (HttpContext.Session.GetInt32("Aid") != null)
            {
                context.Course.Update(course);
                context.SaveChanges();
                return RedirectToAction("AdminCourses", "Course");
           }
            /* user with session */
              else if (HttpContext.Session.GetInt32("Uid") != null)
              return RedirectToAction("IndexLogin", "Home");
            /* user without sesssion */
                else
                return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            if (HttpContext.Session.GetInt32("Aid") != null)
            {
                var course = context.Course.Find(id);
                return View("Delete", course);
            }
            else if (HttpContext.Session.GetInt32("Uid") != null)
                return RedirectToAction("IndexLogin", "Home");
            else
                return RedirectToAction("Index", "Home");

        }


        [HttpPost]
        public IActionResult Delete(Course course)
        {
                context.Course.Remove(course);
                int category = course.CategoryId;
                context.SaveChanges();
                return RedirectToAction("AdminCourses", "Course");
         }
        public IActionResult AdminCourses(string key)

        {  /* Just Admin can access this page */
            if (HttpContext.Session.GetInt32("Aid") != null)

            {
                if (key == null)
                {
                    /* List of All Courses */
                    List<Course> courses = context.Course.Include(c => c.category).OrderBy(c => c.category.CategoryName).ToList();
                    return View(courses);

                }
                else
                {
                    List<Course> courses = context.Course.Include(c => c.category).Where(c => c.CourseName.Contains(key)).OrderBy(c => c.category.CategoryName).ToList();
                    return View(courses);

                }
            }

            /* Other person go to index login */
            else if (HttpContext.Session.GetInt32("Uid") != null)
                return RedirectToAction("IndexLogin", "Home");
            else
                return RedirectToAction("Index", "Home");

        }

        [HttpGet]
        public IActionResult Add()
        {
            if (HttpContext.Session.GetInt32("Aid") != null)
            {
                ViewBag.Categories = context.Category.OrderBy(c => c.CategoryName).ToList();
                return View();
            }
            else if (HttpContext.Session.GetInt32("Uid") != null)
                return RedirectToAction("IndexLogin", "Home");
            else
                return RedirectToAction("Index", "Home");

        }
        [HttpPost]
        public IActionResult Add(Course course)
        {
            context.Course.Add(course);
            context.SaveChanges();
            return RedirectToAction("AdminCourses", "Course");
        }

        [HttpGet]
        public IActionResult Search()
        {
        return View(); 
        }
    }
}