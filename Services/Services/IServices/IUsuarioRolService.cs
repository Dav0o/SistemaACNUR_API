using DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Services.Extension.DtoMapping;

namespace Services.Services.IServices
{
    public interface IUsuarioRolService
    {
        public Task<List<UsuarioRol>> Get();
        public Task<int> Add(DtoUsuarioRol usuarioRol);
        public Task<int> Delete(int Id);
    }
}
