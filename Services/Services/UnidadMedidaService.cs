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
    public class UnidadMedidaService : IUnidadMedidaService
    {
        private readonly AcnurContext _context;

        public UnidadMedidaService(AcnurContext context)
        {
            _context = context;
        }
        public async Task<int> Add(DtoUnidadMedida unidadMedida)
        {
            var parameter = new List<SqlParameter>();
            parameter.Add(new SqlParameter("@EsId_UnidadMedida", unidadMedida.IdUnidadMedida));
            parameter.Add(new SqlParameter("@EsUnidad", unidadMedida.Unidad));
           

            var result = await Task.Run(() => _context.Database
           .ExecuteSqlRawAsync(@"exec SP_Insertar_UnidadMedida @EsId_UnidadMedida, @EsUnidad",
                               parameter.ToArray()));
            return result;
        }

        public async Task<int> Delete(string Id)
        {
            return await Task.Run(() => _context.Database.ExecuteSqlInterpolatedAsync($"SP_Eliminar_UnidadMedida {Id}"));
        }

        public async Task<List<UnidadMedidum>> Get()
        {
            return await _context.UnidadMedida
                 .FromSqlRaw<UnidadMedidum>("SP_Listar_UnidadMedida")
                 .ToListAsync();
        }


        //falta el PA
        public async Task<IEnumerable<UnidadMedidum>> GetById(string Id)
        {
            var param = new SqlParameter("@EsId_UnidadMedida", Id);

            var productDetails = await Task.Run(() => _context.UnidadMedida
                            .FromSqlRaw(@"exec SP_Obtener_UnidadMedida @EsId_UnidadMedida", param).ToListAsync());

            return productDetails;
        }


        //Falta el PA
        public async Task<int> Update(DtoUnidadMedida unidadMedida)
        {
            var parameter = new List<SqlParameter>();
            parameter.Add(new SqlParameter("@EsId_UnidadMedida", unidadMedida.IdUnidadMedida));
            parameter.Add(new SqlParameter("@EsUnidad", unidadMedida.Unidad));


            var result = await Task.Run(() => _context.Database
           .ExecuteSqlRawAsync(@"exec SP_Actualizar_UnidadMedida @EsId_UnidadMedida, @EsUnidad",
                               parameter.ToArray()));
            return result;
        }
    }
}
