using System;
using System.Collections.Generic;

namespace OasisConnect.Models;

public partial class DetallePedido
{
    public int IdDetalle { get; set; }

    public int IdPedidos { get; set; }

    public int IdProductos { get; set; }

    public int Cantidad { get; set; }

    public string? Notas { get; set; }

    public virtual Pedido? IdPedidosNavigation { get; set; }
    public virtual Producto? IdProductosNavigation { get; set; }
}
