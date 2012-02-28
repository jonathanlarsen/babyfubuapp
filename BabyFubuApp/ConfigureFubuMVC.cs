using BabyFubuApp.Interface;
using FubuMVC.Core;
using FubuMVC.WebForms;

namespace BabyFubuApp
{
    public class ConfigureFubuMVC : FubuRegistry
    {
        public ConfigureFubuMVC()
        {
            // This line turns on the basic diagnostics and request tracing
            IncludeDiagnostics(true);

            // All public methods from concrete classes ending in "Controller"
            // in this assembly are assumed to be action methods
            Actions.IncludeTypesNamed(x => x.EndsWith("Action"));

            // Policies
            Routes
                .HomeIs<HomeAction>(x => x.Home())
                .IgnoreControllerNamesEntirely()
                .IgnoreMethodSuffix("Html")
                .RootAtAssemblyNamespace();

            // Match views to action methods by matching
            // on model type, view name, and namespace
            Import<WebFormsEngine>();
            Views.TryToAttachWithDefaultConventions();
        }
    }
}