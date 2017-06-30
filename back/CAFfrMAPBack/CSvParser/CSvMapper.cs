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
            Map(m => m.Nom).Name("Nom_accueil");
            Map(m => m.Type).ConvertUsing(x => x.GetField("type_accueil").Trim().ToLower().Replace(' ','_')); // Name("type_accueil");
            Map(m => m.Type_Libelle).ConvertUsing(x => { var res = x.GetField("type_accueil").Trim().ToLower();
                var propre = res.Substring(0, 1).ToUpper() + new string(res.Skip(1).ToArray());
                return propre;
            } );
            Map(m => m.CodePostal).Name("code postal_caf_fr");
            Map(m => m.Ville).Name("ville_caf_fr");
            Map(m => m.Adresse).Name("adresse_caf_fr");
            Map(m => m.X).Name("Latitude");
            Map(m => m.Y).Name("Longitude");
            Map(m => m.ComplementHeures).Name("complément");
            Map(m => m.HeuresOuvertures).Name("heures_ouverture");
        }
    }
}