using DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Services.Extension.DtoMapping;

namespace Services.Services.IServices
{
    public interface IProfesionService
    {  
        public Task<List<Profesion>> Get();
        public Task<int> Add(DtoProfesion profesion);
        public Task<int> Update(DtoProfesion profesion);
        public Task<int> Delete(string Id);
    }
}
