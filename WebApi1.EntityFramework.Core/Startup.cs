using Furion;
using Microsoft.Extensions.DependencyInjection;

namespace WebApi1.EntityFramework.Core;
public class Startup :AppStartup
{
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddDatabaseAccessor(options =>
        {
            options.AddDbPool<DefaultDbContext>();
        }, "WebApi1.Database.Migrations");
    }
}
