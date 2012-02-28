using System;
using BabyFubuApp.Interface;
using BabyFubuApp.Interface.Actions;
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
                .IgnoreNamespaceText(typeof(HomeAction).Namespace)
                .HomeIs<HomeAction>(x => x.Home())
                .IgnoreControllerNamesEntirely()
                //.IgnoreControllerNamespaceEntirely()
                .IgnoreMethodSuffix("Html")
                .IgnoreMethodSuffix("Post")
                .IgnoreMethodSuffix("Add")
                .IgnoreMethodSuffix("List")
                .IgnoreMethodSuffix("View")
                .ConstrainToHttpMethod(action => action.Method.Name.EndsWith("Post"), "POST")
                .ConstrainToHttpMethod(action => action.Method.Name.EndsWith("View"), "GET")
                .RootAtAssemblyNamespace();

            // Match views to action methods by matching
            // on model type, view name, and namespace
            Import<WebFormsEngine>();
            //Views.TryToAttachWithDefaultConventions();
            Views.TryToAttach(x =>
                                  {
                                      x.by_ViewModel_and_Namespace_and_MethodName();
                                      x.by_ViewModel_and_Namespace();
                                      x.by_ViewModel();
                                  });
        }
    }
}