using System;
using System.Collections.Generic;

namespace ProyectoACNUR_API.Model;

public partial class EnvioMedicina
{
    public int IdEnvioMedicina { get; set; }

    public string MedicinaId { get; set; } = null!;

    public int CantidadMedicina { get; set; }

    public int EnvioId { get; set; }

    public virtual Envio Envio { get; set; } = null!;

    public virtual Medicina Medicina { get; set; } = null!;
}
