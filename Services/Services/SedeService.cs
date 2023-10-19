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
    public class SedeService : ISedeService
    {
        private readonly AcnurContext _context;

        public SedeService(AcnurContext context)
        {
            _context = context;
        }

        public async Task<int> Add(DtoSede sede)
        {
            var parameter = new List<SqlParameter>();
            parameter.Add(new SqlParameter("@EsId_Sede", sede.IdSede));
            parameter.Add(new SqlParameter("@EsDireccion_Id", sede.DireccionId));

            var result = await Task.Run(() => _context.Database
           .ExecuteSqlRawAsync(@"exec SP_Insertar_Sede @EsId_Sede, @EsDireccion_Id",
                               parameter.ToArray()));
            return result;
        }


        //Choca con usuario(creo que esta bien)
        public async Task<int> Delete(string Id)
        {
            return await Task.Run(() => _context.Database.ExecuteSqlInterpolatedAsync($"SP_Eliminar_Sede {Id}"));
        }

        public async Task<List<Sede>> Get()
        {
            return await _context.Sedes
               .FromSqlRaw<Sede>("SP_Listar_Sedes")
               .ToListAsync();
        }

        //Falta el PA
        public async Task<IEnumerable<Sede>> GetById(string Id)
        {
            var param = new SqlParameter("@EsId_Sede", Id);

            var productDetails = await Task.Run(() => _context.Sedes
                            .FromSqlRaw(@"exec SP_Obtener_Sede @EsId_Sede", param).ToListAsync());

            return productDetails;
        }

        public async Task<int> Update(DtoSede sede)
        {
            var parameter = new List<SqlParameter>();
            parameter.Add(new SqlParameter("@EsId_Sede", sede.IdSede));
            parameter.Add(new SqlParameter("@EsDireccion_Id", sede.DireccionId));

            var result = await Task.Run(() => _context.Database
           .ExecuteSqlRawAsync(@"exec SP_Actualizar_Sede @EsId_Sede, @EsDireccion_Id",
                               parameter.ToArray()));
            return result;
        }
    }
}
