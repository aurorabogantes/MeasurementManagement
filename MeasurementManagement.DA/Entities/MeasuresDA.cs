
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MeasurementManagement.DA.Entities
{
    [Table("Measures")]
    public class MeasuresDA
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int Value { get; set; }
        [Required]
        public DateTime Date { get; set; }
    }
}
