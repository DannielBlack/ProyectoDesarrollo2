using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProyectoMVC.Models
{
    public class Personas
    {
        public int PersonasID { get; set; }

        [Required]
        [MaxLength(10)]
        public string Nombre { get; set; }

        [Required]
        [MaxLength(10)]
        public string Apellido { get; set; }

        [Required]
        public int Cedula { get; set; }

        [Required]
        [DisplayName("Edad")]
        [Range(0, 70, ErrorMessage = "Debe tener una edad entre 0 y 70 años")]

        public int Edad { get; set; }

        public virtual ICollection<Actividades> Actividadess { get; set; }
    }
}