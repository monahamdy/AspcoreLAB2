using System.ComponentModel.DataAnnotations.Schema;

namespace AspcoreLAB2.Models
{
    public class Department
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string ?Manger { get; set; }

       [ForeignKey("Instructor")]
        public int? ins_id { get; set; }
        [ForeignKey("Trainee")]
        public int? trainee_id { get; set; }

        [ForeignKey("Course")]
        public int? crs_id { get; set; }
        public virtual List<Instructor> Instructors { get; set; }
        public virtual List<Trainee> ?Trainees { get; set; }
        public virtual List<Course> Courses { get; set; }


    }
}
