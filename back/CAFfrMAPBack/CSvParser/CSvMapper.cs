using CAFfrMAPBack.Models;
using CsvHelper.Configuration;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;

namespace CAFfrMAPBack.CSvParser
{
    public class CSvMapper : CsvClassMap<POI>
    {

        public CSvMapper()
        {
            Map(m => m.Nom).Name("Nom_accueil ");
            Map(m => m.Type).Name("type_accueil");
            Map(m => m.CodePostal).Name("code postal_caf_fr");
            Map(m => m.Ville).Name("ville_caf_fr");
            Map(m => m.Adresse).Name("adresse_caf_fr");
            Map(m => m.X).Name("Latitude");
            Map(m => m.Y).Name("Longitude");
        }
    }
}