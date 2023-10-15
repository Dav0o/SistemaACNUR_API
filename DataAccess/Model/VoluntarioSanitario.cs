using System;
using System.Collections.Generic;

namespace ProyectoACNUR_API.Model;

public partial class VoluntarioSanitario
{
    public int IdVoluntarioSanitario { get; set; }

    public bool Disponible { get; set; }

    public int UsuarioDni { get; set; }

    public virtual ICollection<EnvioHumanitario> EnvioHumanitarios { get; set; } = new List<EnvioHumanitario>();

    public virtual ICollection<ProfesionVoluntario> ProfesionVoluntarios { get; set; } = new List<ProfesionVoluntario>();

    public virtual Usuario UsuarioDniNavigation { get; set; } = null!;
}
