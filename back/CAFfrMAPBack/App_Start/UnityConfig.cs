using CAFfrMAPBack.CSvParser;
using CAFfrMAPBack.Models;
using CAFfrMAPBack.Services;
using Microsoft.Practices.Unity;
using System.Collections.Generic;
using System.Web.Hosting;
using System.Web.Http;
using Unity.WebApi;

namespace CAFfrMAPBack
{
    public static class UnityConfig
    {
        public static string chemin = "";

        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();
            //var parser = new Parser();
            //var reader = System.IO.File.OpenRead(HostingEnvironment.MapPath(@"~/App_Data/file.txt"))
            //var provider = new POIProvider(parser.Parse(chemin));
            var provider = new POIProvider(new List<POI>(){
                    new POI() {Adresse = "37 rue de rennes",
                                CodePostal = 35510, Ville = "Cesson-sévigné", Nom="Dummy",
                                X = -1.675076,
                                Y = 48.090707} });
            container.RegisterInstance<IPOIProvider>(provider);
            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}