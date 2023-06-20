using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Build.Framework;
using Newtonsoft.Json.Serialization;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AspcoreLAB2.Models
{
    public class Course
    {
        public int Id { get; set; }

        [UniqueCourseName]
        [MaxLength(25,ErrorMessage ="Name must be less than 25 letter")]
        [MinLength(2, ErrorMessage = "Name must be more than 2 char")]
        public string CourseName { get; set; }

        [Range(minimum:25,maximum: 100, ErrorMessage = "Degree must be between 25 and 100")]
        public int Degree { get; set; }

        [Remote(action: "CheckMinDegree", controller: "Course", AdditionalFields = nameof(Degree) , ErrorMessage = "Minimum degree must be less than degree.") ]
        public int MinDegree { get; set; }

        [ForeignKey("Department")]
        public int? dept_id { get; set; }

        [ForeignKey("crsResult")]
        public int? crs_id { get; set; }

        [ForeignKey("Instructor")]
        public int? ins_id { get; set; }
        public virtual List<Instructor>? Instructors { get; set; }
        public virtual List<CursResult>? CursResults { get; set; }
        public virtual Department? Department { get; set; }


    }
}
