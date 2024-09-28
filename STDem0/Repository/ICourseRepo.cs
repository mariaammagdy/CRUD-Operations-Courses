using STDem0.Models;

namespace STDem0.Repository
{
    public interface ICourseRepo
    {
        public List<Course> GetAll();
        public Course GetById(int id);
        public void Add(Course course);
        public void Update(Course course);
        public void DeleteById(int id);
    }
}
