using DataAccess.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Services.IServices;
using static Services.Extension.DtoMapping;

namespace ProyectoACNUR_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CuotaSociosController : ControllerBase
    {
        private readonly ICuotaSocioService _service;

        public CuotaSociosController(ICuotaSocioService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<List<CuotaSocio>> Get()
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
        public async Task<IActionResult> Add(DtoCuotaSocio request)
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
    }
}
