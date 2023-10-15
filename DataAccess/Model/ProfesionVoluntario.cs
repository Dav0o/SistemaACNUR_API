using System;
using System.Collections.Generic;

namespace ProyectoACNUR_API.Model;

public partial class ProfesionVoluntario
{
    public int IdProfesionVoluntario { get; set; }

    public int VoluntarioSanitarioId { get; set; }

    public string ProfesionId { get; set; } = null!;

    public virtual Profesion Profesion { get; set; } = null!;

    public virtual VoluntarioSanitario VoluntarioSanitario { get; set; } = null!;
}
