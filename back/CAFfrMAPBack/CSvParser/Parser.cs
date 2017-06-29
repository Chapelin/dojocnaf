using CAFfrMAPBack.Models;
using CsvHelper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace CAFfrMAPBack.CSvParser
{
    public class Parser
    {

        public List<POI> Parse(TextReader data)
        {
            var csvREader = new CsvReader(data);
            csvREader.Configuration.Delimiter = ";";
            csvREader.Configuration.TrimFields = true;
            csvREader.Configuration.TrimHeaders = true;
            csvREader.Configuration.RegisterClassMap<CSvMapper>();
            var listePOI = csvREader.GetRecords<POI>();

            return listePOI.ToList();
        }
    }
}