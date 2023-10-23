using DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Services.Extension.DtoMapping;

namespace Services.Services.IServices
{
    public interface ISocioService
    {
        public Task<List<Socio>> Get();
        public Task<int> Add(DtoSocio socio);
        public Task<int> Update(DtoSocio socio);
        public Task<int> Delete(int Id);
    }
}
