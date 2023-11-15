using DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Services.Extension.DtoMapping;

namespace Services.Services.IServices
{
   public interface IEnvioAlimentoService
    {
        public Task<List<EnvioAlimento>> Get();
        public Task<int> Add(DtoEnvioAlimento envioAlimento);
        public Task<int> Delete(string Id);
    }
}
