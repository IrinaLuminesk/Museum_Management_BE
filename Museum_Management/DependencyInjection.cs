using Museum_Management_Repositories.MasterData.Impls;
using Museum_Management_Services.MasterData.Impls;
using System.Reflection;

public static class DependencyInjection
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        RegisterByConvention(
            services,
            typeof(MuseumService).Assembly,
            "Service");

        RegisterByConvention(
            services,
            typeof(MuseumRepository).Assembly,
            "Repository");

        return services;
    }

    private static void RegisterByConvention(IServiceCollection services, Assembly assembly, string suffix)
    {
        var implementations = assembly.GetTypes()
            .Where(t =>
                t.IsClass &&
                !t.IsAbstract &&
                !t.IsGenericTypeDefinition &&
                t.Name.EndsWith(
                    suffix,
                    StringComparison.Ordinal));

        foreach (var implementation in implementations)
        {
            string expectedInterfaceName = $"I{implementation.Name}";

            var matchingInterface = implementation.GetInterfaces()
                .FirstOrDefault(i =>
                    i.Name == expectedInterfaceName);

            if (matchingInterface is not null)
            {
                services.AddScoped(
                    matchingInterface,
                    implementation);
            }
        }
    }
}