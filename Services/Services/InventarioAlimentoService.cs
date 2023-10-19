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

//Revisar por que algunos procedimientos todavia no estan

namespace Services.Services
{
    public class InventarioAlimentoService : IInventarioAlimentoService
    {
        private readonly AcnurContext _context;

        public InventarioAlimentoService(AcnurContext context)
        {
            _context = context;
        }

        public async Task<int> Add(DtoInventarioAlimento inventarioAlimento)
        {
            var parameter = new List<SqlParameter>();
            //parameter.Add(new SqlParameter("@EsId_InventarioAlimento", inventarioAlimento.IdInventarioAlimento));
            parameter.Add(new SqlParameter("@EsAlimentoId", inventarioAlimento.AlimentoId));
            parameter.Add(new SqlParameter("@AlmacenId", inventarioAlimento.AlmacenId));
            parameter.Add(new SqlParameter("@Cantidad", inventarioAlimento.Cantidad));

            var result = await Task.Run(() => _context.Database
            .ExecuteSqlRawAsync(@"exec SP_Insertar_Alimento_Inventario  @EsAlimentoId, @AlmacenId, @Cantidad",
            parameter.ToArray()));

            return result;
        }

        public async Task<int> Delete(int Id)
        {
            return await Task.Run(() => _context.Database.ExecuteSqlInterpolatedAsync($"SP_Eliminar_Alimento_Almacen {Id}"));
        }

        public async Task<List<InventarioAlimento>> Get()
        {
            return await _context.InventarioAlimentos
                .FromSqlRaw<InventarioAlimento>("SP_Listar_InventarioAlimento")
                .ToListAsync();
        }

        public async Task<IEnumerable<InventarioAlimento>> GetById(int Id)
        {
            var param = new SqlParameter("@EsId_InventarioAlimento", Id);

            var productDetails = await Task.Run(() => _context.InventarioAlimentos
                            .FromSqlRaw(@"exec SP_Obtener_InventarioAlimento @EsId_InventarioAlimento", param).ToListAsync());

            return productDetails;
        }

        public async Task<int> Update(DtoInventarioAlimento inventarioAlimento)
        {
            var parameter = new List<SqlParameter>();
            parameter.Add(new SqlParameter("@EsId_InventarioAlimento", inventarioAlimento.IdInventarioAlimento));
            parameter.Add(new SqlParameter("@EsAlimentoId", inventarioAlimento.AlimentoId));
            parameter.Add(new SqlParameter("@AlmacenId", inventarioAlimento.AlmacenId));
            parameter.Add(new SqlParameter("@Cantidad", inventarioAlimento.Cantidad));

            var result = await Task.Run(() => _context.Database
            .ExecuteSqlRawAsync(@"exec SP_Actualizar_AlimentoInventario @EsId_InventarioAlimento, @EsAlimentoId, @AlmacenId, @Cantidad",
            parameter.ToArray()));

            return result;
        }
    }
}
