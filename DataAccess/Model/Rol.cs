using System;
using System.Collections.Generic;

namespace ProyectoACNUR_API.Model;

public partial class Rol
{
    public string IdRol { get; set; } = null!;

    public string NombreRol { get; set; } = null!;

    public string DescripcionRol { get; set; } = null!;

    public virtual ICollection<UsuarioRol> UsuarioRols { get; set; } = new List<UsuarioRol>();
}
