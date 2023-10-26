using DataAccess.Model;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Services.Services.IServices;
using static Services.Extension.DtoMapping;

namespace Services.Services
{
 
        public class DireccionService :IDireccionService
        {
            private readonly AcnurContext _context;

            public DireccionService(AcnurContext context)
            {
                _context = context;
            }

            public async Task<int> Add(DtoDireccion direccion)
            {
                var parameter = new List<SqlParameter>();
                parameter.Add(new SqlParameter("@EsId_Direccion", direccion.IdDireccion));
                parameter.Add(new SqlParameter("@EsPais", direccion.Pais));
                parameter.Add(new SqlParameter("@EsCiudad", direccion.Ciudad));
                parameter.Add(new SqlParameter("@EsEstado", direccion.Estado));
                parameter.Add(new SqlParameter("@EsDireccion_Exacta", direccion.DireccionExacta));

                var result = await Task.Run(() => _context.Database
                .ExecuteSqlRawAsync(@"exec SP_Insertar_Direccion @EsId_Direccion, @EsPais, @EsCiudad, @EsEstado, @EsDireccion_Exacta",
                parameter.ToArray()));
                return result;
            }

            public async Task<int> Delete(string id)
            {
                return await Task.Run(() => _context.Database.ExecuteSqlInterpolatedAsync($"SP_Eliminar_Direccion {id}"));
            }

        public async Task<List<Direccion>> Get()
        {
            return await _context.Direccions.FromSqlRaw<Direccion>("SP_Listar_Direccion").ToListAsync();
            }

          

            public async Task<int> Update(DtoDireccion direccion)
            {
                var parameter = new List<SqlParameter>();
            parameter.Add(new SqlParameter("@EsId_Direccion", direccion.IdDireccion));
            parameter.Add(new SqlParameter("@EsPais", direccion.Pais));
            parameter.Add(new SqlParameter("@EsCiudad", direccion.Ciudad));
            parameter.Add(new SqlParameter("@EsEstado", direccion.Estado));
            parameter.Add(new SqlParameter("@EsDireccion_Exacta", direccion.DireccionExacta));

            var result = await Task.Run(() => _context.Database
            .ExecuteSqlRawAsync(@"exec SP_Actualizar_Direccion @EsId_Direccion, @EsPais, @EsCiudad, @EsEstado, @EsDireccion_Exacta",
            parameter.ToArray()));
            return result;
        }
        }
    }


