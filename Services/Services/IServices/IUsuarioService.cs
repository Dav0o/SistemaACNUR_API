using DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Services.Extension.DtoMapping;

namespace Services.Services.IServices
{
    public interface IUsuarioService
    {
        public Task<List<Usuario>> Get();
        public Task<IEnumerable<Usuario>> GetById(int DniUsuario);
        public Task<int> Add(DtoUsuario usuario);
        public Task<int> Update(DtoUsuario usuario);
        public Task<int> Delete(int DniUsuario);
    }
}
