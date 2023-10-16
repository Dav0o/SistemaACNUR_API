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
    public class InventarioMedicinaService : IInventarioMedicinaService
    {
        private readonly AcnurContext _context;

        public InventarioMedicinaService(AcnurContext context)
        {
            _context = context;
        }

        public  async Task<int> Add(DtoInventarioMedicina inventarioMedicina)
        {
            var parameter = new List<SqlParameter>();
            parameter.Add(new SqlParameter("@EsMedicina_Id", inventarioMedicina.MedicinaId));
            parameter.Add(new SqlParameter("@EsAlmacen_Id", inventarioMedicina.AlmacenId));
            parameter.Add(new SqlParameter("@Cantidad", inventarioMedicina.Cantidad));

            var result = await Task.Run(() => _context.Database
           .ExecuteSqlRawAsync(@"exec SP_Insertar_Medicina_Inventario @EsMedicina_Id, @EsAlmacen_Id, @Cantidad",
                               parameter.ToArray()));
            return result;
        }

        //falta el PA
        public async Task<int> Delete(int Id)
        {
            return await Task.Run(() => _context.Database.ExecuteSqlInterpolatedAsync($"SP_Eliminar_MedicinaInventario {Id}"));
        }

        public async Task<List<InventarioMedicina>> Get()
        {
            return await _context.InventarioMedicinas
                .FromSqlRaw<InventarioMedicina>("SP_Listar_InventarioMedicina")
                .ToListAsync();
        }

        //Falta el PA
        public async Task<IEnumerable<InventarioMedicina>> GetById(int Id)
        {
            var param = new SqlParameter("@EsId_InventarioMedicina", Id);

            var productDetails = await Task.Run(() => _context.InventarioMedicinas
                            .FromSqlRaw(@"exec SP_Obtener_InventarioMedicina @EsId_InventarioMedicina", param).ToListAsync());

            return productDetails;
        }

        //Falta el PA
        public async Task<int> Update(DtoInventarioMedicina inventarioMedicina)
        {
            var parameter = new List<SqlParameter>();
            parameter.Add(new SqlParameter("@EsMedicina_Id", inventarioMedicina.MedicinaId));
            parameter.Add(new SqlParameter("@EsAlmacen_Id", inventarioMedicina.AlmacenId));
            parameter.Add(new SqlParameter("@Cantidad", inventarioMedicina.Cantidad));

            var result = await Task.Run(() => _context.Database
           .ExecuteSqlRawAsync(@"exec SP_Actualizar_Medicina_Inventario @EsMedicina_Id, @EsAlmacen_Id, @Cantidad",
                               parameter.ToArray()));
            return result;
        }
    }
}
