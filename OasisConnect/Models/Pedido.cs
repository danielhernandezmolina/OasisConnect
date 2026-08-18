using System;
using System.Collections.Generic;

namespace OasisConnect.Models;

public partial class Pedido
{
    public int IdPedidos { get; set; }

    public DateOnly Fecha { get; set; }

    public TimeOnly Hora { get; set; }

    public string Estado { get; set; } = null!;

    public string MetodoPago { get; set; } = null!;

    public string ApellidoHuesped { get; set; } = null!;

    public int NumHabitacion { get; set; }

    public decimal Total { get; set; }

    public int IdHamacas { get; set; }

    public virtual ICollection<DetallePedido> DetallePedidos { get; set; } = new List<DetallePedido>();

    public virtual Hamaca? IdHamacasNavigation { get; set; } = null!;
}
