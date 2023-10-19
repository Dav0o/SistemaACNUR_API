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

            public double PesoKg { get; set; }
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

        #region
        public struct DtoInventarioMedicina
        {
            public int IdInventarioMedicina { get; set; }

            public string MedicinaId { get; set; } 
            public string AlmacenId { get; set; } 

            public int Cantidad { get; set; }
        }
        #endregion

        #region
        public struct DtoSede
        {
            public string IdSede { get; set; }

            public int DireccionId { get; set; }
        }
        #endregion

        #region
        public struct DtoUnidadMedida
        {
            public string IdUnidadMedida { get; set; } 

            public string Unidad { get; set; }
        }
        #endregion

        #region
        public struct DtoUsuario
        {
            public int DniUsuario { get; set; }

            public string NombreUsuario { get; set; }

            public string Apellido1 { get; set; }

            public string Apellido2 { get; set; }

            public string Correo { get; set; } 

            public byte[] Clave { get; set; } 

            public int Telefono { get; set; }

            public string Direccion { get; set; } 

            public string SedeId { get; set; } 
        }
        #endregion
    }


}
