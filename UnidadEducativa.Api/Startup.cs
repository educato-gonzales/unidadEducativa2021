using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using UnidadEducativa.Api.Controllers;
using UnidadEducativa.Api.Helpers;
using UnidadEducativa.Core.Interfaces;
using UnidadEducativa.Core.Services;
using UnidadEducativa.Infrastructure.Data;
using UnidadEducativa.Infrastructure.Repositories;

namespace UnidadEducativa.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<AppSettings>(Configuration.GetSection("AppSettings"));
            services.AddScoped<UsuarioController>();

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            var conex = Configuration.GetConnectionString("colegioDB");
            services.AddControllers();
            services.AddDbContext<colegioContext>(options =>
                options.UseSqlServer(conex)
            );
            services.AddTransient<IAsistenciaService, AsistenciaService>();
            services.AddTransient<IAutoevaluacionService, AutoevaluacionService>();
            services.AddTransient<ICalendarioService, CalendarioService>();
            services.AddTransient<ICategoriaService, CategoriaService>();
            services.AddTransient<ICursoService, CursoService>();
            services.AddTransient<IEstudianteService, EstudianteService>();
            services.AddTransient<IEstudianteMateriaService, EstudianteMateriaService>();
            services.AddTransient<IEvaluacionProfesorService, EvaluacionProfesorService>();
            services.AddTransient<IFotosService, FotosService>();
            services.AddTransient<IHorarioService, HorarioService >();
            services.AddTransient<IInstitucionService, InstitucionService>();
            services.AddTransient<IMateriaService, MateriaService>();
            services.AddTransient<IMateriaDictadaService, MateriaDictadaService>();
            services.AddTransient<INotaService, NotaService>();
            services.AddTransient<INotificacionService, NotificacionService>();
            services.AddTransient<IParaleloService, ParaleloService>();
            services.AddTransient<IParametroService, ParametroService>();
            services.AddTransient<IPeriodoService, PeriodoService>();
            services.AddTransient<IProfesorService, ProfesorService>();
            services.AddTransient<IRepresentanteService, RepresentanteService>();
            services.AddTransient<IRolService, RolService>();
            services.AddTransient<IUsuarioService, UsuarioService>();
            services.AddTransient<IRudeService, RudeService>();
            services.AddTransient<ICalificacionService, CalificacionService>();
            services.AddTransient<IAdministradorService, AdministradorService>();
            services.AddTransient<IEstudianteCursoService, EstudianteCursoService>();
            services.AddTransient<INotasService, NotasService>();

            services.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));
            services.AddTransient<IUnitOfWork, UnitOfWork>();

            services.Configure<AppSettings>(Configuration.GetSection("AppSettings"));
            services.AddScoped<UsuarioController>();

            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder.AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader());
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors("CorsPolicy");

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseMiddleware<JwtMiddleware>();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
