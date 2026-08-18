using System;
using System.Collections.Generic;

namespace OasisConnect.Models;

public partial class Zona
{
    public int IdHotel { get; set; }

    public int IdZona { get; set; }

    public string? NombreZona { get; set; }

    public virtual ICollection<Hamaca> Hamacas { get; set; } = new List<Hamaca>();

    public virtual Hotel IdHotelNavigation { get; set; } = null!;
}
