using System;
using System.Collections.Generic;

namespace ProyectoACNUR_API.Model;

public partial class Medicina
{
    public string IdMedicina { get; set; } = null!;

    public string NombreMedicina { get; set; } = null!;

    public DateTime FechaVencimiento { get; set; }

    public virtual ICollection<EnvioMedicina> EnvioMedicinas { get; set; } = new List<EnvioMedicina>();

    public virtual ICollection<InventarioMedicina> InventarioMedicinas { get; set; } = new List<InventarioMedicina>();
}
