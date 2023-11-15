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
    public class EnvioSedeService: IEnvioSedeService
    {
        private readonly AcnurContext _context;

        public EnvioSedeService(AcnurContext context)
        {
            _context = context;
        }
        public async Task<int> Add(DtoEnvioSede envioSede)
        {
            var parameter = new List<SqlParameter>();
            parameter.Add(new SqlParameter("@ESede_Id", envioSede.SedeId));
            parameter.Add(new SqlParameter("@EsEnvio_Id", envioSede.IdEnvioSede));

            var result = await Task.Run(() => _context.Database
           .ExecuteSqlRawAsync(@"exec SP_Insertar_EnvioSede @ESede_Id, @EsEnvio_Id",
                               parameter.ToArray()));
            return result;
        }

        public async Task<int> Delete(string Id)
        {
            return await Task.Run(() => _context.Database.ExecuteSqlInterpolatedAsync($"SP_Eliminar_EnvioSede {Id}"));
        }


        public async Task<List<EnvioSede>> Get()
        {
            return await _context.EnvioSedes
                .ToListAsync();
        }


    }
}
