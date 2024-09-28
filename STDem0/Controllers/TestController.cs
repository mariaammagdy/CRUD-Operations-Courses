using Microsoft.AspNetCore.Mvc;

namespace STDem0.Controllers
{
    public class TestController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public ViewResult show()
        {
            //naming conv 
            return View();
        }
        public string Display()
        {
            return "hello from first mvc app";
        }
        public int add(int x, int y, string name)
        {
            //  int x = int.Parse(Request.Query["x"]);
            //  int y = int.Parse(Request.Query["y"]);
            return x + y;
        }
        public IActionResult AddName()
        {
            int id = 3;
            string name = "mariam";
            Response.Cookies.Append("id" , id.ToString(),new CookieOptions() { Expires=DateTime.Now.AddMinutes(1)});
            Response.Cookies.Append("fname", name);
            return View();
        }
        public IActionResult GetName()
        {
            int id = int.Parse(Request.Cookies["id"]);
            string name = Request.Cookies["fname"];
           // Response.Cookies.Delete("id");
            return Content($"{id} : {name}");

        }
        public IActionResult GetName2()
        {
            int id = int.Parse(Request.Cookies["id"]);
            string name = Request.Cookies["fname"];
            return Content($"{id} : {name}");

        }
        public IActionResult AddId()
        {
            int id = 3;
            string name = "mariam";
            HttpContext.Session.SetInt32("id", id);
            HttpContext.Session.SetString("name", name);
            return View();
               
        }
        public IActionResult GetId()
        {
            int id = HttpContext.Session.GetInt32("id") ?? 0;
            string name = HttpContext.Session.GetString("name");

            HttpContext.Session.Remove("id");
            return Content($"{id} : {name}");


        }
    }
}
