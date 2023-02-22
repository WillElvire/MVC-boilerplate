using Microsoft.OpenApi.Models;
using WebApi.BML;

namespace WebApi;

public class Startup
{
    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }
    
    public IConfiguration Configuration { get; }

    public void ConfigureServices(IServiceCollection services)
    {
        string ConnectionPath = Configuration["ConnectionString"];
        string Password = Configuration["Password"];

        MConfiguration.getInstance().ConnexionString = $"{ConnectionPath}{Password}";
        
        services.AddCors(c => c.AddPolicy("Policy", builder => {
            builder.AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader();
        }));
        
        services.AddControllers();

  

        #region SWAGGER
        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo { Title = "", Version = "v1" });
        });
        #endregion

    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
            app.UseSwagger();
            app.UseSwaggerUI();
        }
        else
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("swagger/v1/swagger.json", "WevApi v1"); 
                    c.RoutePrefix = string.Empty;
                }
            );
        }

        app.UseHttpsRedirection();
        app.UseRouting();

        app.UseAuthentication();
        app.UseAuthorization();

        app.Use(next => context => { context.Request.EnableBuffering(); return next(context); });

        app.UseCors("Policy");
        app.UseEndpoints(endpoints =>
        {

            endpoints.MapControllers();
        });
    }
}