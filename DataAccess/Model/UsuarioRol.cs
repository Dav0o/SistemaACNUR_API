using System;
using System.Collections.Generic;

namespace ProyectoACNUR_API.Model;

public partial class UsuarioRol
{
    public int IdUsuarioRol { get; set; }

    public int UsuarioDni { get; set; }

    public string RolId { get; set; } = null!;

    public virtual Rol Rol { get; set; } = null!;

    public virtual Usuario UsuarioDniNavigation { get; set; } = null!;
}
