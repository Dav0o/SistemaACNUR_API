using DataAccess.Model;
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
    public class MedicinaService : IMedicinaService
    {
        private readonly AcnurContext _context;

        public MedicinaService(AcnurContext context)
        {
            _context = context;
        }
        public async Task<List<Medicina>> Get()
        {
            return await _context.Medicinas
                .FromSqlRaw<Medicina>("SP_Listar_Medicinas")
                .ToListAsync();
        }
        public Task<int> Add(DtoMedicina medicina)
        {
            throw new NotImplementedException();
        }

        public Task<int> Delete(string Id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Medicina>> GetById(string Id)
        {
            throw new NotImplementedException();
        }

        public Task<int> Update(DtoMapping.DtoMedicina medicina)
        {
            throw new NotImplementedException();
        }
    }
}
