using System.ComponentModel.DataAnnotations.Schema;

namespace AspcoreLAB2.Models
{
    public class CursResult
    {
        public virtual Course Course { get; set; }
        public virtual Trainee Trainee { get; set; }

        public int Id { get; set; }
        public int degree { get; set; }

        public int CourseId { get; set; }
        public int TraineeId { get; set; }




    }
}
