using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace proyecto_parcial_Backend.Models
{
    public partial class Usuario
    {
        public Usuario()
        {
            Cita = new HashSet<Cita>();
            Facturas = new HashSet<Factura>();
        }

        public int IdUsuario { get; set; }
        public string? Nombre { get; set; }
        public string? Correo { get; set; }
        public string? Contraseña { get; set; }
        public string? Telefono { get; set; }


        [JsonIgnore]
        public virtual ICollection<Cita> Cita { get; set; }
        public virtual ICollection<Factura> Facturas { get; set; }
    }
}
