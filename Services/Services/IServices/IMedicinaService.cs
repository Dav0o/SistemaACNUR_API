
using DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Services.Extension.DtoMapping;

namespace Services.Services.IServices
{
    public interface IMedicinaService
    {
        public Task<List<Medicina>> Get();
        public Task<IEnumerable<Medicina>> GetById(string Id);
        public Task<int> Add(DtoMedicina medicina);
        public Task<int> Update(DtoMedicina medicina);
        public Task<int> Delete(string Id);
    }
}
