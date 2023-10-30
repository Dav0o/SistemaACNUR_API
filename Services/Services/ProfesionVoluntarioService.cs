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
    public class ProfesionVoluntarioService: IProfesionVoluntarioService
    {
        private readonly AcnurContext _context;

        public ProfesionVoluntarioService(AcnurContext context)
        {
            _context = context;
        }

        public async Task<int> Add(DtoProfesionVoluntario profesionVoluntario)
        {
            var parameter = new List<SqlParameter>();
            parameter.Add(new SqlParameter("@EsVoluntarioSanitario_Id", profesionVoluntario.VoluntarioSanitarioId));
            parameter.Add(new SqlParameter("@EsProfesion_Id", profesionVoluntario.ProfesionId ));


            var result = await Task.Run(() => _context.Database
           .ExecuteSqlRawAsync(@"exec SP_Insertar_ProfesionVoluntario @EsVoluntarioSanitario_Id, @EsProfesion_Id",
                               parameter.ToArray()));
            return result;
        }


        public async Task<int> Delete(int VoluntarioSanitarioId, string ProfesionId)
        {
            return await _context.Database.ExecuteSqlRawAsync("exec SP_Eliminar_ProfesionVoluntario @EsVoluntarioSanitario_Id, @EsProfesion_Id",
                new SqlParameter("@EsVoluntarioSanitario_Id", VoluntarioSanitarioId),
                new SqlParameter("@EsProfesion_Id", ProfesionId));
        }

        public async Task<List<ProfesionVoluntario>> Get()
        {
            return await _context.ProfesionVoluntarios
                .FromSqlRaw<ProfesionVoluntario>("SP_Listar_ProfesionVoluntario")
                .ToListAsync();
        }



    }
}