using DataAccess.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Services.IServices;
using static Services.Extension.DtoMapping;

namespace ProyectoACNUR_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CuotasController : ControllerBase
    {
        private readonly ICuotaService _service;

        public CuotasController(ICuotaService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<List<Cuotum>> Get()
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
        public async Task<IActionResult> Add(DtoCuota request)
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


        //[HttpPut]
        //public async Task<IActionResult> Update(DtoCuota request)
        //{

        //    try
        //    {
        //        var result = await _service.Update(request);
        //        return Ok(result);
        //    }
        //    catch
        //    {
        //        throw;
        //    }
        //}

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
 