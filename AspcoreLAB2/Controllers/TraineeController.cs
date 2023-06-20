using AspcoreLAB2.Models;
using AspcoreLAB2.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AspcoreLAB2.Controllers
{
    public class TraineeController : Controller
    {
        ITIContext Context = new ITIContext();


        public IActionResult Index()
        {
            return View();
        }

     
        public IActionResult setSession()
        {
            HttpContext.Session.SetString("TraineeName", "mona");
            HttpContext.Session.SetString("CourseName", "OOP");
            HttpContext.Session.SetInt32("Grade", 90);

            return Content("Data Saved ");
        }

        public IActionResult getSession()
        {
            string _Name = HttpContext.Session.GetString("TraineeName");
            string _Course = HttpContext.Session.GetString("CourseName");
            int? _Grade = HttpContext.Session.GetInt32("Grade");

            return Content($"  Name = {_Name} \n  Course = {_Course} \n  Grade = {_Grade}");

        }

        public IActionResult setCookie()
        {
            CookieOptions options = new CookieOptions();
            options.Expires = DateTimeOffset.Now.AddDays(2);
            Response.Cookies.Append("Name", "Mona Hamdy" , options);
            Response.Cookies.Append("Age", "23");

            return Content("Cookie Saved");

        }

        public IActionResult getCookie()
        {

            string name = Request.Cookies["Name"];
            string age = Request.Cookies["Age"];


            return Content($"  Name = {name} \n  Age = {age} ");

        }
        public IActionResult getFromViewModel(int id, int Cid)
        {
          
            List<Trainee> Trainees = Context.Trainees.ToList();
            List<Course> Courses = Context.Courses.ToList();
            List<CursResult> results = Context.Results.ToList();

            var TraCrsRes = (from R in results
                             join C in Courses on R.CourseId equals C.Id
                             join T in Trainees on R.TraineeId equals T.Id
                             where C.Id == Cid & T.Id == id
                             select new
                             {
                                 Name = T.Name,
                                 CourseName = C.CourseName,
                                 Grade = T.Grade,
                                 MinDegree = C.MinDegree,
                                 Img = T.Img
                             }

                             ).FirstOrDefault();

            TraineeCourseCrsResultViewModel TSR = new TraineeCourseCrsResultViewModel();
            TSR.TraineeName = TraCrsRes.Name;
            TSR.CrsName = TraCrsRes.CourseName;
            TSR.TraineeGrade = TraCrsRes.Grade;
            TSR.TraineeImg = TraCrsRes.Img;


            if ((TSR.TraineeGrade >= TraCrsRes.MinDegree))
            {
                TSR.Color = "Green";
            }
            else
            {
                TSR.Color = "Red";
            }
            return View(TSR);

        }

        public IActionResult ShowCrsResult(int id) {
            List<Trainee> Trainees = Context.Trainees.ToList();
            List<Course> Courses = Context.Courses.ToList();
            List<CursResult> results = Context.Results.ToList();

            var TraCrsRes = (from R in results
                             join C in Courses on R.CourseId equals C.Id
                             join T in Trainees on R.TraineeId equals T.Id
                             where C.Id == id
                             select new
                             {
                                 Name = T.Name,
                                 Grade = T.Grade,
                                 MinDegree = C.MinDegree,
                             }).ToList();
            List<TraineeCourseCrsResultViewModel> TSR = new List<TraineeCourseCrsResultViewModel>();
            string color; 
            foreach (var i in TraCrsRes)
            {
                if ((i.Grade >= i.MinDegree))
                {
                    color = "green";
                }
                else
                {
                    color = "red";

                }
                TSR.Add(new TraineeCourseCrsResultViewModel()
                {
                    TraineeName = i.Name,
                    TraineeGrade = i.Grade,
                    MinGrade = i.MinDegree,
                    Color = color
                });; 
              
            }

          
            return View(TSR);
        }


        public IActionResult ShowTraineeResult(int id)
        {
            List<Trainee> Trainees = Context.Trainees.ToList();
            List<Course> Courses = Context.Courses.ToList();
            List<CursResult> results = Context.Results.ToList();

            var TraCrsRes = (from R in results
                             join C in Courses on R.CourseId equals C.Id
                             join T in Trainees on R.TraineeId equals T.Id
                             where T.Id == id
                             select new
                             {
                                 CourseName = C.CourseName,
                                 Grade = T.Grade,
                                 MinDegree = C.MinDegree,
                             }).ToList();
            List<TraineeCourseCrsResultViewModel> TSR = new List<TraineeCourseCrsResultViewModel>();
            string color;
            foreach (var i in TraCrsRes)
            {
                if ((i.Grade >= i.MinDegree))
                {
                    color = "green";
                }
                else
                {
                    color = "red";

                }
                TSR.Add(new TraineeCourseCrsResultViewModel()
                {
                    CrsName = i.CourseName,
                    TraineeGrade = i.Grade,
                    MinGrade = i.MinDegree,
                    Color = color
                }); ;

            }


            return View(TSR);
        }


    }
}
