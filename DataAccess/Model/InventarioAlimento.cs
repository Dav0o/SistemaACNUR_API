using System;
using System.Collections.Generic;

namespace DataAccess.Model;

public partial class InventarioAlimento
{
    public int IdInventarioAlimento { get; set; }

    public string AlimentoId { get; set; } = null!;

    public string AlmacenId { get; set; } = null!;

    public int? Cantidad { get; set; }

    public virtual Alimento Alimento { get; set; } = null!;

    public virtual Almacen Almacen { get; set; } = null!;
}
