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
    public class ProfesionService : IProfesionService
    {
    
        private readonly AcnurContext _context;

        public ProfesionService(AcnurContext context)
        {
            _context = context;
        }

        public async Task<int> Add(DtoProfesion profesion)
        {
            var parameter = new List<SqlParameter>();
            parameter.Add(new SqlParameter("@EsId_Profesion", profesion.IdProfesion));
            parameter.Add(new SqlParameter("@EsNombreProfesion", profesion.NombreProfesion));
           
            var result = await Task.Run(() => _context.Database
            .ExecuteSqlRawAsync(@"exec SP_Insertar_Profesion @EsId_Profesion, @EsNombreProfesion",
            parameter.ToArray()));
            return result;
        }

        public async Task<int> Delete(string id)
        {
            return await Task.Run(() => _context.Database.ExecuteSqlInterpolatedAsync($"SP_Eliminar_Profesion {id}"));
        }

        public async Task<List<Profesion>> Get()
        {
            return await _context.Profesions.FromSqlRaw<Profesion>("SP_Listar_Profesiones").ToListAsync();
        }


        public async Task<int> Update(DtoProfesion profesion)
        {
            var parameter = new List<SqlParameter>();
            parameter.Add(new SqlParameter("@EsId_Profesion", profesion.IdProfesion));
            parameter.Add(new SqlParameter("@EsNombreProfesion", profesion.NombreProfesion));

            var result = await Task.Run(() => _context.Database.
            ExecuteSqlRawAsync(@"exec SP_Actualizar_Profesion @EsId_Profesion, @EsNombreProfesion",
            parameter.ToArray()));

            return result;
        }
    }
}

  