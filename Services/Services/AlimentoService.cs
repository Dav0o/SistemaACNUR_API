
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
    public class AlimentoService : IAlimentoService
    {
        private readonly AcnurContext _context;

        public AlimentoService(AcnurContext context)
        {
            _context = context;
        }
        public async Task<int> Add(DtoAlimento alimento)
        {
            var parameter = new List<SqlParameter>();
            parameter.Add(new SqlParameter("@EsId_Alimento", alimento.IdAlimento));
            parameter.Add(new SqlParameter("@EsNombreAlimento", alimento.NombreAlimento));
            parameter.Add(new SqlParameter("@EsFechaVencimiento", alimento.FechaVencimiento));
            parameter.Add(new SqlParameter("@EsPeso_KG", alimento.PesoKg));

            var result = await Task.Run(() => _context.Database
           .ExecuteSqlRawAsync(@"exec SP_Insertar_Alimento @EsId_Alimento, @EsNombreAlimento, @EsFechaVencimiento, @EsPeso_KG",
                               parameter.ToArray()));
            return result;
        }

        public async Task<int> Delete(string Id)
        {
            return await Task.Run(() => _context.Database.ExecuteSqlInterpolatedAsync($"SP_Eliminar_Alimento {Id}"));
        }


        public async Task<List<Alimento>> Get()
        {
            return await _context.Alimentos
                .FromSqlRaw<Alimento>("SP_Listar_Alimentos")
                .ToListAsync();
        }

        public async Task<int> Update(DtoAlimento alimento)
        {
            var parameter = new List<SqlParameter>();
            parameter.Add(new SqlParameter("@EsId_Alimento", alimento.IdAlimento));
            parameter.Add(new SqlParameter("@EsNombreAlimento", alimento.NombreAlimento));
            parameter.Add(new SqlParameter("@EsFechaVencimiento", alimento.FechaVencimiento));
            parameter.Add(new SqlParameter("@EsPeso_KG", alimento.PesoKg));

            var result = await Task.Run(() => _context.Database
           .ExecuteSqlRawAsync(@"exec SP_Actualizar_Alimento @EsId_Alimento, @EsNombreAlimento, @EsFechaVencimiento, @EsPeso_KG",
                               parameter.ToArray()));
            return result;
        }

        public async Task<IEnumerable<Alimento>> GetById(string Id)
        {
            var param = new SqlParameter("@EsId_Alimento", Id);

            var productDetails = await Task.Run(() => _context.Alimentos
                            .FromSqlRaw(@"exec SP_Obtener_Alimento @EsId_Alimento", param).ToListAsync());

            return productDetails;
        }
    }
}
