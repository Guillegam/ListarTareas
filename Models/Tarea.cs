using System.ComponentModel.DataAnnotations;

namespace ListaDeTareas.Models
{
    public class Tarea
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Nombre de la tarea")]
        public string Nombre { get; set; }
    }
}

