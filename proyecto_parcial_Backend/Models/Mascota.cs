using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace proyecto_parcial_Backend.Models
{
    public partial class Mascota
    {
        public Mascota()
        {
            Cita = new HashSet<Cita>();
            Facturas = new HashSet<Factura>();
            Inventarios = new HashSet<Inventario>();
            Reportes = new HashSet<Reporte>();
        }

        public int IdMascota { get; set; }
        public string? NombrePet { get; set; }
        public string? Ciudad { get; set; }
        public string? Raza { get; set; }
        public int? Edad { get; set; }
        public string? Antecedentes { get; set; }
        public string? Castrado { get; set; }

        [JsonIgnore]
        public virtual ICollection<Cita> Cita { get; set; }
        public virtual ICollection<Factura> Facturas { get; set; }
        public virtual ICollection<Inventario> Inventarios { get; set; }
        public virtual ICollection<Reporte> Reportes { get; set; }
    }
}
