using System;
using System.Collections.Generic;

namespace OasisConnect.Models;

public partial class Producto
{
    public int IdProductos { get; set; }

    public string? Alergenos { get; set; }

    public string Nombre { get; set; } = null!;

    public string Descripcion { get; set; } = null!;

    public decimal Precio { get; set; }

    public sbyte Disponibilidad { get; set; }

    public string? Categoria { get; set; }

    public virtual ICollection<DetallePedido> DetallePedidos { get; set; } = new List<DetallePedido>();
}
