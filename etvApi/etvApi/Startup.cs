using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using etvApi.Models;


namespace etvApi
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
            {
                services.AddCors(options =>
                {
                    options.AddPolicy("Default", conf =>
                    {
                        conf.AllowAnyMethod();
                        conf.AllowAnyHeader();
                        conf.AllowAnyOrigin();
                    });
                });


                services.AddControllers().AddJsonOptions(x =>
                 x.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles);
                services.AddDbContext<etvContext>(options =>
                    options.UseSqlServer(Configuration.GetConnectionString("cadenaConexion")));
                services.AddSwaggerGen(c =>
                {
                    c.SwaggerDoc("v1", new OpenApiInfo { Title = "etv", Version = "v1" });
                });
            }
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "etv v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors("Default");

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
