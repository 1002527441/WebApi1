using Furion;
using System.Reflection;

namespace WebApi1.Web.Entry;
public class SingleFilePublish :ISingleFilePublish
{
    public Assembly[] IncludeAssemblies()
    {
        return Array.Empty<Assembly>();
    }

    public string[] IncludeAssemblyNames()
    {
        return new[]
        {
            "WebApi1.Application",
            "WebApi1.Core",
            "WebApi1.EntityFramework.Core",
            "WebApi1.Web.Core"
        };
    }
}