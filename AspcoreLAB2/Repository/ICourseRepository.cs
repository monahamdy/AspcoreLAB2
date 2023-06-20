using AspcoreLAB2.Models;

namespace AspcoreLAB2.Repository
{
    public interface ICourseRepository
    {
        List<Course> GetAll();
        Course GetBYId(int id);
        void Add(Course crs);
        void Update(int id, Course crs);
        void Delete(int id);
        void Save();
    }
}