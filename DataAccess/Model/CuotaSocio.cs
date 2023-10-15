using System;
using System.Collections.Generic;

namespace ProyectoACNUR_API.Model;

public partial class CuotaSocio
{
    public int IdCuotaSocio { get; set; }

    public int CuotaId { get; set; }

    public int SocioId { get; set; }

    public virtual Cuotum Cuota { get; set; } = null!;

    public virtual Socio Socio { get; set; } = null!;
}
