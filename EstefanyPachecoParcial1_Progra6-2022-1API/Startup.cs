using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EstefanyPachecoParcial1_Progra6_2022_1API.Models;
using Microsoft.EntityFrameworkCore;


namespace EstefanyPachecoParcial1_Progra6_2022_1API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }


        public void ConfigureServices(IServiceCollection services)
        {
            //Agregar la cadena de conexión para el proyecto.
            //TODO: Debemos guardar esta cadena por medio de usersecrets.json
            //y no por medio de appsettings.json
            var conn = @"SERVER=.;DATABASE=P6Assets20221;trusted_connection=true;";

            services.AddDbContext<P6Assets20221Context>(options => options.UseSqlServer(conn));



            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "EstefanyPachecoParcial1_Progra6_2022_1API", Version = "v1" });
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "EstefanyPachecoParcial1_Progra6_2022_1API v1"));
            }

            app.UseRouting();

            app.UseAuthorization();

            //TODO: revisar si hace falta alguna config para usod e JWT

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }






    }
}
