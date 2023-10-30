using DataAccess.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Services.IServices;
using static Services.Extension.DtoMapping;

namespace ProyectoACNUR_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfesionVoluntariosController : ControllerBase
    {
        private readonly IProfesionVoluntarioService _service;

        public ProfesionVoluntariosController(IProfesionVoluntarioService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<List<ProfesionVoluntario>> Get()
        {
            try
            {
                return await _service.Get();
            }
            catch
            {
                throw;
            }
        }



        [HttpPost]
        public async Task<IActionResult> Add(DtoProfesionVoluntario request)
        {


            try
            {
                var response = await _service.Add(request);

                return Ok(response);
            }
            catch
            {
                throw;
            }
        }


        [HttpDelete]
        public async Task<int> Delete(int VoluntarioSanitarioId, string ProfesionId)
        {
            try
            {
                var response = await _service.Delete(VoluntarioSanitarioId, ProfesionId);
                return response;
            }
            catch
            {
                throw;
            }
        }
    }
}