using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UniversitySys.Models;
using UniversitySys.SystemContext;
using UniversitySys.ViewModel;

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
        public IActionResult Add()
        {
            var InstructorDeptCrsViewModel = new InstructorDeptCrsViewModel
            {
                DepartmentList = context.Departments.ToList(),
                CourseList = context.Courses.ToList()
            };
            return View("Add", InstructorDeptCrsViewModel);
        }
        public IActionResult SaveAdd(InstructorDeptCrsViewModel instructorDeptCrsViewModel)
        {
            //InstructorDeptCrsViewModel instructorDeptCrsViewModel
            //    = new InstructorDeptCrsViewModel();
            Instructor instructor = new Instructor();
            instructorDeptCrsViewModel.DepartmentList = context.Departments.ToList();
            instructorDeptCrsViewModel.CourseList = context.Courses.ToList();

            instructor.Id = instructorDeptCrsViewModel.Id;
            instructor.Name = instructorDeptCrsViewModel.Name;
            instructor.Image = instructorDeptCrsViewModel.Image;
            instructor.Salary = instructorDeptCrsViewModel.Salary;
            instructor.Address = instructorDeptCrsViewModel.Address;
            instructor.DepartmentId = instructorDeptCrsViewModel.DepartmentId;
            instructor.CourseId = instructorDeptCrsViewModel.CourseId;
            if (instructor.Name != null)
            {
                context.Instructors.Add(instructor);
                context.SaveChanges();
                return RedirectToAction("GetAllInstructors");
            }

            //DEPTList = instructorDeptCrsViewModel.DepartmentList;
            //CRSList = instructorDeptCrsViewModel.CourseList;
            return View("Add", instructorDeptCrsViewModel);
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
