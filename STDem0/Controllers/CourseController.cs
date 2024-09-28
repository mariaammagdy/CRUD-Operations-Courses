using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using STDem0.Models;
using STDem0.Repository;

namespace STDem0.Controllers
{
    [Authorize]
    public class CourseController : Controller
    {
        ICourseRepo courep;
        public CourseController(ICourseRepo _courep)
        {
            courep = _courep;
        }
    
        public IActionResult Index()
        {
            var res = courep.GetAll();
            return View(res);
        }
        [AllowAnonymous]
        public IActionResult Details(int? id)
        {
            if (id == null)
                return BadRequest();
            Course cour = courep.GetById(id.Value);
            if (cour == null)
                return NotFound();
            return View(cour);

        }
        public IActionResult Delete(int id)
        {
            var del = courep.GetById(id);
            return View(del);
        }
        [HttpPost, ActionName("delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            courep.DeleteById(id);
            return RedirectToAction("Index");
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Course course)
        {
            courep.Add(course);
            return RedirectToAction("Index");

        }
        public IActionResult Update(int id)
        {
            Course cour = courep.GetById(id);
            return View(cour);
        }
        [HttpPost]
        public IActionResult Update(Course course)
        {
            courep.Update(course);
            return RedirectToAction("Index");
        }
    }
}