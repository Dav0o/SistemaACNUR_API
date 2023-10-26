using DataAccess.Model;
using static Services.Extension.DtoMapping;

namespace Services.Services.IServices
{
    public interface IRolService
    {
        public Task<List<Rol>> Get();
        public Task<int> Add(DtoRol rol);
        public Task<int> Update(DtoRol rol);
        public Task<int> Delete(string id);
    }
}
