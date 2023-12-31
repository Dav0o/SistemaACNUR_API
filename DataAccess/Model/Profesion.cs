﻿using System;
using System.Collections.Generic;

namespace DataAccess.Model;

public partial class Profesion
{
    public string IdProfesion { get; set; } = null!;

    public string NombreProfesion { get; set; } = null!;

    public virtual ICollection<ProfesionVoluntario> ProfesionVoluntarios { get; set; } = new List<ProfesionVoluntario>();
}
