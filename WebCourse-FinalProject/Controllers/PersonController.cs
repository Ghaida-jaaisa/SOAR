using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.Eventing.Reader;
using WebCourse_FinalProject.Models;


namespace WebCourse_FinalProject.Controllers
{
    public class PersonController : Controller
    {
       
        private PersonContext _context { get; set; }

        public PersonController(PersonContext ctx) => _context = ctx;


        /*
        [HttpGet]
        public IActionResult AddPerson()
        {
            if (HttpContext.Session.GetInt32("Aid") != null)
                return RedirectToAction("UserAdd", "Person");
            else if (HttpContext.Session.GetInt32("Uid") != null)
                return RedirectToAction("IndexLogin", "Home");
            else return RedirectToAction("Register", "Home");
        }
        */


        [HttpPost]
        public IActionResult AddPerson(Person person)
        {
            if (person != null)
            {
                _context.Persons.Add(person);
                _context.SaveChanges();
                /* HttpContext.Session.SetInt32("Uid", person.PersonId); */
                if (HttpContext.Session.GetInt32("Aid") != null)
                return RedirectToAction("AdminUser", "Person");
                else return RedirectToAction("Login", "Person");

            }
            else
            {
                return RedirectToAction("Register", "Home");
            }
            
        }
        [HttpGet]
        public IActionResult Login()
        {
            /* Admin */ 
            if (HttpContext.Session.GetInt32("Aid") != null)
            return RedirectToAction("AdminView", "Person");
            /* User With session */ 
            else if (HttpContext.Session.GetInt32("Uid") != null)
            return RedirectToAction("IndexLogin", "Home");
            /* User Without session */                                                                                                                                                                                                                                                                                                                                                                                                                                                                  
            return View();
        }
        

        [HttpPost]
        public IActionResult Login(string mail, string pass)
        {
            Person person = _context.Persons.Where(p => p.Email == mail && p.Password == pass).FirstOrDefault();
            if (person != null)
            {
                if (person.PersonId == 1 || person.PersonId == 2 || person.Admin == true)
                {
                    HttpContext.Session.SetInt32("Aid", person.PersonId);
                    return RedirectToAction("AdminView", "Person");
                }

                else
                {
                    HttpContext.Session.SetInt32("Uid", person.PersonId);
                    return RedirectToAction("IndexLogin", "Home");
                }
            }
            return View();
        }

            public IActionResult AdminView() {
            /* Just Admin can access this page */ 
            if (HttpContext.Session.GetInt32("Aid") != null)
            return View();
            /* Other person go to index login */ 
            else if(HttpContext.Session.GetInt32("Uid") != null)
            return RedirectToAction("IndexLogin", "Home");
            else
            return RedirectToAction("Login", "Person");
        }

        public IActionResult UserInfo()

        {
            if (HttpContext.Session.GetInt32("Uid") != null)
            {
                int person_id = (int)HttpContext.Session.GetInt32("Uid");
                Person p = _context.Persons.Where(p => p.PersonId == person_id).FirstOrDefault();
                return View(p);
            }
            else if (HttpContext.Session.GetInt32("Aid") != null)
            {
                int person_id_admin = (int)HttpContext.Session.GetInt32("Aid");
                Person pA = _context.Persons.Where(p => p.PersonId == person_id_admin).FirstOrDefault();
                return View(pA);
            }
            else
            return RedirectToAction("Login", "Person");

        }

        
        public IActionResult AdminUser()
        {
            /* Just Admin can access this page */
            if (HttpContext.Session.GetInt32("Aid") != null)

            {    /* List of All Courses */
                List<Person> persons = _context.Persons.OrderBy(p => p.PersonId).ToList();
                return View(persons);
            }
            /* user with sesion */ 
             else if (HttpContext.Session.GetInt32("Uid") != null)
             return RedirectToAction("IndexLogin", "Home");

            /* Other person go to index login */
            else
            return RedirectToAction("Login", "Person");
        }


        [HttpGet]
        public IActionResult UserDelete(int id)
        {
            if (HttpContext.Session.GetInt32("Aid") != null)
            {
                var person = _context.Persons.Find(id);
                return View(person);
            }
            else if (HttpContext.Session.GetInt32("Uid") != null)
                return RedirectToAction("IndexLogin", "Home");
            else
                return RedirectToAction("Index", "Home");

        }


        [HttpPost]
        public IActionResult UserDelete(Person person)
        {
                _context.Persons.Remove(person);
                _context.SaveChanges();
                return RedirectToAction("AdminUser", "Person");
            
        }


        [HttpGet]
        public IActionResult UserEdit(int id)
        {
            if (HttpContext.Session.GetInt32("Aid") != null)
            {
                var person = _context.Persons.Find(id);
                return View(person);
            }
            /* user with session */
            else if (HttpContext.Session.GetInt32("Uid") != null)
                return RedirectToAction("IndexLogin", "Home");
            /* user without sesssion */
            else
                return RedirectToAction("Index", "Home");
        }
        [HttpPost]
        public IActionResult UserEdit(Person person)

        {
            /* just for admin */
                _context.Persons.Update(person);
                _context.SaveChanges();
                return RedirectToAction("AdminUser", "Person");
          
        }
        [HttpGet]
        public IActionResult UserAdd()
        {

            if (HttpContext.Session.GetInt32("Aid") != null)
            {
                return View();
            }
            /* user with session */
            else if (HttpContext.Session.GetInt32("Uid") != null)
                return RedirectToAction("IndexLogin", "Home");
            /* user without sesssion */
            else
                return RedirectToAction("Index", "Home");
        }

    }    

}

