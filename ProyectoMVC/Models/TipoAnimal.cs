using System.ComponentModel.DataAnnotations;

namespace ProyectoMVC.Models
{
    public class TipoAnimal
    {
        [Required]
        [Range(1, 50, ErrorMessage = "El valor para {0} debe de ser entre {1} y {2}")]
        public int IdTipoAnimal { get; set; }

        public string TipoDescripcion {  get; set; }
    }
}
