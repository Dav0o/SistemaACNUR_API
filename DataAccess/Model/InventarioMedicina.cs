using System;
using System.Collections.Generic;

namespace DataAccess.Model;

public partial class InventarioMedicina
{
    public int IdInventarioMedicina { get; set; }

    public string MedicinaId { get; set; } = null!;

    public string AlmacenId { get; set; } = null!;

    public int? Cantidad { get; set; }

    public virtual Almacen Almacen { get; set; } = null!;

    public virtual Medicina Medicina { get; set; } = null!;
}
