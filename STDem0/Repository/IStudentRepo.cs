using Microsoft.EntityFrameworkCore;
using STDem0.Data;
using STDem0.Models;

namespace STDem0.Repository
{
    public interface IStudentRepo
    {
        public List<Student> GetAll();
        public Student GetById(int id);
        public void Add(Student student);
        public void Update(Student student);
        public void DeleteById(int id);
    }

}
