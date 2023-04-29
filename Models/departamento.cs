using System.ComponentModel.DataAnnotations;

namespace P2_2020ZR601_2020MG601.Models
{
    public class departamento
    {
        [Key]
        [Display (Name = "ID")] 
        public int IdDepartamento { get; set; }
        [Display (Name ="Departamento")]
        public string? Departamento { get; set; }

    }
}
