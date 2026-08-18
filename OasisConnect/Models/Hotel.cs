using System;
using System.Collections.Generic;

namespace OasisConnect.Models;

public partial class Hotel
{
    public int IdHotel { get; set; }

    public string NombreHotel { get; set; } = null!;

    public string Cif { get; set; } = null!;

    public string? Direccion { get; set; }

    public string? ConfigPmsEndpoint { get; set; }

    public bool? EstadoActividad { get; set; }

    public virtual ICollection<Hamaca> Hamacas { get; set; } = new List<Hamaca>();

    public virtual ICollection<Zona> Zonas { get; set; } = new List<Zona>();
}
