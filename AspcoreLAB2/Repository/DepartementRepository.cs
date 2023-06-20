using AspcoreLAB2.Models;

namespace AspcoreLAB2.Repository
{
    public class DepartementRepository: IDepartementRepository
    {
        ITIContext Context;
        public DepartementRepository()
        {
            Context = new ITIContext();
        }
       public List<Department> GetAll()
        {
            return Context.Departments.ToList();
        }
        public Department GetBYId(int id) {
            return Context.Departments.SingleOrDefault(d => d.Id == id);
         }
        public void Add(Department department) { 
           Context.Departments.Add(department);

        }
        public void Update(int id , Department department)
        {
            Department olddept = GetBYId(id);
            olddept.Name = department.Name;
            olddept.Id = department.Id;
            olddept.Manger=department.Manger;
            olddept.crs_id=department.crs_id;
            olddept.trainee_id=department.trainee_id; 
            olddept.ins_id=department.ins_id;   
            //Context.Update(department);
        }
        public void Delete(int id)
        {
            Department olddept=GetBYId(id);
            Context.Departments.Remove(olddept);    
        }
        public void Save() {
            Context.SaveChanges();
        }
    }
}
