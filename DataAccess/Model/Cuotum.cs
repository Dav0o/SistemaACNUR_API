using System;
using System.Collections.Generic;

namespace ProyectoACNUR_API.Model;

public partial class Cuotum
{
    public int IdCuota { get; set; }

    public decimal CargosAnuales { get; set; }

    public string TipoCuota { get; set; } = null!;

    public virtual ICollection<CuotaSocio> CuotaSocios { get; set; } = new List<CuotaSocio>();

    public virtual ICollection<Socio> Socios { get; set; } = new List<Socio>();
}
