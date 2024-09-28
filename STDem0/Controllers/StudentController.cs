using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using STDem0.Models;
using STDem0.Repository;
using STDem0.Data;
using System;
using Microsoft.AspNetCore.Authorization;

namespace STDem0.Controllers
{
    [Authorize]
    public class StudentController : Controller
    {

        //ITIContext db = new ITIContext();
        IStudentRepo studentRep;// = new StudentRepo();    
        IDepartmentRepo departmentRepo;// = new DepartmentRepo();
        public StudentController(IDepartmentRepo _departmentRepo, IStudentRepo _studentRepo)
        {
            departmentRepo = _departmentRepo;
            studentRep = _studentRepo;
        }
        public IActionResult Create()
        {
            ViewBag.depts = departmentRepo.GetAll();
            // ViewBag.depts = db.Departments.ToList();
            return View();
        }
        // public IActionResult Create(int stuid, string name, int age , int deptno)
        [HttpPost]
        public IActionResult Create(Student stu)
        {
     
                studentRep.Add(stu);

                // db.Students.Add(stu);
                //db.SaveChanges();
                return RedirectToAction("Index");
                ViewBag.depts = departmentRepo.GetAll();
                // ViewBag.depts = db.Departments.ToList();
                return View(stu);
            
        }
        public IActionResult Details(int? id)
        {
            if (id == null)
                return BadRequest(); //200
            Student stu = studentRep.GetById(id.Value);
            // Student stu = db.Students.SingleOrDefault(a => a.Id == id);
            if (stu == null)
                return NotFound();  //404
            return View(stu);

        }

        public IActionResult Delete(int id)
        {
            var stu = studentRep.GetById(id);
            //var stu = db.Students.SingleOrDefault(a => a.Id == id);
            //db.Students.Remove(stu);
            //db.SaveChanges();
            return View(stu);
        }
        [HttpPost, ActionName("delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            studentRep.DeleteById(id);
            //var stu = db.Students.SingleOrDefault(a => a.Id == id);
            // db.Students.Remove(stu);
            //db.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Update(int id)
        {
            ViewBag.depts = departmentRepo.GetAll();
            var student = studentRep.GetById(id);
            //ViewBag.depts = db.Departments.ToList();
            //var student = db.Students.Find(id);
            if (student == null)
            {
                return NotFound();
            }
            return View(student);
        }
        [HttpPost]
        public IActionResult Update(Student stu)
        {
           /* if (!ModelState.IsValid)
            {
                return View(stu);
            }*/
            studentRep.Update(stu);
            // var student = db.Students.Find(stu.Id);
            /* if (student == null)
             {
                 return NotFound();
             }
             student.Name = stu.Name;
             student.Age = stu.Age;
             student.Email = stu.Email;
             student.Password = stu.Password;
             db.Students.Update(student);
             db.SaveChanges();*/
            return RedirectToAction("Index");

        }
        public IActionResult Index()
        {
            var result = studentRep.GetAll();

            // var result = db.Students.Include(s=>s.Department).ToList();
            return View(result);
        }
    }
}
