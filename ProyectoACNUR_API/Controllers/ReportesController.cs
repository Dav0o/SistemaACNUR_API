using DataAccess.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ProyectoACNUR_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportesController : ControllerBase
    {
        private readonly AcnurContext _context;

        public ReportesController(AcnurContext context)
        {
            _context = context;
        }

        [HttpGet("inventario-alimentos")]
        public async Task<List<Alimento>> ReporteAlimentos()
        {

            var alimentos = await _context.Alimentos.Include("InventarioAlimentos").ToListAsync();

            return alimentos;
        }
        [HttpGet("inventario-medicinas")]
        public async Task<List<Medicina>> ReporteMedicinas()
        {

            var medicinas = await _context.Medicinas.Include("InventarioMedicinas").ToListAsync();

            return medicinas;
        }

        [HttpPost("consultarEnvioPorFecha")]
        public IActionResult ConsultarEnvioPorFecha([FromBody] EnvioFechaParams parametros)
        {
            try
            {
                var result = _context.Envios.FromSqlRaw("EXEC SP_Consultar_EnvioXFecha @p0, @p1", parametros.EsFechaInicio, parametros.EsFechaFin).ToList();
                return Ok(result);
            }
            catch (Exception ex)
            {
                // Manejar errores según tus necesidades
                return BadRequest("Error al ejecutar el procedimiento almacenado: " + ex.Message);
            }
        }

        public class EnvioFechaParams
        {
            public DateTime EsFechaInicio { get; set; }
            public DateTime EsFechaFin { get; set; }
        }
    }
}
