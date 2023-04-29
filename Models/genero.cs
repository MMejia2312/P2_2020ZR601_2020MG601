using System.ComponentModel.DataAnnotations;

namespace P2_2020ZR601_2020MG601.Models
{
    public class genero
    {
        [Key]
        public int IdGenero { get; set; }
        public String? Genero { get; set; }
    }
}
