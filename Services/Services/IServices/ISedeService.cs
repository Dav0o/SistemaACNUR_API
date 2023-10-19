using DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Services.Extension.DtoMapping;

namespace Services.Services.IServices
{
    public interface ISedeService
    {
        public Task<List<Sede>> Get();
        public Task<IEnumerable<Sede>> GetById(string Id);
        public Task<int> Add(DtoSede sede);
        public Task<int> Update(DtoSede sede);
        public Task<int> Delete(string Id);
    }
}
