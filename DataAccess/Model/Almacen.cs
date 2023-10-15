using System;
using System.Collections.Generic;

namespace ProyectoACNUR_API.Model;

public partial class Almacen
{
    public string IdAlmacen { get; set; } = null!;

    public string? NombreAlmacen { get; set; }

    public string? DescripcionAlmacen { get; set; }

    public string SedeId { get; set; } = null!;

    public virtual ICollection<InventarioAlimento> InventarioAlimentos { get; set; } = new List<InventarioAlimento>();

    public virtual ICollection<InventarioMedicina> InventarioMedicinas { get; set; } = new List<InventarioMedicina>();

    public virtual Sede Sede { get; set; } = null!;
}
