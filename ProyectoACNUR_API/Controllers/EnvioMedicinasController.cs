﻿using DataAccess.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Services.IServices;
using static Services.Extension.DtoMapping;

namespace ProyectoACNUR_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnvioMedicinasController : ControllerBase
    {
        private readonly IEnvioMedicinaService _service;

        public EnvioMedicinasController(IEnvioMedicinaService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<List<EnvioMedicina>> Get()
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
        public async Task<IActionResult> Add(DtoEnvioMedicina request)
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
