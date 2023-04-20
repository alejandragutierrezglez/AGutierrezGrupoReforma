using System;
using System.Collections.Generic;

namespace DL;

public partial class DetalleFactura
{
    public int? FolioFactura { get; set; }

    public int? IdProducto { get; set; }

    public int? Cantidad { get; set; }

    public virtual Factura? FolioFacturaNavigation { get; set; }

    public virtual Producto? IdProductoNavigation { get; set; }
}
