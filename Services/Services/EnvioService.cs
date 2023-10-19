using DataAccess.Model;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Services.Extension;
using Services.Services.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Services.Extension.DtoMapping;

namespace Services.Services
{
    
    public class EnvioService : IEnvioService
    {
        private readonly AcnurContext _context;

        public EnvioService(AcnurContext context)
        {
            _context = context;
        }

        public async Task<int> Add(DtoEnvio envio)
        {
            var parameter = new List<SqlParameter>();
            parameter.Add(new SqlParameter("@EsDestino", envio.Destino));
            parameter.Add(new SqlParameter("@EsFechaEnvio", envio.FechaEnvio));
            parameter.Add(new SqlParameter("@EsTipoAyuda", envio.TipoAyuda));
            parameter.Add(new SqlParameter("@EsCantidad", envio.Cantidad));
            parameter.Add(new SqlParameter("@EsUnidadMedidaId", envio.UnidadMedidaId));

            var result = await Task.Run(() => _context.Database
            .ExecuteSqlRawAsync(@"exec SP_Insertar_Envio @EsDestino, @EsFechaEnvio, @EsTipoAyuda, @EsCantidad, @EsUnidadMedidaId",
            parameter.ToArray()));

            return result;
        }

        public async Task<int> Delete(int Id)
        {
            return await Task.Run(() => _context.Database.ExecuteSqlInterpolatedAsync($"SP_Eliminar_Envio {Id}"));
        }

        public async Task<List<Envio>> Get()
        {
            return await _context.Envios
               .FromSqlRaw<Envio>("SP_Listar_Envios")
               .ToListAsync();
        }

        public async Task<IEnumerable<Envio>> GetById(int Id)
        {
            var param = new SqlParameter("@Es_Id_Envio", Id);

            var productDetails = await Task.Run(() => _context.Envios.FromSqlRaw(@"exec SP_Obtener_Envio", param).ToListAsync());

            return productDetails;
        }

        public async Task<int> Update(DtoEnvio envio)
        {
            var parameter = new List<SqlParameter>();
            parameter.Add(new SqlParameter("@Es_Id_Envio", envio.IdEnvio));
            parameter.Add(new SqlParameter("@EsDestino", envio.Destino));
            parameter.Add(new SqlParameter("@EsFechaEnvio", envio.FechaEnvio));
            parameter.Add(new SqlParameter("@EsTipoAyuda", envio.TipoAyuda));
            parameter.Add(new SqlParameter("@EsCantidad", envio.Cantidad));
            parameter.Add(new SqlParameter("@EsUnidadMedidaId", envio.UnidadMedidaId));

            var result = await Task.Run(() => _context.Database
            .ExecuteSqlRawAsync(@"exec SP_Actualizar_Envio @Es_Id_Envio, @EsDestino, @EsFechaEnvio, @EsTipoAyuda, @EsCantidad, @EsUnidadMedidaId",
            parameter.ToArray()));

            return result;
        }
    }
}
