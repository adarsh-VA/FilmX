using Assignment_3.Helpers;
using Assignment_3.Repository;
using Assignment_3.Repository.Interfaces;
using Assignment_3.Services;
using Assignment_3.Services.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace Assignment_3
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
            services.AddCors(options =>
            {
                options.AddPolicy("AllowVueJsApp",
                    builder =>
                    {
                        builder.WithOrigins("http://localhost:8080")
                               .AllowAnyHeader()
                               .AllowAnyMethod();
                    });
            });

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "FilmX_Backend", Version = "v1" });
            });
            services.TryAddScoped<IActorRepository, ActorRepository>();
            services.TryAddScoped<IActorService, ActorService>();
            services.TryAddScoped<IProducerRepository, ProducerRepository>();
            services.TryAddScoped<IProducerService, ProducerService>();
            services.TryAddScoped<IGenreRepository, GenreRepository>();
            services.TryAddScoped<IGenreService, GenreService>();
            services.TryAddScoped<IReviewRepository, ReviewRepository>();
            services.TryAddScoped<IReviewService, ReviewService>();
            services.TryAddScoped<IMovieRepository, MovieRepository>();
            services.TryAddScoped<IMovieService, MovieService>();
            services.AddTransient<CustomExceptionHandler>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "FilmX_Backend v1"));
            }

            app.UseHttpsRedirection();
            app.UseCors("AllowVueJsApp");
            app.UseRouting();
            app.UseMiddleware<CustomExceptionHandler>();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
