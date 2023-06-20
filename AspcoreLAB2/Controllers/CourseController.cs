using AspcoreLAB2.Models;
using AspcoreLAB2.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.FlowAnalysis.DataFlow;
using Microsoft.EntityFrameworkCore;

namespace AspcoreLAB2.Controllers
{
    public class CourseController : Controller
    {
       ITIContext Context=new ITIContext();
       ICourseRepository courseRepository;

        IDepartementRepository departementRepository;
       //DIP
        public CourseController(ICourseRepository crsRepo, IDepartementRepository deptRepo)  //injection
        {
            courseRepository = crsRepo;
            departementRepository = deptRepo;
            //courseRepository = new CourseRepository();
            //departementRepository = new DepartementRepository();
        }
       

        [HttpGet]
        public IActionResult Index()
        {
            List<Course> crsmodel =//courseRepository.GetAll();
                                   Context.Courses.Include(n => n.Department).ToList();
            return View(crsmodel);


        }

        public JsonResult CheckMinDegree(int minDegree, int degree)
        {
            if (minDegree < degree)
            {
                return Json(true);
            }

            return Json("Minimum degree must be less than degree.");
        }

        [HttpGet]
        public IActionResult New()
        {
            

            List<Course> crs= courseRepository.GetAll();
            //Context.Courses.ToList();
            ViewData["DeptList"] =//   
               Context.Departments.ToList();
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> New(Course course) {
            //if (course != null)
            if (ModelState.IsValid == true)
            {
                courseRepository.Add(course);
               
                //Context.Courses.Add(course);
                courseRepository.Save();
                return RedirectToAction("Index");
            }
            else
            {
                ViewData["DeptList"] = //departementRepository.GetAll();       
                Context.Departments.ToList();

                return View(course);
            }

        }
        [HttpGet]
        public IActionResult Edit(int Id)
        {
            Course course = courseRepository.GetBYId(Id);
            //Context.Courses.SingleOrDefault(n => n.Id == Id);
            List<Department> Depts = departementRepository.GetAll();
                                     //Context.Departments.ToList();
            ViewBag.Depts = Depts;
            List<Course> Crses = courseRepository.GetAll();
                //Context.Courses.ToList();
            ViewBag.Crses = Crses;
            return View(course);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Course course,int id)
        {
            if (ModelState.IsValid == true)
            {
                courseRepository.Update( id,course);
                // Course crs =   
                //Context.Courses.SingleOrDefault(x => x.Id == course.Id);

                // //crs.CourseName = course.CourseName;
                // //crs.Degree = course.Degree;
                // //crs.MinDegree = course.MinDegree;
                // //crs.crs_id = course.crs_id;
                // //crs.dept_id = course.dept_id;
                // Context.SaveChanges();
                courseRepository.Save();
                return RedirectToAction("Index");
            }
            List<Department> Depts = departementRepository.GetAll();
                                     //Context.Departments.ToList();
            ViewBag.Depts = Depts;
            return View(course);
        }
        public IActionResult Delete(int Id)
        {
            Course course =courseRepository.GetBYId(Id);
            //Context.Courses.SingleOrDefault(x => x.Id == Id);
            // Context.Courses.Remove(course);
            courseRepository.Delete(Id);
            courseRepository.Save();
            return RedirectToAction("Index");
        }
    }
}
