using AspcoreLAB2.Models;

namespace AspcoreLAB2.Repository
{
    public class CourseRepository: ICourseRepository
    {

        ITIContext Context;
        public CourseRepository()
        {
            Context = new ITIContext();
        }
        public List<Course> GetAll()
        {
            return Context.Courses.ToList();
        }
        public Course GetBYId(int id)
        {
            return Context.Courses.SingleOrDefault(d => d.Id == id);
        }
        public void Add(Course crs)
        {
            Context.Courses.Add(crs);   

        }
        public void Update(int id, Course crs)
        {
            Course oldcrs = GetBYId(id);
            oldcrs.CourseName = crs.CourseName;
            oldcrs.crs_id = crs.crs_id;
            oldcrs.dept_id = crs.dept_id;
            oldcrs.ins_id= crs.ins_id;
            oldcrs.MinDegree = crs.MinDegree;
            oldcrs.Degree= crs.Degree;

        }
        public void Delete(int id)
        {
            Course oldcrs = GetBYId(id);
            Context.Courses.Remove(oldcrs);
        }
        public void Save()
        {
            Context.SaveChanges();
        }
    }
}

