using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AspNetCoreWebApiAngular.Models
{
    [Table("Monitor", Schema = "dbo")]  
    public class Monitor
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]  
        [Display(Name = "Monitor Id")]  
        public int Id { get; set; }

        [Required]
        [Column(TypeName = "float")]  
        [Display(Name = "Recorded Value")] 
        public float Value { get; set; }

        [Required]
        [Column(TypeName = "varchar(100)")]  
        public string Description { get; set; }

        [Required]
        [Column(TypeName = "datetime")]  
        public DateTime MeasuredAt { get; set; }
    }

}
