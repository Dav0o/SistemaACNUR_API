using System;
using System.Collections.Generic;

namespace DataAccess.Model;

public partial class Usuario
{
    public int DniUsuario { get; set; }

    public string NombreUsuario { get; set; } = null!;

    public string Apellido1 { get; set; } = null!;

    public string Apellido2 { get; set; } = null!;

    public string Correo { get; set; } = null!;

    public string Clave { get; set; } = null!;

    public int Telefono { get; set; }

    public string Direccion { get; set; } = null!;

    public string SedeId { get; set; } = null!;

    public virtual Sede Sede { get; set; } = null!;

    public virtual ICollection<Socio> Socios { get; set; } = new List<Socio>();

    public virtual ICollection<UsuarioRol> UsuarioRols { get; set; } = new List<UsuarioRol>();

    public virtual ICollection<VoluntarioAdministrador> VoluntarioAdministradors { get; set; } = new List<VoluntarioAdministrador>();

    public virtual ICollection<VoluntarioSanitario> VoluntarioSanitarios { get; set; } = new List<VoluntarioSanitario>();
}
