using CAFfrMAPBack.Models;
using CAFfrMAPBack.Services;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;

namespace CAFfrMAPBack.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
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

        [Route("api/POI/getall")]
        public IEnumerable<POI> GetAll()
        {
            return this.provider.GetAll();
        }

        [Route("api/POI/get/{filtres}")]
        public IEnumerable<POI> Get([FromUri] string filtres)
        {
            var listefiltres = filtres.Split(',');

            return this.provider.GetByFiltre(listefiltres);
        }

        [Route("api/POI/getallocataire")]
        public Allocataire GetAllocataire()
        {
            return new Allocataire() { Adresse1 = "37 rue de rennes", CodePostal = 35510, Ville = "Cesson sévigné" };
        }


    }
}