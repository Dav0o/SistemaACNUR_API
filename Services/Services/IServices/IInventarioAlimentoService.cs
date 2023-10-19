using DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Services.Extension.DtoMapping;

namespace Services.Services.IServices
{
    public interface IInventarioAlimentoService
    {
        public Task<List<InventarioAlimento>> Get();
        public Task<IEnumerable<InventarioAlimento>> GetById(int Id);
        public Task<int> Add(DtoInventarioAlimento inventarioAlimento);
        public Task<int> Update(DtoInventarioAlimento inventarioAlimento);
        public Task<int> Delete(int Id);
    }
}
