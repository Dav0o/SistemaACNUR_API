using DataAccess.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Services.IServices;
using static Services.Extension.DtoMapping;

namespace ProyectoACNUR_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VoluntarioAdministradorsController : ControllerBase
    { 
         private readonly IVoluntarioAdministradorService _service;

    public VoluntarioAdministradorsController(IVoluntarioAdministradorService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<List<VoluntarioAdministrador>> Get()
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
    public async Task<IActionResult> Add(DtoVoluntarioAdministrador request)
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
  