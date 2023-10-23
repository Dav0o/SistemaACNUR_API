using DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Services.Extension.DtoMapping;

namespace Services.Services.IServices
{
    public interface IDireccionService
    {
        public Task<List<Direccion>> Get();
        public Task<int> Add(DtoDireccion direccion);
        public Task<int> Update(DtoDireccion direccion);
        public Task<int> Delete(string id);
    }
}
