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
    public class EnvioAlimentoService : IEnvioAlimentoService
    {
        private readonly AcnurContext _context;

        public EnvioAlimentoService(AcnurContext context)
        {
            _context = context;
        }
        public async Task<int> Add(DtoEnvioAlimento envioAlimento)
        {
            var parameter = new List<SqlParameter>();
            parameter.Add(new SqlParameter("@EsId_Alimento", envioAlimento.AlimentoId));
            parameter.Add(new SqlParameter("@EsCantidad_Alimento", envioAlimento.CantidadAlimento ));
            parameter.Add(new SqlParameter("@EsEnvio_Id", envioAlimento.EnvioId));
          
            var result = await Task.Run(() => _context.Database
           .ExecuteSqlRawAsync(@"exec SP_Insertar_EnvioAlimento @EsId_Alimento, @EsCantidad_Alimento, @EsEnvio_Id",
                               parameter.ToArray()));
            return result;
        }

        public async Task<int> Delete(string Id)
        {
            return await Task.Run(() => _context.Database.ExecuteSqlInterpolatedAsync($"SP_Eliminar_EnvioAlimento {Id}"));
        }


        public async Task<List<EnvioAlimento>> Get()
        {
            return await _context.EnvioAlimentos
                .ToListAsync();
        }


    }
}
