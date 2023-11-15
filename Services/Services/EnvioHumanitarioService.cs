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
    public class EnvioHumanitarioService : IEnvioHumanitarioService
    {
        private readonly AcnurContext _context;

        public EnvioHumanitarioService(AcnurContext context)
        {
            _context = context;
        }
        public async Task<int> Add(DtoEnvioHumanitario envioHumanitario)
        {
            var parameter = new List<SqlParameter>();
            parameter.Add(new SqlParameter("@EsVoluntario_Sanitario_Id", envioHumanitario.VoluntarioSanitarioId));
            parameter.Add(new SqlParameter("@EsEnvio_Id", envioHumanitario.EnvioId));

            var result = await Task.Run(() => _context.Database
           .ExecuteSqlRawAsync(@"exec SP_Insertar_EnvioHumanitario @EsVoluntario_Sanitario_Id, @EsEnvio_Id",
                               parameter.ToArray()));
            return result;
        }

        public async Task<int> Delete(string Id)
        {
            return await Task.Run(() => _context.Database.ExecuteSqlInterpolatedAsync($"SP_Eliminar_EnvioHumanitario {Id}"));
        }


        public async Task<List<EnvioHumanitario>> Get()
        {
            return await _context.EnvioHumanitarios
                .ToListAsync();
        }


    }
}

    