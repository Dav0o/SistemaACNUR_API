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
    public class CuotaService : ICuotaService
    {
        private readonly AcnurContext _context;

        public CuotaService(AcnurContext context)
        {
            _context = context;
        }

        public async Task<int> Add(DtoCuota cuota)
        {
            var parameter = new List<SqlParameter>();
            parameter.Add(new SqlParameter("@EsId_Cuota", cuota.IdCuota));
            parameter.Add(new SqlParameter("@EsCargos_Anuales", cuota.CargosAnuales));
            parameter.Add(new SqlParameter("@EsTipo_Cuota", cuota.TipoCuota));

            var result = await Task.Run(() => _context.Database
            .ExecuteSqlRawAsync(@"exec SP_Insertar_Cuota @EsId_Cuota, @EsCargos_Anuales, @EsTipo_Cuota",
            parameter.ToArray()));
            return result;
        }

        public async Task<int> Delete(int id)
        {
            return await Task.Run(() => _context.Database.ExecuteSqlInterpolatedAsync($"SP_Eliminar_Cuota {id}"));
        }

        public async Task<List<Cuotum>> Get()
        {
            return await _context.Cuota.FromSqlRaw<Cuotum>("SP_Listar_Cuotas").ToListAsync();
        }


        //public async Task<int> Update(DtoCuota cuota)
        //{
        //    var parameter = new List<SqlParameter>();
        //    parameter.Add(new SqlParameter("@EsId_Cuota", cuota.IdCuota));
        //    parameter.Add(new SqlParameter("@EsCargos_Anuales", cuota.CargosAnuales));
        //    parameter.Add(new SqlParameter("@EsTipo_Cuota", cuota.TipoCuota));

        //    var result = await Task.Run(() => _context.Database
        //    .ExecuteSqlRawAsync(@"exec SP_Actualizar_Cuota @EsId_Cuota, @EsCargos_Anuales, @EsTipo_Cuota",
        //    parameter.ToArray()));
        //    return result;
        //}
    }
}

 