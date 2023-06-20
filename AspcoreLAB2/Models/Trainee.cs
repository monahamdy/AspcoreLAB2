using System.ComponentModel.DataAnnotations.Schema;

namespace AspcoreLAB2.Models
{
    public class Trainee
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string ?Img { get; set; }
        public string? Address { get; set; }
        public int Grade { get; set; }
        [ForeignKey("Course")]
        public int? crs_id { get; set; }
        public virtual Course? Course { get; set; }

        [ForeignKey("Trainee")]
        public int? trainee_id { get; set; }
        public virtual Department? Department { get; set; }
        public virtual List<CursResult>  ?CursResults { get; set; }

    }
}
