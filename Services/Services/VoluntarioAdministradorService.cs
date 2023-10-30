
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
    public class VoluntarioAdministradorService : IVoluntarioAdministradorService
    {

        private readonly AcnurContext _context;

        public VoluntarioAdministradorService(AcnurContext context)
        {
            _context = context;
        }

        public async Task<int> Add(DtoVoluntarioAdministrador voluntarioAdministrador)
        {
            var parameter = new List<SqlParameter>();
            parameter.Add(new SqlParameter("@EsId_Voluntario_Administrador ", voluntarioAdministrador.IdVoluntarioAdministrador));
            parameter.Add(new SqlParameter("@EsUsuario_Dni ", voluntarioAdministrador.UsuarioDni));


            var result = await Task.Run(() => _context.Database
           .ExecuteSqlRawAsync(@"exec SP_Insertar_VoluntarioAdmin @EsId_Voluntario_Administrador, @EsUsuario_Dni",
            parameter.ToArray()));
            return result;
        }

        public async Task<int> Delete(int id)
        {
            return await Task.Run(() => _context.Database.ExecuteSqlInterpolatedAsync($"SP_Eliminar_VoluntarioAdmin {id}"));
        }


        public async Task<List<VoluntarioAdministrador>> Get()
        {
            return await _context.VoluntarioAdministradors
                .FromSqlRaw<VoluntarioAdministrador>("SP_Listar_VoluntariosAdmin")
                .ToListAsync();
        }

    }

}