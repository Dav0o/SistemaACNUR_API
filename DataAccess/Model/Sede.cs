using System;
using System.Collections.Generic;

namespace ProyectoACNUR_API.Model;

public partial class Sede
{
    public string IdSede { get; set; } = null!;

    public int DireccionId { get; set; }

    public virtual ICollection<Almacen> Almacens { get; set; } = new List<Almacen>();

    public virtual Direccion Direccion { get; set; } = null!;

    public virtual ICollection<EnvioSede> EnvioSedes { get; set; } = new List<EnvioSede>();

    public virtual ICollection<Usuario> Usuarios { get; set; } = new List<Usuario>();
}
