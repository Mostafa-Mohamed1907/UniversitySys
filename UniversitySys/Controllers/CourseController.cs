using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UniversitySys.Models;
using UniversitySys.SystemContext;

namespace UniversitySys.Controllers
{
    public class CourseController : Controller
    {
        UniversityContext context = new UniversityContext();
        public IActionResult Index()
        {
            var course = context.Courses.Include("Department").ToList();
            return View("Index", course);
        }
        [HttpGet]
        public IActionResult Add()
        {
            ViewData["DeptList"] = context.Departments.ToList();
            return View("Add");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SaveAdd(Course course)
        {
            //if (!context.Departments.Any(d => d.Id == course.DepartmentId))
            //{
            //    ModelState.AddModelError("DepartmentId", "Selected Department does not exist.");
            //    // Ensure dropdown is populated again
            //    ViewData["DeptList"] = context.Departments.ToList();
            //    return View("Add", course);
            //}

            if (ModelState.IsValid == true)
            {
                if (course.DepartmentId != 0)
                {
                    context.Courses.Add(course);
                    context.SaveChanges();
                    return RedirectToAction("Index");
                }
                ModelState.AddModelError("DepartmentId", " Select Department ");
            }
            // Ensure dropdown is populated again
            ViewData["DeptList"] = context.Departments.ToList(); 
            return View("Add", course);
        }

        public IActionResult TestLessThanMinDegree(Course course)
        {
            if (course.MinDegree < course.Degree)
            {
                return Json(true);
            }
            return Json(false);
        }


    }
}
