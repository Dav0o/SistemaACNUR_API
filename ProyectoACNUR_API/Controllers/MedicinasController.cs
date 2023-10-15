using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProyectoACNUR_API.Model;
using Services.Services.IServices;

namespace ProyectoACNUR_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicinasController : ControllerBase
    {
        private readonly IMedicinaService _service;

        public MedicinasController(IMedicinaService service)
        {
            _service = service;
        }
        [HttpGet]
        public async Task<List<Medicina>> Get()
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
    }
}
