using DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Services.Extension.DtoMapping;

namespace Services.Services.IServices
{
    public interface IInventarioMedicinaService
    {
        public Task<List<InventarioMedicina>> Get();
        public Task<IEnumerable<InventarioMedicina>> GetById(int Id);
        public Task<int> Add(DtoInventarioMedicina inventarioMedicina);
        public Task<int> Update(DtoInventarioMedicina inventarioMedicina);
        public Task<int> Delete(int Id);
    }
}
