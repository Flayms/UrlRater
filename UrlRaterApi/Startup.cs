using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using UrlRaterApi.Services.Db;

namespace UrlRaterApi {
  public class Startup {
    public Startup(IConfiguration configuration) {
      this.Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    // This method gets called by the runtime. Use this method to add services to the container.
    public void ConfigureServices(IServiceCollection services) { //todo: dont put password that open here
      var connectionString = "User ID=postgres;Password=X#cZ@iwLQL%c53;Host=localhost;Port=5432;Database=UrlRater;Pooling=true;";

      services.AddCors(options => {
        options.AddPolicy("AllowAnyOrigin",
          builder => builder
            .AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader());
      });

      services.AddControllers();
      services.AddSwaggerGen(c => {
        c.SwaggerDoc("v1", new OpenApiInfo { Title = "UrlRaterApi", Version = "v1" });
      });
      services.AddDbContext<UrlRaterDbContext>(options => options.UseNpgsql(connectionString));
      services.AddScoped<UrlRaterDbContext>();
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env) {
      if (env.IsDevelopment()) {
        app.UseDeveloperExceptionPage();
        app.UseSwagger();
        app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "UrlRaterApi v1"));
      }

      app.UseHttpsRedirection();

      app.UseCors("AllowAnyOrigin");

      app.UseRouting();

      app.UseAuthorization();

      app.UseEndpoints(endpoints => {
        endpoints.MapControllers();
      });
    }
  }
}
