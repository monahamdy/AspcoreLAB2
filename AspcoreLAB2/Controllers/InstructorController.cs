using AspcoreLAB2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AspcoreLAB2.Controllers
{
    public class InstructorController : Controller
    {
        ITIContext Context = new ITIContext();
     
        public IActionResult Index()
        {

            List<Instructor> Inst = Context.instructors.Include(e=>e.Department).Include(E=>E.Course).ToList();

            return View(Inst);
        }
        public IActionResult details(int id)
        {
           Instructor instructor= Context.instructors.Include(e => e.Department).Include(E => E.Course).FirstOrDefault(n => n.Id == id);
            return View(instructor);
        }


        [HttpGet]
        public IActionResult New()
        {
            List<Department> Depts = Context.Departments.ToList();
            ViewBag.Depts = Depts;
            List<Course> Crses = Context.Courses.ToList();
            ViewBag.Crses = Crses;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> New(Instructor instructor)
        {
            if (instructor != null)
            {
                Context.instructors.Add(instructor);
                Context.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return View(instructor);
            }

        }


        [HttpGet]
        public IActionResult Edit(int Id)
        {
           Instructor instructor = Context.instructors.SingleOrDefault(n => n.Id == Id);
            List<Department> Depts = Context.Departments.ToList();
            ViewBag.Depts = Depts;
            List<Course> courses = Context.Courses.ToList();
            ViewBag.courses = courses;
            return View(instructor);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Instructor instructor)
        {
            Instructor inst = Context.instructors.SingleOrDefault(x => x.Id == instructor.Id);
            inst.Name = instructor.Name;
            inst.Salary = instructor.Salary;
            inst.Address = instructor.Address;
            inst.Img = instructor.Img;
            inst.dept_id = instructor.dept_id;
            inst.crs_id = instructor.crs_id;

            Context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Search(string Name)
        {
            if (Name != "")
            {
                var insts = Context.instructors.Where(x => x.Name.ToLower().Contains(Name.ToLower())).ToList();
                return View("Index", insts);
            }
            else
            {
                var instructors = Context.instructors.ToList();

                return View("Index", instructors);
            }

        }

        public IActionResult Delete(int Id)
        {
            Instructor instructor = Context.instructors.SingleOrDefault(x => x.Id == Id);
            Context.instructors.Remove(instructor);
            Context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult GetCourseByDept(int deptid)
        {
           List<Course> courses = Context.Courses.Where(d => d.crs_id == deptid).ToList();
            return Json(courses);
        }
    }
}
