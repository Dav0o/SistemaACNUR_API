using System;
using System.Collections.Generic;

namespace DataAccess.Model;

public partial class RegistroAccione
{
    public int IdAuditoria { get; set; }

    public string Tabla { get; set; } = null!;

    public string Accion { get; set; } = null!;

    public string Campo { get; set; } = null!;

    public DateTime Fecha { get; set; }

    public string Usuario { get; set; } = null!;

    public string Pc { get; set; } = null!;
}
