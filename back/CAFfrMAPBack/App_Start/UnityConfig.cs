using CAFfrMAPBack.CSvParser;
using CAFfrMAPBack.Models;
using CAFfrMAPBack.Services;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Web;
using System.Web.Hosting;
using System.Web.Http;
using Unity.WebApi;

namespace CAFfrMAPBack
{
    public static class UnityConfig
    {
        public static string chemin = "@~/App_Data/GEOLOC.csv";

        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();
            var parser = new Parser();
            var reader = File.OpenRead(
                    Path.Combine((string)AppDomain.CurrentDomain.GetData("DataDirectory"),"GEOLOC.csv"));
            var provider = new POIProvider(parser.Parse(new StreamReader(reader)));
            //var provider = new POIProvider(new List<POI>(){
            //        new POI() {Adresse = "37 rue de rennes",
            //                    CodePostal = 35510, Ville = "Cesson-sévigné", Nom="Dummy",
            //                    X = -1.675076,
            //                    Y = 48.090707} });
            container.RegisterInstance<IPOIProvider>(provider);
            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}