using System;
using System.Collections.Generic;

namespace DataAccess.Model;

public partial class Socio
{
    public int IdSocio { get; set; }

    public int CuentaBanco { get; set; }

    public int UsuarioDni { get; set; }

    public int CuotaId { get; set; }

    public virtual Cuotum Cuota { get; set; } = null!;

    public virtual ICollection<CuotaSocio> CuotaSocios { get; set; } = new List<CuotaSocio>();

    public virtual Usuario UsuarioDniNavigation { get; set; } = null!;
}
