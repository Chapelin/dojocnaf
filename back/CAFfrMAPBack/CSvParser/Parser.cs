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
            return null;
        }
    }
}