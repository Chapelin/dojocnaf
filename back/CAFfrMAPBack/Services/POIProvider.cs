using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CAFfrMAPBack.Models;

namespace CAFfrMAPBack.Services
{
    public class POIProvider : IPOIProvider
    {
        public IEnumerable<POI> GetAll()
        {
            return new List<POI>() { new POI() { Adresse = "Adresse dummy", Nom = "Dummy", Type = "CAF" } };
        }
    }
}