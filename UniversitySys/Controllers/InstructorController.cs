using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UniversitySys.SystemContext;

namespace UniversitySys.Controllers
{
    public class InstructorController : Controller
    {
        UniversityContext context = new UniversityContext();
        public IActionResult GetAllInstructors()
        {
            var Instruct = context.Instructors.Include("Department").
                Include("Course").ToList();
            return View("GetAllInstructors", Instruct);
        }
        public IActionResult Details(int id)
        {
            var Instruct = context.Instructors.Include("Department").
                Include("Course").FirstOrDefault(I => I.Id == id);
            return View("Details", Instruct);
        }
        public IActionResult Search(string name)
        { 
            var Instruct = context.Instructors.Include("Department").
                Include("Course").FirstOrDefault(I => I.Name == name);
            if (Instruct != null)
            {
               return RedirectToAction ("Details", Instruct);
            }
            ViewBag.Message = "Instructor not found";
            return View("Search", null);
        }


    }
}
