using DataAccess.Model;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Services.Services.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Services.Extension.DtoMapping;

namespace Services.Services
{
    public class EnvioMedicinaService : IEnvioMedicinaService
    {
        private readonly AcnurContext _context;

        public EnvioMedicinaService(AcnurContext context)
        {
            _context = context;
        }
        public async Task<int> Add(DtoEnvioMedicina envioMedicina)
        {
            var parameter = new List<SqlParameter>();
            parameter.Add(new SqlParameter("@EsMedicina_Id", envioMedicina.MedicinaId));
            parameter.Add(new SqlParameter("@EsCantidad_Medicina", envioMedicina.CantidadMedicina));
            parameter.Add(new SqlParameter("@EsEnvio_Id", envioMedicina.EnvioId));

            var result = await Task.Run(() => _context.Database
           .ExecuteSqlRawAsync(@"exec SP_Insertar_EnvioMedicina @EsMedicina_Id, @EsCantidad_Medicina, @EsEnvio_Id",
                               parameter.ToArray()));
            return result;
        }

        public async Task<int> Delete(string Id)
        {
            return await Task.Run(() => _context.Database.ExecuteSqlInterpolatedAsync($"SP_Eliminar_EnvioMedicina {Id}"));
        }


        public async Task<List<EnvioMedicina>> Get()
        {
            return await _context.EnvioMedicinas
                .ToListAsync();
        }


    }
}

