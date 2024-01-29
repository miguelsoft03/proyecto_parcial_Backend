using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace proyecto_parcial_Backend.Models
{
    public partial class Cita
    {
        public Cita()
        {
            Facturas = new HashSet<Factura>();
            Inventarios = new HashSet<Inventario>();
        }

        public int IdCita { get; set; }
        public int? IdUsuario { get; set; }
        public string? Nombre { get; set; }
        public string? Correo { get; set; }
        public int? IdMascota { get; set; }
        public string? NombrePet { get; set; }
        public string? Ciudad { get; set; }
        public string? Especialidad { get; set; }
        public string? Sucursal { get; set; }
        public int? Mes { get; set; }
        public int? Dia { get; set; }

        public virtual Mascota? oMascota { get; set; }
        public virtual Usuario? oUsuario { get; set; }

        [JsonIgnore]
        public virtual ICollection<Factura> Facturas { get; set; }
        public virtual ICollection<Inventario> Inventarios { get; set; }
    }
}
