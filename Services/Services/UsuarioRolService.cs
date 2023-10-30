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
    public class UsuarioRolService: IUsuarioRolService
    {
       
        private readonly AcnurContext _context;

        public UsuarioRolService(AcnurContext context)
        {
            _context = context;
        }

        public async Task<int> Add(DtoUsuarioRol usuarioRol)
        {
            var parameter = new List<SqlParameter>();
            parameter.Add(new SqlParameter("@EsUsuarioDni", usuarioRol.UsuarioDni));
            parameter.Add(new SqlParameter("@EsRolId", usuarioRol.RolId));
        

            var result = await Task.Run(() => _context.Database
           .ExecuteSqlRawAsync(@"exec SP_Insertar_UsuarioRol @EsUsuarioDni, @EsRolId",
                               parameter.ToArray()));
            return result;
        }


        public async Task<int> Delete(int usuarioDni, string rolId)
        {
            return await _context.Database.ExecuteSqlRawAsync("exec SP_Eliminar_UsuarioRol @EsUsuarioDni, @EsRolId",
                new SqlParameter("@EsUsuarioDni", usuarioDni),
                new SqlParameter("@EsRolId", rolId));
        }

        public async Task<List<UsuarioRol>> Get()
        {
            return await _context.UsuarioRols
                .FromSqlRaw<UsuarioRol>("SP_Listar_UsuarioRol")
                .ToListAsync();
        }

     
       
    }
}

    