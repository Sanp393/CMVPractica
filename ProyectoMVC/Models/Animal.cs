using System.ComponentModel.DataAnnotations;

namespace ProyectoMVC.Models
{
    public class Animal
    {
        [Required]
        [Range(1, 50, ErrorMessage = "El valor para {0} debe de ser entre {1} y {2}")]
        public int IdAnimal { get; set; }

        [Required]
        [Display(Name = "Animal")]
        [StringLength(10, ErrorMessage = "El nombre de animal introducido no puede exceder los 10 carácteres")]
        public string Nombre { get; set; }

        
    }
}
