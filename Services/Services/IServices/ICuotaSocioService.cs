using DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Services.Extension.DtoMapping;

namespace Services.Services.IServices
{
    public interface ICuotaSocioService
    {
        public Task<List<CuotaSocio>> Get();
        public Task<int> Add(DtoCuotaSocio cuotaSocio);
    }
}
