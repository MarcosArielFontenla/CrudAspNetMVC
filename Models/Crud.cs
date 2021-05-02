using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CrudRazor3.Models
{
    public class Crud
    {
        [Key] // Id primary key
        public int Id { get; set; }
        [Required] // NombreCurso requerido
        [Display(Name = "Nombre de cursos")]
        public string NombreCurso { get; set; }
        [Display(Name = "Cantidad de clases")]
        public int CantidadClases { get; set; }
        public int Precio { get; set; }
    }
}
