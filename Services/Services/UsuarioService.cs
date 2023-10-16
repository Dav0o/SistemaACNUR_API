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
    public class UsuarioService : IUsuarioService
    {

        private readonly AcnurContext _context;

        public UsuarioService(AcnurContext context)
        {
            _context = context;
        }

        //error: convert de vchar a int; quien sabe donde ¡?
        public async Task<int> Add(DtoUsuario usuario)
        {
            var parameter = new List<SqlParameter>();
            parameter.Add(new SqlParameter("@EsDni_Usuario", usuario.DniUsuario));
            parameter.Add(new SqlParameter("@EsNombreUsuario", usuario.NombreUsuario));
            parameter.Add(new SqlParameter("@EsApellido1", usuario.Apellido1));
            parameter.Add(new SqlParameter("@EsApellido2", usuario.Apellido2));
            parameter.Add(new SqlParameter("@EsCorreo",usuario.Correo));
            parameter.Add(new SqlParameter("@EsClave", usuario.Clave));
            parameter.Add(new SqlParameter("@EsDirecion", usuario.Direccion));
            parameter.Add(new SqlParameter("@EsTelefono", usuario.Telefono));
            parameter.Add(new SqlParameter("@EsSede_Id", usuario.SedeId));

            var result = await Task.Run(() => _context.Database
           .ExecuteSqlRawAsync(@"exec SP_Insertar_Usuario @EsDni_Usuario, @EsNombreUsuario, @EsApellido1, @EsApellido2,
                                    @EsCorreo, @EsClave, @EsDirecion, @EsTelefono, @EsSede_Id",
                               parameter.ToArray()));
            return result;
        }

        //conflicto al borrar(idk si esta bien)
        public async Task<int> Delete(int DniUsuario)
        {
            return await Task.Run(() => _context.Database.ExecuteSqlInterpolatedAsync($"SP_Eliminar_Usuario {DniUsuario}"));
        }

        public async Task<List<Usuario>> Get()
        {
            return await _context.Usuarios
                .FromSqlRaw<Usuario>("SP_Listar_Usuarios")
                .ToListAsync();
        }



        //falta PA
        public async Task<IEnumerable<Usuario>> GetById(int DniUsuario)
        {
            var param = new SqlParameter("@EsDni_Usuario", DniUsuario);

            var productDetails = await Task.Run(() => _context.Usuarios
                            .FromSqlRaw(@"exec SP_Obtener_Usuario @EsDni_Usuario", param).ToListAsync());

            return productDetails;
        }

        //bug
        public async Task<int> Update(DtoUsuario usuario)
        {
            var parameter = new List<SqlParameter>();
            parameter.Add(new SqlParameter("@EsDni_Usuario", usuario.DniUsuario));
            parameter.Add(new SqlParameter("@EsNombreUsuario", usuario.NombreUsuario));
            parameter.Add(new SqlParameter("@EsApellido1", usuario.Apellido1));
            parameter.Add(new SqlParameter("@EsApellido2", usuario.Apellido2));
            parameter.Add(new SqlParameter("@EsCorreo", usuario.Correo));
            parameter.Add(new SqlParameter("@EsClave", usuario.Clave));
            parameter.Add(new SqlParameter("@EsDirecion", usuario.Direccion));
            parameter.Add(new SqlParameter("@EsTelefono", usuario.Telefono));
            parameter.Add(new SqlParameter("@EsSede_Id", usuario.SedeId));

            var result = await Task.Run(() => _context.Database
           .ExecuteSqlRawAsync(@"exec SP_Actualizar_Usuario @EsDni_Usuario, @EsNombreUsuario, @EsApellido1, @EsApellido2,
                                    @EsCorreo, @EsClave, @EsDirecion, @EsTelefono, @EsSede_Id",
                               parameter.ToArray()));
            return result;
        }
    }
}
