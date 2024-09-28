using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using STDem0.Models;
using STDem0.Repository;

namespace STDem0.Controllers
{
    [Authorize]
    public class DepartmentController : Controller
    {
        // ITIContext db = new ITIContext();
        IDepartmentRepo deptRep; //= new DepartmentRepo();
                                 //get or route
        public DepartmentController(IDepartmentRepo _deptrepo)
        {
            deptRep = _deptrepo;
        }
        public IActionResult Create()
        {
            return View();
        }
        // public string Create(/*[FromQuery]*/ int id , int deptid , string name , int capacity) //model binder
        [HttpPost]
        public IActionResult Create(Department dept) //model binder
        {
            // Request.Form["deptid"]  // method is post (more secure)
            // Request.RouteValues["id"]
            // Request.Query["deptid"]  // method is get

            /*  Department dept = new Department()
              {
                  DeptId = deptid ,
                  DeptName = name ,
                  Capacity = capacity,
              };*/
            deptRep.Add(dept);
            //db.Departments.Add(dept);
            //db.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Details(int? id)
        {
            if (id == null)
                return BadRequest(); //200
                                     // Department dept = db.Departments.SingleOrDefault(a=>a.DeptId== id);
            Department dept = deptRep.GetById(id.Value);
            if (dept == null)
                return NotFound();  //404
            return View(dept);
            // ViewData["department"]=dept;

            /* ViewData["x"] = 30;  //object
             ViewData["y"] = 50;
             ViewBag.z = 900;
             Student std = new Student()
             {
                 Name = "ali",
                 Age = 25,
             };
             DetailsViewModel model = new DetailsViewModel()
             {
                 Student=std,Department=dept
             };*/
            //string str=$"{dept.DeptId } : {dept.DeptName} : {dept.Capacity}";
            //return Content(str);   //text plain
            // Json(dept);   //json
            // return File("names.txt" , "text/plain" ,"mariam.txt");  //file
            // return Redirect("http://www.google.com"); //details->google || status code 302
            //return RedirectPermanent("http://www.google.com");   //direct to google || status code 301

        }
        public IActionResult Delete(int id)
        {
            var dept = deptRep.GetById(id);
            //var dept = db.Departments.SingleOrDefault(a=>a.DeptId== id);
            // db.Departments.Remove(dept);
            //db.SaveChanges();
            return View(dept);
        }
        [HttpPost, ActionName("delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            deptRep.DeleteById(id);
            //var dept = db.Departments.SingleOrDefault(a => a.DeptId == id);
            //db.Departments.Remove(dept);
            //db.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Update(int id)
        {
            Department dept = deptRep.GetById(id);
            // Department dept = db.Departments.Find(id);
            return View(dept);
        }
        [HttpPost]
        public IActionResult Update(Department dept)
        {
            deptRep.Update(dept);
            /* if (!ModelState.IsValid)
             {
                 return View(dept);
             }

             var dep = db.Departments.Find(dept.DeptId);
             if (dep == null)
             {
                 return NotFound();
             }

             dep.DeptName = dept.DeptName;
             dep.Capacity = dept.Capacity;
             db.Departments.Update(dep);
             db.SaveChanges();*/
            return RedirectToAction("Index");

        }

        public IActionResult Index()
        {
            var result = deptRep.GetAll();
            //  var result = db.Departments.ToList();
            return View(result);
            // return Json(result);
        }
    }
}
