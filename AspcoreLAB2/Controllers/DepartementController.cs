using AspcoreLAB2.Models;
using AspcoreLAB2.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace AspcoreLAB2.Controllers
{
    public class DepartementController : Controller
    {
        IDepartementRepository deptRepository;
        ICourseRepository courseRepository;//null
        //DI
        public DepartementController(ICourseRepository crsRepo, IDepartementRepository deptRepo)
        {
            deptRepository = deptRepo;
            courseRepository = crsRepo;
           
        }

        public IActionResult ShowDepts()
        {
            //onexecuting
            List<Department> depts = deptRepository.GetAll();
            //onexecuted
            return View(depts);
        }
        // Department/GetEmpByDept?deptId=1
        //public IActionResult GetEmpByDept(int deptId)
        //{
        //    List<Employee> Emps = empRepository.GetByDeptID(deptId);
        //    return Json(Emps);
        //}

        [Authorize(Roles = "Admin")]
        public IActionResult Index()
        {
            List<Department> DeptsModel = deptRepository.GetAll();
            return View(DeptsModel);//view name= Index, Model = List<Deprtment>
            //return View("Index", DeptsModel);
        }
        //[HttpGet]
        //default action handel request type (GET | POST)
        public IActionResult New()
        {
            return View();//view name = "New" ,Model  = null
        }

        //\DEpartment\save?Name=sd&ManagerName=ahmed
        // public IActionResult Save(string name,string ManagerName)
        [HttpPost]

        public IActionResult Save(Department dept)//dept==>request
        {
            //if(Request.Method=="Post")
            if (dept.Name != null)//validate
            {
                deptRepository.Add(dept);
                deptRepository.Save();
                //return View("Index",context.Department.ToList());//view =index ,Model=null
                return RedirectToAction("Index");
            }
            //ViewData["Error"]
            return View("New", dept);// view =New ,Model =department come from request

        }

        //action must be public
        //action cant be static
        //action cant be overload
        [HttpGet]
        public IActionResult Method1()
        {
            return Content("Method1");
        }

        [HttpPost]
        public IActionResult Method1(int id)
        {
            return Content("Method1_Overload");
        }




    }
}
