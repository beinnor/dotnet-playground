using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using ListAppApi.Models;

namespace ListAppApi
{
  public class Startup
  {
    public Startup(IConfiguration configuration)
    {
      Configuration = configuration;
    }

    readonly string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

    public IConfiguration Configuration { get; }

    // This method gets called by the runtime. Use this method to add services to the container.
    public void ConfigureServices(IServiceCollection services)
    {
      // TODO: Cors stuff, fix this
      services.AddCors(options =>
        {
          options.AddPolicy(MyAllowSpecificOrigins,
          builder =>
          {
            builder.WithOrigins("https://localhost:5001/api/Items",
                                  "http://localhost:5500",
                                  "http://127.0.0.1:5500")
                  .AllowAnyHeader();
          });
        });
      services.AddDbContext<ItemContext>(opt =>
             opt.UseSqlite("Data Source=ListAppApi.db"));
      services.AddControllers();
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
      }

      app.UseCors(MyAllowSpecificOrigins);

      app.UseHttpsRedirection();

      app.UseRouting();

      app.UseAuthorization();

      app.UseEndpoints(endpoints =>
      {
        endpoints.MapControllers();
      });
    }
  }
}
