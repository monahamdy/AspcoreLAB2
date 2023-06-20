using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Model;

using System.ComponentModel.DataAnnotations.Schema;

namespace AspcoreLAB2.Models
{

    public class UniqueCourseNameAttribute : ValidationAttribute
    {
        ITIContext context = new ITIContext();
            protected override ValidationResult IsValid(object value, ValidationContext validationContext)
            {
                var course = (Course)validationContext.ObjectInstance;
                var departmentId = course.dept_id;

                if (context.Courses.Any(c => c.CourseName == value.ToString() && c.dept_id == departmentId))
                {
                    return new ValidationResult("The course name already exists for this department.");
                }

                return ValidationResult.Success;
            }
        }
}
