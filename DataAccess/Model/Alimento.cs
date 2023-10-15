﻿using System;
using System.Collections.Generic;

namespace ProyectoACNUR_API.Model;

public partial class Alimento
{
    public string IdAlimento { get; set; } = null!;

    public string NombreAlimento { get; set; } = null!;

    public DateTime FechaVencimiento { get; set; }

    public double PesoKg { get; set; }

    public virtual ICollection<EnvioAlimento> EnvioAlimentos { get; set; } = new List<EnvioAlimento>();

    public virtual ICollection<InventarioAlimento> InventarioAlimentos { get; set; } = new List<InventarioAlimento>();
}