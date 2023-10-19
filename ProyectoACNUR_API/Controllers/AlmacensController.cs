using Microsoft.AspNetCore.Mvc;
using DataAccess.Model;
using Services.Services.IServices;
using static Services.Extension.DtoMapping;

namespace ProyectoACNUR_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class AlmacensController : ControllerBase
    {
        private readonly IAlmacenService _service;

        public AlmacensController(IAlmacenService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<List<Almacen>> Get()
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
        public async Task<IEnumerable<Almacen>> GetById(string Id)
        {
            try
            {
                var response = await _service.GetById(Id);

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
        public async Task<IActionResult> Add(DtoAlmacen request)
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
        public async Task<IActionResult> Update(DtoAlmacen request)
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
        public async Task<int> Delete(string Id)
        {
            try
            {
                var response = await _service.Delete(Id);
                return response;
            }
            catch
            {
                throw;
            }
        }
    }
}