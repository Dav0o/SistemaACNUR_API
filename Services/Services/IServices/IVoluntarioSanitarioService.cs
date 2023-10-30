using DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Services.Extension.DtoMapping;

namespace Services.Services.IServices
{
    public interface IVoluntarioSanitarioService
    {
        public Task<List<VoluntarioSanitario>> Get();
        public Task<int> Add(DtoVoluntarioSanitario voluntarioSanitario);
        public Task<int> Update(DtoVoluntarioSanitario voluntarioSanitario);
        public Task<int> Delete(int Id);
    }
}
