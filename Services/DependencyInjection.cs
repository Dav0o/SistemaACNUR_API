﻿using Microsoft.Extensions.Configuration;
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

            return services;
        }
    }
}
