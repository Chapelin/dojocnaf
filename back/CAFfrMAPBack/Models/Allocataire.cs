using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CAFfrMAPBack.Models
{
    public class Allocataire
    {
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string Numero { get; set; }
        public string AdresseComplete
        {
            get
            {
                return string.Format("{0} {1} {2}", this.Adresse1, this.CodePostal, this.Ville);
            }
        }

        public string Adresse1 { get; set; }
        public int CodePostal { get; set; }
        public string Ville { get; set; }
    }
}