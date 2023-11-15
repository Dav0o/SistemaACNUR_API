using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Services.Services;
using Services.Services.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddServices(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddScoped<IAlimentoService, AlimentoService>();
            services.AddScoped<IMedicinaService, MedicinaService>();
            services.AddScoped<IAlmacenService, AlmacenService>();
            services.AddScoped<IInventarioAlimentoService, InventarioAlimentoService>();
            services.AddScoped<IEnvioService, EnvioService>();
            services.AddScoped<IInventarioMedicinaService, InventarioMedicinaService>();
            services.AddScoped<ISedeService, SedeService>();
            services.AddScoped<IUnidadMedidaService, UnidadMedidaService>();
            services.AddScoped<IUsuarioService, UsuarioService>();
            services.AddScoped<IDireccionService, DireccionService>();
            services.AddScoped<IRolService, RolService>();  
            services.AddScoped<IUsuarioRolService, UsuarioRolService> ();
            services.AddScoped<IProfesionService, ProfesionService>();
            services.AddScoped<IProfesionVoluntarioService, ProfesionVoluntarioService>();
            services.AddScoped<ICuotaService, CuotaService>();
            services.AddScoped<ISocioService, SocioService>();
            services.AddScoped<ICuotaSocioService, CuotaSocioService> ();
            services.AddScoped<IVoluntarioAdministradorService, VoluntarioAdministradorService>();
            services.AddScoped<IVoluntarioSanitarioService, VoluntarioSanitarioService>();
            services.AddScoped<IEnvioAlimentoService, EnvioAlimentoService>();
            services.AddScoped<IEnvioMedicinaService, EnvioMedicinaService>();
            services.AddScoped<IEnvioHumanitarioService, EnvioHumanitarioService>();
            services.AddScoped<IEnvioSedeService, EnvioSedeService>();

            return services;
        }
    }
}
