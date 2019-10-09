using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lime
{
    class Clients
    {
        public int ID { get; set; }
        public int ID_AdresseFacturation { get; set; }
        public int ID_AdresseLivraison { get; set; }
        public string Nom { get; set; }
        public string Telephone1 { get; set; }
        public string Telephone2 { get; set; }
        public string Email1 { get; set; }
        public string Email2 { get; set; }
        public string Commentaire { get; set; }
        public double RemisePermanente { get; set; }
        public string PersonneDeContact { get; set; }


    }
}
