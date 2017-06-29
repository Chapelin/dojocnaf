using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CAFfrMAPBack.Models;

namespace CAFfrMAPBack.Services
{
    public class POIProvider : IPOIProvider
    {
        //private IEnumerable<POI> data;

        //public POIProvider(IEnumerable<POI> data)
        //{

        //}
        public IEnumerable<POI> GetAll()
        {
            return new List<POI>() { new POI() { Adresse = "37 rue de rennes", CodePostal = 35510, Ville="Cesson sévigné", Nom = "Dummy", Type = "CAF" } };
        }
    }
}