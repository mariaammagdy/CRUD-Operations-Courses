using STDem0.Data;
using STDem0.Models;

namespace STDem0.Repository
{
    public class DepartmentRepo : IDepartmentRepo
    {
        ITIContext db; //= new ITIContext();
        public DepartmentRepo(ITIContext _db)
        {
            db = _db;
        }
        public void Add(Department department)
        {
            db.Add(department);
            db.SaveChanges();
        }

        public void DeleteById(int id)
        {
            var dept = db.Departments.FirstOrDefault(a => a.DeptId == id);
            // db.Remove(dept);
            dept.Status = false;
            db.SaveChanges();
        }

        public List<Department> GetAll()
        {
            return db.Departments.Where(d=>d.Status==true).ToList();
        }

        public Department GetById(int id)
        {
            return db.Departments.FirstOrDefault(a => a.DeptId == id);

        }

        public void Update(Department department)
        {
            db.Departments.Update(department);
            db.SaveChanges();
        }
    }
}
