using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CAFfrMAPBack.Models;
using CAFfrMAPBack.CSvParser;
using System.IO;

namespace CAFfrMAPBack.Services
{
    public class POIProvider : IPOIProvider
    {
        private IEnumerable<POI> data;

        public POIProvider()
        {
            this.data = new List<POI>();
        }
        public POIProvider(List<POI> data)
        {
            this.data = data;
        }
        public IEnumerable<POI> GetAll()
        {
            return data;
        }

        public IEnumerable<POI> GetByType(params string[] filtres)
        {
            return data.Where(x => filtres.Any(y => string.Equals(x.Type, y, StringComparison.InvariantCultureIgnoreCase)));
        }
    }
}