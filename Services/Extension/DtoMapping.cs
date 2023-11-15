namespace Services.Extension
{
    public class DtoMapping
    {
        #region Alimento
        public struct DtoAlimento
        {
            public string IdAlimento { get; set; }

            public string NombreAlimento { get; set; }

            public DateTime FechaVencimiento { get; set; }

            public double Peso { get; set; }

            public string Unidad { get; set; }
        }
        #endregion

        #region Medicina
        public struct DtoMedicina
        {
            public string IdMedicina { get; set; } 

            public string NombreMedicina { get; set; } 

            public DateTime FechaVencimiento { get; set; }
        }
        #endregion

        #region Almacen
        public struct DtoAlmacen
        {
            public string IdAlmacen { get; set; }

            public string NombreAlmacen { get; set; }

            public string DescripcionAlmacen { get; set; }

            public string SedeId { get; set; }
        }
        #endregion

        #region InventarioAlimento
        public struct DtoInventarioAlimento
        {
            public int IdInventarioAlimento { get; set; }

            public string AlimentoId { get; set; } 

            public string AlmacenId { get; set; } 

            public int Cantidad { get; set; }
        }
        #endregion

        #region Envio
        public struct DtoEnvio
        {
            public int IdEnvio { get; set; }

            public string Destino { get; set; } 

            public DateTime FechaEnvio { get; set; }

            public string TipoAyuda { get; set; } 

            public int Cantidad { get; set; }

            public string UnidadMedidaId { get; set; } 
        }

        #endregion

        #region InventarioMedicina 
        public struct DtoInventarioMedicina
        {
            public int IdInventarioMedicina { get; set; }

            public string MedicinaId { get; set; } 
            public string AlmacenId { get; set; } 

            public int Cantidad { get; set; }
        }
        #endregion

        #region Sede
        public struct DtoSede
        {
            public string IdSede { get; set; }

            public int DireccionId { get; set; }
        }
        #endregion

        #region UnidadMedida
        public struct DtoUnidadMedida
        {
            public string IdUnidadMedida { get; set; } 

            public string Unidad { get; set; }
        }
        #endregion

        #region Usuario
        public struct DtoUsuario
        {
            public int DniUsuario { get; set; }

            public string NombreUsuario { get; set; }

            public string Apellido1 { get; set; }

            public string Apellido2 { get; set; }

            public string Correo { get; set; }

            public string Clave { get; set; }

            public int Telefono { get; set; }

            public string Direccion { get; set; }

            public string SedeId { get; set; }
        }
        public struct DtoLogin
        {
            public string Correo { get; set; }

            public string Clave { get; set; }
        }
        #endregion

        #region Direccion
        public struct DtoDireccion
        {
            public int IdDireccion { get; set; }

            public string Pais { get; set; } 

            public string Ciudad { get; set; }

            public string Estado { get; set; } 

            public string DireccionExacta { get; set; }

        }
        #endregion

        #region Rol
        public struct DtoRol
        {
            public string IdRol { get; set; } 

            public string NombreRol { get; set; }

            public string DescripcionRol { get; set; } 


        }
        #endregion

        #region UsuarioRol
        public struct DtoUsuarioRol
        {
            public int IdUsuarioRol { get; set; }

            public int UsuarioDni { get; set; }

            public string RolId { get; set; } 


        }
        #endregion

        #region Profesion
        public struct DtoProfesion
        {
            public string IdProfesion { get; set; }

            public string NombreProfesion { get; set; } 


        }
        #endregion

        #region ProfesionVoluntario
        public struct DtoProfesionVoluntario
        {
            public int IdProfesionVoluntario { get; set; }

            public int VoluntarioSanitarioId { get; set; }

            public string ProfesionId { get; set; }

        }
        #endregion

        #region Socio
        public struct DtoSocio
        {
            public int IdSocio { get; set; }

            public int CuentaBanco { get; set; }

            public int UsuarioDni { get; set; }

            public int CuotaId { get; set; }


        }
        #endregion

        #region Cuota
        public struct DtoCuota
        {
            public int IdCuota { get; set; }

            public decimal CargosAnuales { get; set; }

            public string TipoCuota { get; set; } 


        }
        #endregion

        #region CuotaSocio
        public struct DtoCuotaSocio
        {
            public int IdCuotaSocio { get; set; }

            public int CuotaId { get; set; }

            public int SocioId { get; set; }

            public DateTime FechaPago { get; set; }

        }
        #endregion

        #region VoluntarioAdministrador
        public struct DtoVoluntarioAdministrador
        {
            public int IdVoluntarioAdministrador { get; set; }

            public int UsuarioDni { get; set; }


        }
        #endregion

        #region VoluntarioSanitario
        public struct DtoVoluntarioSanitario
        {
            public int IdVoluntarioSanitario { get; set; }

            public bool Disponible { get; set; }

            public int UsuarioDni { get; set; }


        }
        #endregion

        #region EnvioAlimento
        public struct DtoEnvioAlimento
        {
            public int IdEnvioAlimento { get; set; }

            public string AlimentoId { get; set; }

            public int CantidadAlimento { get; set; }

            public int EnvioId { get; set; }


        }
        #endregion

        #region EnvioMedicina
        public struct DtoEnvioMedicina
        {
            public int IdEnvioMedicina { get; set; }

            public string MedicinaId { get; set; } 

            public int CantidadMedicina { get; set; }

            public int EnvioId { get; set; }


        }
        #endregion

        #region EnvioHumanitario
        public struct DtoEnvioHumanitario
        {
           public int IdEnvioHumanitario { get; set; }

            public int VoluntarioSanitarioId { get; set; }

            public int EnvioId { get; set; }

        }
        #endregion

        #region EnvioSede
        public struct DtoEnvioSede
        {
            public int IdEnvioSede { get; set; }

            public string SedeId { get; set; }

            public int EnvioId { get; set; }


        }
        #endregion

    }


}
