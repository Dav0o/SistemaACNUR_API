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
    public class RolService : IRolService
    { 
        private readonly AcnurContext _context;

        public RolService(AcnurContext context)
        {
            _context = context;
        }

        public async Task<int> Add(DtoRol rol)
        {
            var parameter = new List<SqlParameter>();
            parameter.Add(new SqlParameter("@EsId_Rol", rol.IdRol));
            parameter.Add(new SqlParameter("@EsNombreRol", rol.NombreRol));
            parameter.Add(new SqlParameter("@EsDescripcionRol",rol.DescripcionRol ));
           

            var result = await Task.Run(() => _context.Database
            .ExecuteSqlRawAsync(@"exec SP_Insertar_Rol @EsId_Rol, @EsNombreRol, @EsDescripcionRol",
            parameter.ToArray()));
            return result;
        }

       
        public async Task<int> Delete(string id)
        {
            return await Task.Run(() => _context.Database.ExecuteSqlInterpolatedAsync($"SP_Eliminar_Rol {id}"));
        }

        public async Task<List<Rol>> Get()
        {
            return await _context.Rols.FromSqlRaw<Rol>("SP_Listar_Rol").ToListAsync();
        }



        public async Task<int> Update(DtoRol rol)
        {
            var parameter = new List<SqlParameter>();
            parameter.Add(new SqlParameter("@EsId_Rol", rol.IdRol));
            parameter.Add(new SqlParameter("@EsNombreRol", rol.NombreRol));
            parameter.Add(new SqlParameter("@EsDescripcionRol", rol.DescripcionRol));


            var result = await Task.Run(() => _context.Database
            .ExecuteSqlRawAsync(@"exec SP_Actualizar_Rol @EsId_Rol, @EsNombreRol, @EsDescripcionRol",
            parameter.ToArray()));
            return result;
        }

       
    }
}


