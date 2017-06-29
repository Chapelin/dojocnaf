using CAFfrMAPBack.Models;
using CAFfrMAPBack.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using CAFfrMAPBack.Services;

namespace CAFfrMAPBack.Controllers
{

    public class POIController : ApiController
    {
        private IPOIProvider provider;

        public POIController() : base()
        {
            this.provider = new POIProvider();
        }


        public IEnumerable<POI> Get()
        {
            return this.provider.GetAll();
        }
    }
}