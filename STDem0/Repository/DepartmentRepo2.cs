using STDem0.Models;

namespace STDem0.Repository
{
    public class DepartmentRepo2 : IDepartmentRepo
    {
        static List<Department> db = new List<Department>()
        {
            new Department(){DeptName="CS" , Capacity=50 , DeptId=1}
        };
        public void Add(Department department)
        {
            db.Add(department);
        }

        public void DeleteById(int id)
        {
            throw new NotImplementedException();
        }

        public List<Department> GetAll()
        {
            return db;
        }

        public Department GetById(int id)
        {
            return db.FirstOrDefault(a => a.DeptId == id);
        }

        public void Update(Department department)
        {
            throw new NotImplementedException();
        }
    }
}
