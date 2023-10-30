using DataAccess.Model;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
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
    public class VoluntarioSanitarioService: IVoluntarioSanitarioService
    {
        private readonly AcnurContext _context;

        public VoluntarioSanitarioService(AcnurContext context)
        {
            _context = context;
        }

        public async Task<int> Add(DtoVoluntarioSanitario voluntarioSanitario)
        {

            var parameter = new List<SqlParameter>();
            parameter.Add(new SqlParameter("@EsId_Voluntario_Sanitario", voluntarioSanitario.IdVoluntarioSanitario));
            parameter.Add(new SqlParameter("@EsDisponible", voluntarioSanitario.Disponible));
            parameter.Add(new SqlParameter("@EsUsuario_Dni", voluntarioSanitario.UsuarioDni));
            

            var result = await Task.Run(() => _context.Database
            .ExecuteSqlRawAsync(@"exec SP_Insertar_VoluntarioSanitario @EsId_Voluntario_Sanitario , @EsDisponible, @EsUsuario_Dni",
            parameter.ToArray()));
            return result;
        }

        public async Task<int> Delete(int id)
        {
            return await Task.Run(() => _context.Database.ExecuteSqlInterpolatedAsync($"SP_Eliminar_VoluntarioSanitario {id}"));
        }

        public async Task<List<VoluntarioSanitario>> Get()
        {
            return await _context.VoluntarioSanitarios.FromSqlRaw<VoluntarioSanitario>("SP_Listar_VoluntariosSanitarios").ToListAsync();
        }

        public async Task<int> Update(DtoVoluntarioSanitario voluntarioSanitario)
        {
            var parameter = new List<SqlParameter>();
            parameter.Add(new SqlParameter("@EsId_Voluntario_Sanitario", voluntarioSanitario.IdVoluntarioSanitario));
            parameter.Add(new SqlParameter("@EsDisponible", voluntarioSanitario.Disponible));
            parameter.Add(new SqlParameter("@EsUsuario_Dni", voluntarioSanitario.UsuarioDni));


            var result = await Task.Run(() => _context.Database
            .ExecuteSqlRawAsync(@"exec SP_Actualizar_VoluntarioSanitario @EsId_Voluntario_Sanitario , @EsDisponible, @EsUsuario_Dni",
            parameter.ToArray()));
            return result;
        }
    }
}
