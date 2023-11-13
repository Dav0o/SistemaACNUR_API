using DataAccess.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Services.Services.IServices;
using static Services.Extension.DtoMapping;
using System;
using System.Security.Cryptography;
using System.Text;

namespace ProyectoACNUR_API.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly AcnurContext _service;

        public UsuarioController(AcnurContext service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<List<Usuario>> Get()
        {
            try
            {
                return await _service.Usuarios.ToListAsync();
            }
            catch
            {
                throw;
            }
        }

        [HttpGet("{DniUsuario}")]
        public async Task<Usuario> GetById(int DniUsuario)
        {

            var user = await _service.Usuarios.FirstOrDefaultAsync(x => x.DniUsuario == DniUsuario);


            if (user == null)
            {
                return null;
            }
            return user;
        }

        [HttpPost]
        public async Task<IActionResult> Add(DtoUsuario request)
        {
            Usuario newUser = new Usuario();

            newUser.DniUsuario = request.DniUsuario;
            newUser.NombreUsuario = request.NombreUsuario;
            newUser.Apellido1 = request.Apellido1;
            newUser.Apellido2 = request.Apellido2;
            newUser.Correo = request.Correo;

            // Encriptar la contraseña con SHA-256
            newUser.Clave = HashPassword(request.Clave);

            newUser.Telefono = request.Telefono;
            newUser.Direccion = request.Direccion;
            newUser.SedeId = request.SedeId;

            _service.Add(newUser);
            await _service.SaveChangesAsync();

            return Ok(newUser);
        }

        [HttpPut]
        public async Task<IActionResult> Update(DtoUsuario request)
        {
            Usuario newUser = new Usuario();

            newUser.DniUsuario = request.DniUsuario;
            newUser.NombreUsuario = request.NombreUsuario;
            newUser.Apellido1 = request.Apellido1;
            newUser.Apellido2 = request.Apellido2;
            newUser.Correo = request.Correo;

            // Encriptar la contraseña con SHA-256
            newUser.Clave = HashPassword(request.Clave);

            newUser.Telefono = request.Telefono;
            newUser.Direccion = request.Direccion;
            newUser.SedeId = request.SedeId;

            _service.Usuarios.Attach(newUser);
            _service.Entry(newUser).State = EntityState.Modified;
            await _service.SaveChangesAsync();


            return NoContent();

        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int DniUsuario)
        {
            var user = await _service.Usuarios.FirstOrDefaultAsync(x => x.DniUsuario == DniUsuario);
            if (user != null)
            {
                _service.Remove(user);
                await _service.SaveChangesAsync();

                return NoContent();
            }
            return NoContent();

        }
        private string HashPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                // Convertir la contraseña a bytes
                byte[] passwordBytes = Encoding.UTF8.GetBytes(password);

                // Calcular el hash
                byte[] hashBytes = sha256.ComputeHash(passwordBytes);

                // Convertir el hash a una cadena hexadecimal
                string hashedPassword = BitConverter.ToString(hashBytes).Replace("-", "").ToLower();

                return hashedPassword;
            }
        }
    }
}