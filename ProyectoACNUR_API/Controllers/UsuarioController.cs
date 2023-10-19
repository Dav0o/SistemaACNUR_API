using DataAccess.Model;
using Microsoft.AspNetCore.Mvc;
using Services.Services.IServices;
using static Services.Extension.DtoMapping;

namespace ProyectoACNUR_API.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioService _service;

        public UsuarioController(IUsuarioService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<List<Usuario>> Get()
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

        [HttpGet("{id}")]
        public async Task<IEnumerable<Usuario>> GetById(int DniUsuario)
        {
            try
            {
                var response = await _service.GetById(DniUsuario);

                if (response == null)
                {
                    return null;
                }

                return response;
            }
            catch
            {
                throw;
            }
        }

        [HttpPost]
        public async Task<IActionResult> Add(DtoUsuario request)
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

        [HttpPut]
        public async Task<IActionResult> Update(DtoUsuario request)
        {

            try
            {
                var result = await _service.Update(request);
                return Ok(result);
            }
            catch
            {
                throw;
            }
        }

        [HttpDelete]
        public async Task<int> Delete(int DniUsuario)
        {
            try
            {
                var response = await _service.Delete(DniUsuario);
                return response;
            }
            catch
            {
                throw;
            }
        }
    }
}
