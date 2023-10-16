using DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Services.Extension.DtoMapping;

namespace Services.Services.IServices
{
    public interface IUnidadMedidaService
    {
        public Task<List<UnidadMedidum>> Get();
        public Task<IEnumerable<UnidadMedidum>> GetById(string Id);
        public Task<int> Add(DtoUnidadMedida unidadMedida);
        public Task<int> Update(DtoUnidadMedida unidadMedida);
        public Task<int> Delete(string Id);
    }
}
