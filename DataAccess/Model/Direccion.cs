using System;
using System.Collections.Generic;

namespace ProyectoACNUR_API.Model;

public partial class Direccion
{
    public int IdDireccion { get; set; }

    public string Pais { get; set; } = null!;

    public string Ciudad { get; set; } = null!;

    public string Estado { get; set; } = null!;

    public string DireccionExacta { get; set; } = null!;

    public virtual ICollection<Sede> Sedes { get; set; } = new List<Sede>();
}
