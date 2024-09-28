using Microsoft.EntityFrameworkCore;
using STDem0.Data;
using STDem0.Models;

namespace STDem0.Repository
{
    public class StudentRepo : IStudentRepo
    {
        ITIContext db; //= new ITIContext();
        public StudentRepo(ITIContext _db)
        {
            db = _db;
        }

        public void Add(Student student)
        {
            db.Add(student);
            db.SaveChanges();
        }

        public void DeleteById(int id)
        {
            var student = db.Students.FirstOrDefault(a => a.Id == id);
            db.Students.Remove(student);
            db.SaveChanges();
        }

        public List<Student> GetAll()
        {
            return db.Students
                     .Include(s => s.Department)
                     .ToList();
        }


        public Student GetById(int id)
        {
            return db.Students.FirstOrDefault(a => a.Id == id);

        }

        public void Update(Student student)
        {
            db.Update(student);
            db.SaveChanges();
        }
    }
}
