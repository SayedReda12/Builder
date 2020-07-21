using Builder.Common.EntityFromework;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Builder.Common.DependencyInjection
{
    public static class DependencyAutoRegister
    {
        public static void RegisterByAssembly(this IServiceCollection services)
        {
            var assemblies = LoadAsseblies();
            services.SingletonRegister(assemblies);
            services.ScopedRegister(assemblies);
            services.TransientRegister(assemblies);

            services.AddScoped(typeof(IRepository<,>), typeof(EfBaseRepository<,>));

        }

        private static IServiceCollection SingletonRegister(this IServiceCollection services, IEnumerable<Assembly> assemblies)
        {
            Type type = typeof(ISingletonDependency);

            // Get all Driven interfaces
            var interfaces = assemblies.SelectMany(x=>x.GetTypes())
                    .Where(x => type.IsAssignableFrom(x) && x.IsInterface && x != type && !x.IsGenericType)
                .Select(x => x).ToList();


            foreach (var interfaceItem in interfaces)
            {
                //get concrete for the current interface
                var Implementation = assemblies.SelectMany(x => x.GetTypes())
                .FirstOrDefault(a => interfaceItem.IsAssignableFrom(a)
                && interfaceItem.Name.ToLower().Contains(a.Name.ToLower())
                && !a.IsInterface);

                // Register In DI
                services.AddSingleton(interfaceItem, Implementation);
            }

            return services;
        }

        private static IServiceCollection ScopedRegister(this IServiceCollection services, IEnumerable<Assembly> assemblies)
        {
            Type type = typeof(IScopedDependency);

            // Get all Driven interfaces
            var interfaces = assemblies.SelectMany(x => x.GetTypes())
                    .Where(x => type.IsAssignableFrom(x) && x.IsInterface && x != type && !x.IsGenericType)
                .Select(x => x).ToList();


            foreach (var interfaceItem in interfaces)
            {
                //get concrete for the current interface
                var Implementation = assemblies.SelectMany(x => x.GetTypes())
                .FirstOrDefault(a => interfaceItem.IsAssignableFrom(a)
                && interfaceItem.Name.ToLower().Contains(a.Name.ToLower())
                && !a.IsInterface);

                // Register In DI
                services.AddScoped(interfaceItem, Implementation);
            }

            return services;
        }

        private static IServiceCollection TransientRegister(this IServiceCollection services, IEnumerable<Assembly> assemblies)
        {
            Type type = typeof(ITransientDependency);

            // Get all Driven interfaces
            var interfaces = assemblies.SelectMany(x => x.GetTypes())
                    .Where(x => type.IsAssignableFrom(x) && x.IsInterface && x != type && !x.IsGenericType)
                .Select(x => x).ToList();


            foreach (var interfaceItem in interfaces)
            {
                //get concrete for the current interface
                var Implementation = assemblies.SelectMany(x => x.GetTypes())
                .FirstOrDefault(a => interfaceItem.IsAssignableFrom(a)
                && interfaceItem.Name.ToLower().Contains(a.Name.ToLower())
                && !a.IsInterface);

                // Register In DI
                services.AddTransient(interfaceItem, Implementation);
            }

            return services;
        }

        private static IEnumerable<Assembly> LoadAsseblies()
        {
            var loadedAssemblies = AppDomain.CurrentDomain.GetAssemblies().Where(a => !a.IsDynamic).ToList();
            var loadedPaths = loadedAssemblies.Select(a => a.Location).ToArray();

            var referencedPaths = Directory.GetFiles(AppDomain.CurrentDomain.BaseDirectory, "*.dll");
            var toLoad = referencedPaths.Where(r => !loadedPaths.Contains(r, StringComparer.InvariantCultureIgnoreCase)).ToList();

            toLoad.ForEach(path => loadedAssemblies.Add(AppDomain.CurrentDomain.Load(AssemblyName.GetAssemblyName(path))));

            return loadedAssemblies;
        }
    }
}
