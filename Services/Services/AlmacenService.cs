using DataAccess.Model;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Services.Extension;
using Services.Services.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using static Services.Extension.DtoMapping;

namespace Services.Services
{
    public class AlmacenService : IAlmacenService
    {
        private readonly AcnurContext _context;

        public AlmacenService(AcnurContext context)
        {
            _context = context;
        }

        public async Task<int> Add(DtoAlmacen almacen)
        {
            var parameter = new List<SqlParameter>();
            parameter.Add(new SqlParameter("@EsId_Almacen", almacen.IdAlmacen));
            parameter.Add(new SqlParameter("@EsNombreAlmacen", almacen.NombreAlmacen));
            parameter.Add(new SqlParameter("@EsDescripcionAlmacen", almacen.DescripcionAlmacen));
            parameter.Add(new SqlParameter("@EsSedeId", almacen.SedeId));

            var result = await Task.Run(() => _context.Database
            .ExecuteSqlRawAsync(@"exec SP_Insertar_Almacen @EsId_Almacen, @EsNombreAlmacen, @EsDescripcionAlmacen, @EsSedeId",
            parameter.ToArray()));
            return result;
        }

        public async Task<int> Delete(string id)
        {
            return await Task.Run(() => _context.Database.ExecuteSqlInterpolatedAsync($"SP_Eliminar_Almacen {id}"));
        }

        public async Task<List<Almacen>> Get()
        {
            return await _context.Almacens.FromSqlRaw<Almacen>("SP_Listar_Almacen").ToListAsync();
        }

        public async Task<IEnumerable<Almacen>> GetById(string Id)
        {
            var param = new SqlParameter("@Es_Id_Almacen", Id);

            var productDetails = await Task.Run(() => _context.Almacens.FromSqlRaw(@"exec SP_Obtener_Almacen", param).ToListAsync());

            return productDetails;
        }

        public async Task<int> Update(DtoAlmacen almacen)
        {
            var parameter = new List<SqlParameter>();
            parameter.Add(new SqlParameter("@EsId_Almacen", almacen.IdAlmacen));
            parameter.Add(new SqlParameter("@EsNombreAlmacen", almacen.NombreAlmacen));
            parameter.Add(new SqlParameter("@EsDescripcionAlmacen", almacen.DescripcionAlmacen));
            parameter.Add(new SqlParameter("@EsSedeId", almacen.SedeId));

            var result = await Task.Run(() => _context.Database.
            ExecuteSqlRawAsync(@"exec SP_Actualizar_Almacen @EsId_Almacen, @EsNombreAlmacen, @EsDescripcionAlmacen, @EsSedeId",
            parameter.ToArray()));

            return result;
        }
    }
}
