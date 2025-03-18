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
            try
            {
                var Instruct = context.Instructors
                    .Include(i => i.Department)
                    .Include(i => i.Course)
                    .ToList();
                return View("GetAllInstructors", Instruct);
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = "An error occurred: " + ex.Message;
                return View("ErrorPage");
            }

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

        [HttpPost]
        [ValidateAntiForgeryToken]
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
            if (ModelState.IsValid == true)
            {
                context.Instructors.Add(instructor);
                context.SaveChanges();
                return RedirectToAction("GetAllInstructors");
            }

            //DEPTList = instructorDeptCrsViewModel.DepartmentList;
            //CRSList = instructorDeptCrsViewModel.CourseList;
            return View("Add", instructorDeptCrsViewModel);
        }

        //public IActionResult Edit(int id)
        //{
        //    var instructor = context.Instructors.Include("Department").
        //        Include("Course").SingleOrDefault(i => i.Id == id);
        //    InstructorDeptCrsViewModel instructorDeptCrsViewModel
        //        = new InstructorDeptCrsViewModel();
        //    instructorDeptCrsViewModel.DepartmentList = context.Departments.ToList();
        //    instructorDeptCrsViewModel.CourseList = context.Courses.ToList();
        //    if (ModelState.IsValid==true)
        //    {
        //        //instructor.Id = instructorDeptCrsViewModel.Id;
        //        instructor.Name = instructorDeptCrsViewModel.Name;
        //        instructor.Image = instructorDeptCrsViewModel.Image;
        //        instructor.Salary = instructorDeptCrsViewModel.Salary;
        //        instructor.Address = instructorDeptCrsViewModel.Address;
        //        instructor.DepartmentId = instructorDeptCrsViewModel.DepartmentId;
        //        instructor.CourseId = instructorDeptCrsViewModel.CourseId;
        //        context.SaveChanges();
        //        return RedirectToAction("GetAllInstructors");
        //    }

        //    return View("Edit", instructor);
        //}
        //public IActionResult SaveEdit(int id, InstructorDeptCrsViewModel instructorDeptCrsViewModel)
        //{
        //    //InstructorDeptCrsViewModel instructorDeptCrsViewModel
        //    //    = new InstructorDeptCrsViewModel();
        //    Instructor instructor = new Instructor();
        //    instructorDeptCrsViewModel.DepartmentList = context.Departments.ToList();
        //    instructorDeptCrsViewModel.CourseList = context.Courses.ToList();

        //    instructor.Id = instructorDeptCrsViewModel.Id;
        //    instructor.Name = instructorDeptCrsViewModel.Name;
        //    instructor.Image = instructorDeptCrsViewModel.Image;
        //    instructor.Salary = instructorDeptCrsViewModel.Salary;
        //    instructor.Address = instructorDeptCrsViewModel.Address;
        //    instructor.DepartmentId = instructorDeptCrsViewModel.DepartmentId;
        //    instructor.CourseId = instructorDeptCrsViewModel.CourseId;
        //    if (instructor.Name != null)
        //    {
        //        context.Instructors.Add(instructor);
        //        context.SaveChanges();
        //        return RedirectToAction("GetAllInstructors");
        //    }

        //    //DEPTList = instructorDeptCrsViewModel.DepartmentList;
        //    //CRSList = instructorDeptCrsViewModel.CourseList;
        //    return View("Add", instructorDeptCrsViewModel);
        //}

        public IActionResult TestUnique(string name)
        {
            var student = context.Instructors.FirstOrDefault(i => i.Name == name);
            if (student == null)
            {
                return Json(true);
            }
            return Json(false);
        }


        [HttpGet]
        public IActionResult Search(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                ViewBag.Message = "Please enter a valid name";
                return View("Search", null);
            }

            name = name.Trim(); // Trim any leading or trailing white spaces

            var Instruct = context.Instructors
                .Include("Department")
                .Include("Course")
                .FirstOrDefault(I => I.Name.Trim() == name); // Trim in database comparison if needed

            if (Instruct == null)
            {
                ViewBag.Message = "Instructor not found";
                return View("Search", null);
            }

            return View("Search", Instruct);
        }



    }
}
