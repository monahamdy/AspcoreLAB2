using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AspcoreLAB2.Controllers
{
    [Authorize]//befor 402
    [HandelError]//filter
    public class FilterController : Controller
    {
        public IActionResult Index()
        {
            throw new Exception("Some Exception happen");
            return View();
        }

        [AllowAnonymous]
        public IActionResult Index2()
        {
            throw new Exception("Some Exception happen");
            return View();
        }

        [MyAction]
        public IActionResult testAction(int age, string name)
        {
            return Content("OK");
        }
    }
}

    
