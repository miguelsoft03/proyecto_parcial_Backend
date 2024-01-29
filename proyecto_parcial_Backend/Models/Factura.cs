using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace proyecto_parcial_Backend.Models
{
    public partial class Factura
    {
        public int IdFactura { get; set; }
        public int? IdUsuario { get; set; }
        public string? Nombre { get; set; }
        public string? Correo { get; set; }
        public int? IdMascota { get; set; }
        public string? NombrePet { get; set; }
        public int? IdCita { get; set; }
        public DateTime FechaCita { get; set; }
        public string? Especialidad { get; set; }
        public decimal? Costos { get; set; }
        [JsonIgnore]
        public virtual Cita? oCita { get; set; }
        public virtual Mascota? oMascota { get; set; }
        public virtual Usuario? oUsuario { get; set; }
        
    }
}
