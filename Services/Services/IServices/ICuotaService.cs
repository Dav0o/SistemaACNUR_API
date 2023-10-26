using DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Services.Extension.DtoMapping;

namespace Services.Services.IServices
{
    public interface ICuotaService

    {
        public Task<List<Cuotum>> Get();
        public Task<int> Add(DtoCuota cuota);
   
        public Task<int> Delete(int Id);
    }
}
