using System;
using System.Collections.Generic;

namespace DataAccess.Model;

public partial class Envio
{
    public int IdEnvio { get; set; }

    public string Destino { get; set; } = null!;

    public DateTime FechaEnvio { get; set; }

    public string TipoAyuda { get; set; } = null!;

    public int? Cantidad { get; set; }

    public string UnidadMedidaId { get; set; } = null!;

    public virtual ICollection<EnvioAlimento> EnvioAlimentos { get; set; } = new List<EnvioAlimento>();

    public virtual ICollection<EnvioHumanitario> EnvioHumanitarios { get; set; } = new List<EnvioHumanitario>();

    public virtual ICollection<EnvioMedicina> EnvioMedicinas { get; set; } = new List<EnvioMedicina>();

    public virtual ICollection<EnvioSede> EnvioSedes { get; set; } = new List<EnvioSede>();

    public virtual UnidadMedidum UnidadMedida { get; set; } = null!;
}
