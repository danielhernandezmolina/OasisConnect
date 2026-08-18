using System;
using System.Collections.Generic;

namespace OasisConnect.Models;

public partial class Hamaca
{
    public int IdHamacas { get; set; }

    public int IdZona { get; set; }

    public string Identificacion { get; set; } = null!;

    public int IdHotel { get; set; }

    public virtual Hotel IdHotelNavigation { get; set; } = null!;

    public virtual Zona IdZonaNavigation { get; set; } = null!;

    public virtual ICollection<Pedido> Pedidos { get; set; } = new List<Pedido>();
}
