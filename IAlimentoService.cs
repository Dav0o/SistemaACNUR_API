using DataAccess.Model;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Services.Extension.DtoMapping;

namespace Services.Services.IServices
{
    public interface IAlimentoService
    {
        public Task<List<Alimento>> Get();
        public Task<IEnumerable<Alimento>> GetById(string Id_Alimento);
        public Task<int> Add(DtoAlimento alimento);
        public Task<int> Update(DtoAlimento alimento);
        public Task<int> Delete(string Id);
    }
}
