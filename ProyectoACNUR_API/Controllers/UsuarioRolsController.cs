﻿using DataAccess.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Services.IServices;
using static Services.Extension.DtoMapping;

namespace ProyectoACNUR_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioRolsController : ControllerBase
    {
        private readonly IUsuarioRolService _service;

        public UsuarioRolsController(IUsuarioRolService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<List<UsuarioRol>> Get()
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
        public async Task<IActionResult> Add(DtoUsuarioRol request)
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
        public async Task<int> Delete(int usuarioDni, string rolId)
        {
            try
            {
                var response = await _service.Delete(usuarioDni, rolId);
                return response;
            }
            catch
            {
                throw;
            }
        }
    }
}
