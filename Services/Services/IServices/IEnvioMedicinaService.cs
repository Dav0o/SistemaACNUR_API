using DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Services.Extension.DtoMapping;

namespace Services.Services.IServices
{
    public interface IEnvioMedicinaService
    {
        public Task<List<EnvioMedicina>> Get();
        public Task<int> Add(DtoEnvioMedicina envioMedicina);
        public Task<int> Delete(string Id);
    }
}
