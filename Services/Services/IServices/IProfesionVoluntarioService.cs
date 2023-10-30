using DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Services.Extension.DtoMapping;

namespace Services.Services.IServices
{
    public interface IProfesionVoluntarioService
    {
        public Task<List<ProfesionVoluntario>> Get();
        public Task<int> Add(DtoProfesionVoluntario profesionVoluntario);
        public Task<int> Delete(int VoluntarioSanitarioId, string ProfesionId);
    }
}
