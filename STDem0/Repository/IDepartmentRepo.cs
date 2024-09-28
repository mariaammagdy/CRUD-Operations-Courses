using STDem0.Data;
using STDem0.Models;

namespace STDem0.Repository
{
    public interface IDepartmentRepo
    {
        public List<Department> GetAll();
        public Department GetById(int id);
        public void Add(Department department);
        public void Update(Department department);
        public void DeleteById(int id);
    }


}

