using DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Services.Extension.DtoMapping;

namespace Services.Services.IServices
{
    public interface IEnvioHumanitarioService
    {
        public Task<List<EnvioHumanitario>> Get();
        public Task<int> Add(DtoEnvioHumanitario envioHumanitario);
        public Task<int> Delete(string Id);
    }
}
