using CAFfrMAPBack.Models;
using CsvHelper.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CAFfrMAPBack.CSvParser
{
    public class CSvMapper: CsvClassMap<POI>
    {

        public CSvMapper() { 

            }
    }
}