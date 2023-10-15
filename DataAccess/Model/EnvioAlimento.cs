using System;
using System.Collections.Generic;

namespace DataAccess.Model;

public partial class EnvioAlimento
{
    public int IdEnvioAlimento { get; set; }

    public string AlimentoId { get; set; } = null!;

    public int CantidadAlimento { get; set; }

    public int EnvioId { get; set; }

    public virtual Alimento Alimento { get; set; } = null!;

    public virtual Envio Envio { get; set; } = null!;
}
