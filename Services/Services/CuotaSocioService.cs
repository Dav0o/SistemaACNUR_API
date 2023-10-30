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
    public class CuotaSocioService : ICuotaSocioService

    {
        private readonly AcnurContext _context;
        public CuotaSocioService(AcnurContext context)
        {
            _context = context;
        }

        public async Task<int> Add(DtoCuotaSocio cuotaSocio)
        {
            var parameter = new List<SqlParameter>();
            parameter.Add(new SqlParameter("@EsCuotaId", cuotaSocio.CuotaId)); 
            parameter.Add(new SqlParameter("@EsSocioId", cuotaSocio.SocioId)); 
            parameter.Add(new SqlParameter("@EsFechaPago", cuotaSocio.FechaPago)); 

            var result = await Task.Run(() => _context.Database.ExecuteSqlRawAsync(
                @"exec SP_Insertar_CuotaSocio @EsCuotaId, @EsSocioId, @EsFechaPago",
                parameter.ToArray()));
            return result;
        }


        public async Task<List<CuotaSocio>> Get()
        {
            return await _context.CuotaSocios.FromSqlRaw<CuotaSocio>("SP_Listar_CuotasSocios").ToListAsync();
        }


    }
}
