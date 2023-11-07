using DataAccess.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

using Services.Services.IServices;
using static Services.Extension.DtoMapping;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProyectoACNUR_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlimentosController : ControllerBase
    {
        private readonly IAlimentoService _service;

        public AlimentosController(IAlimentoService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<List<Alimento>> Get()
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

        [HttpGet("{Id_Alimento}")]
        public async Task<IEnumerable<Alimento>> GetById(string Id_Alimento)
        {
            try
            {
                var response = await _service.GetById(Id_Alimento);

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
        public async Task<IActionResult> Add(DtoAlimento request)
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
        public async Task<IActionResult> Update(DtoAlimento request)
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
