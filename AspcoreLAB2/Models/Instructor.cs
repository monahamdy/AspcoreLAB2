using System.ComponentModel.DataAnnotations.Schema;

namespace AspcoreLAB2.Models
{
    public class Instructor
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Img { get; set; }
        public string? Address { get; set; }
        public float Salary { get; set; }

        [ForeignKey("Department")]
        public int? dept_id { get; set; }


        [ForeignKey("Course")]
        public int? crs_id { get; set; }
        public virtual Department? Department { get; set; }
        public virtual Course? Course { get; set; }


    }
}
