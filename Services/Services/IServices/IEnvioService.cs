using DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Services.Extension.DtoMapping;

namespace Services.Services.IServices
{
    public interface IEnvioService
    {
        public Task<List<Envio>> Get();
        public Task<IEnumerable<Envio>> GetById(int Id);
        public Task<int> Add(DtoEnvio envio);
        public Task<int> Update(DtoEnvio envio);
        public Task<int> Delete(int Id);
    }
}
