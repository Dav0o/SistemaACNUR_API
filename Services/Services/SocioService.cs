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
    public class SocioService : ISocioService
    {
        private readonly AcnurContext _context;
       
        public SocioService(AcnurContext context)
        {
            _context = context;
        }

        public async Task<int> Add(DtoSocio socio)
        {
            
            var parameter = new List<SqlParameter>();
            parameter.Add(new SqlParameter("@EsId_Socio", socio.IdSocio));
            parameter.Add(new SqlParameter("@EsCuenta_Banco", socio.CuentaBanco));
            parameter.Add(new SqlParameter("@EsUsuarioDni", socio.UsuarioDni));
            parameter.Add(new SqlParameter("@EsCuota_Id", socio.CuotaId));

            var result = await Task.Run(() => _context.Database
            .ExecuteSqlRawAsync(@"exec SP_Insertar_Socio @EsId_Socio, @EsCuenta_Banco, @EsUsuarioDni, @EsCuota_Id ",
            parameter.ToArray()));
            return result;
        }

        public async Task<int> Delete(int id)
        {
            return await Task.Run(() => _context.Database.ExecuteSqlInterpolatedAsync($"SP_Eliminar_Socio {id}"));
        }

        public async Task<List<Socio>> Get()
        {
            return await _context.Socios.FromSqlRaw<Socio>("SP_Listar_Socios").ToListAsync();
        }

        public async Task<int> Update(DtoSocio socio)
        {
            var parameter = new List<SqlParameter>();
            parameter.Add(new SqlParameter(" @EsId_Socio", socio.IdSocio));
            parameter.Add(new SqlParameter("@EsCuenta_Banco", socio.CuentaBanco));
            parameter.Add(new SqlParameter("@EsUsuarioDni", socio.UsuarioDni));
            parameter.Add(new SqlParameter("@EsCuota_Id", socio.CuotaId));

            var result = await Task.Run(() => _context.Database
            .ExecuteSqlRawAsync(@"exec SP_Actualizar_Socio @EsId_Socio, @EsCuenta_Banco, @EsUsuarioDni, @EsCuota_Id ",
            parameter.ToArray()));
            return result;
        }
    }
}
