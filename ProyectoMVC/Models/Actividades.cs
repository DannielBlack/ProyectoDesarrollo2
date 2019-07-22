using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProyectoMVC.Models
{
    public class Actividades
    {
        public int ActividadesID { get; set; }
        public int PersonasID { get; set; }
        [Required]
        [MaxLength(15)]
        public string Lugar { get; set; }
        [Required]
        [MaxLength(20)]
        public string Descripcion { get; set; }
        [Required]
        public DateTime Fecha { get; set; }

        public virtual Personas Personas { get; set; }
    }
}