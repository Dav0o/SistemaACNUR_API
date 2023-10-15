using System;
using System.Collections.Generic;

namespace DataAccess.Model;

public partial class EnvioHumanitario
{
    public int IdEnvioHumanitario { get; set; }

    public int VoluntarioSanitarioId { get; set; }

    public int EnvioId { get; set; }

    public virtual Envio Envio { get; set; } = null!;

    public virtual VoluntarioSanitario VoluntarioSanitario { get; set; } = null!;
}
