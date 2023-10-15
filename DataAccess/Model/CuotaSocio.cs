using System;
using System.Collections.Generic;

namespace DataAccess.Model;

public partial class CuotaSocio
{
    public int IdCuotaSocio { get; set; }

    public int CuotaId { get; set; }

    public int SocioId { get; set; }

    public DateTime FechaPago { get; set; }

    public virtual Cuotum Cuota { get; set; } = null!;

    public virtual Socio Socio { get; set; } = null!;
}
