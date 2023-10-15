using System;
using System.Collections.Generic;

namespace ProyectoACNUR_API.Model;

public partial class EnvioSede
{
    public int IdEnvioSede { get; set; }

    public string SedeId { get; set; } = null!;

    public int EnvioId { get; set; }

    public virtual Envio Envio { get; set; } = null!;

    public virtual Sede Sede { get; set; } = null!;
}
