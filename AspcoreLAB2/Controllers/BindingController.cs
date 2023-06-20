using AspcoreLAB2.Models;
using Microsoft.AspNetCore.Mvc;

namespace AspcoreLAB2.Controllers
{
    public class BindingController : Controller
    {
       
        public IActionResult Primitive(int age, string name, int id, string[] color)
        {
            return Content("ok");
        }

        //Binding Collection Dic
        //binding/dic? name = christen & phone[ahmed] = 123 & phone[asmaa] = 456
        public IActionResult Dic(Dictionary<string, string> phone, string name)
        {
            return Content("ok");
        }

        //bind custom / Complex Type class
        //binding/testobj? id=10 & name=sd & managername=Hossam
        //binding/testobj? id = 10 & name = sd & employee[0].name = hassan
        public IActionResult testObj(Department dept, string name)
        {
            return Content("ok");
        }
    }
}
