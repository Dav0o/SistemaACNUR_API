using DataAccess.Model;
using Services.Extension;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Services.Extension.DtoMapping;

namespace Services.Services.IServices
{
    public interface IAlmacenService
    {
        public Task<List<Almacen>> Get();
        public Task<IEnumerable<Almacen>> GetById(string id);
        public Task<int> Add(DtoAlmacen almacen);
        public Task<int> Update(DtoAlmacen almacen);
        public Task<int> Delete(string id);
    }
}
