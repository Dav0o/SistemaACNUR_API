using DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Services.Extension.DtoMapping;

namespace Services.Services.IServices
{
    public interface IVoluntarioAdministradorService
    {
        public Task<List<VoluntarioAdministrador>> Get();
        public Task<int> Add(DtoVoluntarioAdministrador voluntarioAdministrador);
        public Task<int> Delete(int Id);
    }
}
