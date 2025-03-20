using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UniversitySys.Models;
using UniversitySys.SystemContext;
using UniversitySys.ViewModel;

namespace UniversitySys.Controllers
{
    public class TraineeController : Controller
    {
        UniversityContext context = new UniversityContext();
        [HttpGet]
        public IActionResult ShowREsult(int id, int crsid)
        {
            var trainee = context.CrsResults
                .Include(c => c.Trainee)
                .Include(c => c.Course)
                .FirstOrDefault(c => c.TraineeId == id && c.CourseId == crsid);

            if (trainee == null)
            {
                ModelState.AddModelError("", "No data found for the provided Trainee ID and Course ID.");
                return View();
            }

            TraineeCrsResultViewModel traCrsResultViewModel = new TraineeCrsResultViewModel
            {
                TraineeId = trainee.TraineeId,
                CourseId = trainee.CourseId,
                TraineeName = trainee.Trainee?.Name ?? "Unknown",
                CourseName = trainee.Course?.Name ?? "Unknown",
                TraineeDegree = trainee.Degree
            };

            if (trainee.Degree >= trainee.Course.MinDegree)
            {
                traCrsResultViewModel.Status = "Pass";
                traCrsResultViewModel.Color = "green";
            }
            else
            {
                traCrsResultViewModel.Status = "Fail";
                traCrsResultViewModel.Color = "red";
            }

            return View("ShowREsult", traCrsResultViewModel);
        }
    }
}
