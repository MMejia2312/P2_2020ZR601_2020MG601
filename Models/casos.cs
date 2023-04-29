using System.ComponentModel.DataAnnotations;

namespace P2_2020ZR601_2020MG601.Models
{
    public class casos
    {
        [Key]
        [Display (Name = "ID Caso")]
        public int IdCasos { get; set; }
        [Display (Name = "ID Departamento")]
        public int IdDepartamento { get; set; }
        [Display(Name = "ID Genero")]
        public int IdGenero { get; set; }
        public int Confirmados { get; set; }
        public int Recuperados { get; set; }
        public int Fallecidos { get; set; }

    }
}
