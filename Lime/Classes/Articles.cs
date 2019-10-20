using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lime
{
    class Articles
    {
        public int ID { get; set; }
        public int ID_CodeArticles { get; set; }
        public int ID_Marques { get; set; }
        public int ID_Categories { get; set; }
        public string Libelle { get; set; }
        public double Prixvente { get; set; }
        public double PrixAchat { get; set; }
        public bool GererStock { get; set; }
        public int QuantiteStock { get; set; }
        public int SeuilAlerte { get; set; }


    }
}
