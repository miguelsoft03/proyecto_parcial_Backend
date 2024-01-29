using System;
using System.Collections.Generic;

namespace proyecto_parcial_Backend.Models
{
    public partial class Reporte
    {
        public int IdReporte { get; set; }
        public int? IdMascota { get; set; }
        public string? NombrePet { get; set; }
        public DateTime FechaCita { get; set; }
        public string? Estado { get; set; }

        public virtual Mascota? oMascota { get; set; }
    }
}
