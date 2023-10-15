using System;
using System.Collections.Generic;

namespace DataAccess.Model;

public partial class VoluntarioAdministrador
{
    public int IdVoluntarioAdministrador { get; set; }

    public int UsuarioDni { get; set; }

    public virtual Usuario UsuarioDniNavigation { get; set; } = null!;
}
