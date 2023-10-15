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
    }
}
