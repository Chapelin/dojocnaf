using CAFfrMAPBack.Models;
using System.Collections.Generic;

namespace CAFfrMAPBack.Services
{
    public interface IPOIProvider
    {
        IEnumerable<POI> GetAll();
        IEnumerable<POI> GetByType(params string[] filtres);
       
    }
}