using Template.Common.ViewModels;
using System.Reflection;

namespace Template.Common.Extensions
{
    /// <summary>
    /// MauiAppBuilder extension to register types
    /// </summary>
    public static class MauiAppBuilderExtensions
    {

        /// <summary>
        /// Register all ViewModels and pages as transient
        /// </summary>
        public static MauiAppBuilder RegisterViewModelsAndServices(this MauiAppBuilder builder)
        {
          
            // Find the viewmodels and services from the calling assembly
            var currentAssembly = Assembly.GetCallingAssembly();
            RegisterAssemblyViewModelsAndServices(currentAssembly, builder);

            // Find the viewmodels and services from all the referenced assemblies
            // that share the same namespace
            var assemblyName = currentAssembly.GetName().Name;
            var references = currentAssembly.GetReferencedAssemblies().Where(x => x.FullName.Contains(assemblyName));
            foreach (var reference in references)
            {
                var assembly = Assembly.Load(reference);
                RegisterAssemblyViewModelsAndServices(assembly, builder);                
            }
            return builder;
        }


        /// <summary>
        /// For a given assembly register the viewmodel and services
        /// </summary>
        private static void RegisterAssemblyViewModelsAndServices(Assembly assembly, MauiAppBuilder builder)
        {
            var foundViewModels = new List<Type>();
            var foundPages = new Dictionary<string, Type>();
            foreach (var type in assembly.DefinedTypes
                   .Where(e => !e.IsAbstract &&
                   (e.IsSubclassOf(typeof(Page)) || e.Name.Contains("ViewModel")))) //s e.IsSubclassOf(typeof(BaseViewModel))))
            {

                builder.Services.AddTransient(type.AsType());
                if (type.Name.Contains("ViewModel"))
                {
                    foundViewModels.Add(type);
                }
                if (type.IsSubclassOf(typeof(Page)))
                {
                    foundPages.Add(type.Name, type);
                }
            }

            foreach (var type in assembly.DefinedTypes
             .Where(e => e.Name.Contains("Service")))
            {
                var interfaceType = type.GetInterfaces();
                if (interfaceType.Length > 0)
                {
                    builder.Services.AddSingleton(interfaceType.First(), type);
                }
            }   
            
            // Register all routes
            foreach(var viewModels in foundViewModels)
            {
               
                // Try to find the proper page
                var pageName = viewModels.Name.Replace("ViewModel", "Page");
                var page = foundPages.FirstOrDefault(x => x.Key == pageName);
                if (page.Value != null)
                { 
                    Routing.RegisterRoute(viewModels.ToString(), page.Value);
                }
            }
        }


    }
}
