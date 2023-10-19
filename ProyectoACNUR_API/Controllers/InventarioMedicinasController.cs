using DataAccess.Model;
using Microsoft.AspNetCore.Mvc;
using Services.Services.IServices;
using static Services.Extension.DtoMapping;

namespace ProyectoACNUR_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InventarioMedicinasController : ControllerBase
    {
        private readonly IInventarioMedicinaService _service;

        public InventarioMedicinasController(IInventarioMedicinaService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<List<InventarioMedicina>> Get()
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
        public async Task<IEnumerable<InventarioMedicina>> GetById(int Id)
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
        public async Task<IActionResult> Add(DtoInventarioMedicina request)
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
        public async Task<IActionResult> Update(DtoInventarioMedicina request)
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
        public async Task<int> Delete(int Id)
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
