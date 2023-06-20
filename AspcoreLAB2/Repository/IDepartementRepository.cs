using AspcoreLAB2.Models;

namespace AspcoreLAB2.Repository
{
    public interface IDepartementRepository
    {
        List<Department> GetAll();
        Department GetBYId(int id);
        void Add(Department department);
        void Update(int id, Department department);
        void Delete(int id);
        void Save();

    }
}