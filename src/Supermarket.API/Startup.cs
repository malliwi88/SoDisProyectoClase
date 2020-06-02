﻿using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using Microsoft.EntityFrameworkCore;
using Supermarket.API.Persistencia;
using Supermarket.API.Dominio.Repositorios;

namespace Supermarket.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        /// <summary>
        /// Método que permite configurar los servicios que se van a agregar al servidor kestrel
        /// Este punto de configuración del servidor cumple el propósito de ser middleware
        /// y hace posible la modularidad de la aplicación, al implementar el patrón de DI
        /// </summary>
        /// <param name="services"></param>
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            // emular el comportamiento de una base de datos en memoria con EFCore
            services.AddDbContext<SupermarketApiContext>(options =>
                options.UseInMemoryDatabase("SupermarketApi"));

            // agregar el servicio de categorias para que se pueda manejar
            // inyección de dependencias en el repositorio y el controlador
            services.AddTransient<ICategoriaRepo, CategoriaRepo>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
