

// You can remove the reference to WebActivator by calling the Start() method from your Global.asax Application_Start

using System.Web.Routing;
using Bottles;
using FubuMVC.Core;
using FubuMVC.StructureMap;
using Raven.Client;
using Raven.Client.Document;
using StructureMap;

[assembly: WebActivator.PreApplicationStartMethod(typeof(BabyFubuApp.App_Start.AppStartFubuMVC), "Start", callAfterGlobalAppStart: true)]

namespace BabyFubuApp.App_Start
{
    public static class AppStartFubuMVC
    {
        public static void Start()
        {
            var store = new DocumentStore{ConnectionStringName = "RavenDB"};
            store.Initialize();
            ObjectFactory.Configure(x => x.ForSingletonOf<IDocumentStore>().Add(store));

            // FubuApplication "guides" the bootstrapping of the FubuMVC
            // application
            FubuApplication.For<ConfigureFubuMVC>() // ConfigureFubuMVC is the main FubuRegistry
                                                    // for this application.  FubuRegistry classes 
                                                    // are used to register conventions, policies,
                                                    // and various other parts of a FubuMVC application


                // FubuMVC requires an IoC container for its own internals.
                // In this case, we're using a brand new StructureMap container,
                // but FubuMVC just adds configuration to an IoC container so
                // that you can use the native registration API's for your
                // IoC container for the rest of your application
                .StructureMap(ObjectFactory.Container)
                .Bootstrap();

			// Ensure that no errors occurred during bootstrapping
			PackageRegistry.AssertNoFailures();
        }
    }
}