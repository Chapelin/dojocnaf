using CAFfrMAPBack.Models;
using CAFfrMAPBack.Services;
using System.Collections.Generic;
using System.Web.Http;

namespace CAFfrMAPBack.Controllers
{

    public class POIController : ApiController
    {
        private IPOIProvider provider;

        public POIController(IPOIProvider provider) : base()
        {
            this.provider = provider;
        }

        public IEnumerable<POI> Get()
        {
            return this.provider.GetAll();
        }

        [Route("api/POI/getallocataire")]
        public Allocataire GetAllocataire()
        {
            return new Allocataire() { Adresse = "37 rue de rennes", CodePostal = 35510, Ville = "Cesson sévigné" };
        }
    }
}