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
    public class MedicinaService : IMedicinaService
    {
        private readonly AcnurContext _context;

        public MedicinaService(AcnurContext context)
        {
            _context = context;
        }
        public async Task<List<Medicina>> Get()
        {
            return await _context.Medicinas
                .FromSqlRaw<Medicina>("SP_Listar_Medicinas")
                .ToListAsync();
        }
        public async Task<int> Add(DtoMedicina medicina)
        {
            var parameter = new List<SqlParameter>();
            parameter.Add(new SqlParameter("@EsId_Medicina", medicina.IdMedicina));
            parameter.Add(new SqlParameter("@EsNombreMedicina", medicina.NombreMedicina));
            parameter.Add(new SqlParameter("@EsFechaVencimiento", medicina.FechaVencimiento));
            

            var result = await Task.Run(() => _context.Database
           .ExecuteSqlRawAsync(@"exec SP_Insertar_Medicina @EsId_Medicina, @EsNombreMedicina, @EsFechaVencimiento",
                               parameter.ToArray()));
            return result;
        }

        public async Task<int> Delete(string Id)
        {
            return await Task.Run(() => _context.Database.ExecuteSqlInterpolatedAsync($"SP_Eliminar_Medicina {Id}"));
        }

        public Task<IEnumerable<Medicina>> GetById(string Id)
        {
            throw new NotImplementedException();
        }

        public async Task<int> Update(DtoMapping.DtoMedicina medicina)
        {
            var parameter = new List<SqlParameter>();
            parameter.Add(new SqlParameter("@EsId_Medicina", medicina.IdMedicina));
            parameter.Add(new SqlParameter("@EsNombreMedicina", medicina.NombreMedicina));
            parameter.Add(new SqlParameter("@EsFechaVencimiento", medicina.FechaVencimiento));

            var result = await Task.Run(() => _context.Database
           .ExecuteSqlRawAsync(@"exec SP_Actualizar_Medicina @EsId_Medicina, @EsNombreMedicina, @EsFechaVencimiento",
                               parameter.ToArray()));
            return result;
        }
    }
}
