using Elsa;
using Elsa.Persistence.EntityFramework.Core.Extensions;
using Elsa.Persistence.EntityFramework.Sqlite;
using Furion;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace WebApi1.Web.Core;
public class Startup :AppStartup
{
    public void ConfigureServices(IServiceCollection services)
    {

        services.AddApiVersioning();

        var elsaSection = App.Configuration.GetSection("Elsa");

        // Elsa services.
        services
            .AddElsa(elsa => elsa
                .UseEntityFrameworkPersistence(ef => ef.UseSqlite())
                .AddConsoleActivities()
                .AddHttpActivities(elsaSection.GetSection("Server").Bind)
                .AddQuartzTemporalActivities()
                .AddJavaScriptActivities()
                .AddWorkflowsFrom<Startup>()
            );

        // Elsa API endpoints.
        services.AddElsaApiEndpoints();

        // Allow arbitrary client browser apps to access the API.
        // In a production environment, make sure to allow only origins you trust.
        services.AddCors(cors => cors.AddDefaultPolicy(policy => policy
            .AllowAnyHeader()
            .AllowAnyMethod()
            .AllowAnyOrigin()
            .WithExposedHeaders("Content-Disposition")));


        services.AddConsoleFormatter();
            services.AddJwt<JwtHandler>();

            services.AddCorsAccessor();

            services.AddControllers()
                    .AddInjectWithUnifyResult();
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }

        app.UseHttpsRedirection();

        app.UseCors()
            .UseHttpActivities();
            

        app.UseRouting();

        app.UseCorsAccessor();

        app.UseAuthentication();
        app.UseAuthorization();

        app.UseInject(string.Empty);

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });
    }
}
