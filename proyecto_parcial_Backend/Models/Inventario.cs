using System;
using System.Collections.Generic;

namespace proyecto_parcial_Backend.Models
{
    public partial class Inventario
    {
        public int IdInventario { get; set; }
        public int? IdMascota { get; set; }
        public string? NombrePet { get; set; }
        public int? IdCita { get; set; }
        public DateTime FechaCita { get; set; }
        public string? Especialidad { get; set; }

        public virtual Cita? oCita { get; set; }
        public virtual Mascota? oMascota { get; set; }
    }
}
