using STDem0.Data;
using STDem0.Models;

namespace STDem0.Repository
{
    public class CourseRepo : ICourseRepo
    {
        ITIContext db;
        public CourseRepo(ITIContext _db)
        {
            db = _db;
        }
        public void Add(Course course)
        {
            db.Add(course);
            db.SaveChanges();
        }

        public void DeleteById(int id)
        {
            var del = db.Courses.FirstOrDefault(c => c.Id == id);
            db.Remove(del);
            db.SaveChanges();


        }

        public List<Course> GetAll()
        {
            return db.Courses.ToList();
        }

        public Course GetById(int id)
        {
            return db.Courses.FirstOrDefault(c => c.Id == id);
        }

        public void Update(Course course)
        {
            db.Courses.Update(course);
            db.SaveChanges();
        }
    }
}
