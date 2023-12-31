﻿using System;
using System.Collections.Generic;

namespace DataAccess.Model;

public partial class UnidadMedidum
{
    public string IdUnidadMedida { get; set; } = null!;

    public string Unidad { get; set; } = null!;

    public virtual ICollection<Envio> Envios { get; set; } = new List<Envio>();
}
