using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Dapper.Contrib;
using Dapper.Contrib.Extensions;
using System.ComponentModel; //Sert à changer l'affichage du nom de la propritéé dans la BDD par un texte(Last Name au lieu de lastname par exemple)
using System.ComponentModel.DataAnnotations;

namespace Lime
{
    public class Magasin
    {
        public int ID { get; set; }
        public int ID_Adresses { get; set; }
        public string Libelle { get; set; }

        public Magasin()
        {
        }

        public Magasin(int ID_, int ID_Adresses_, string Libelle_)
        {
            this.ID = ID_;
            this.ID_Adresses = ID_Adresses_;
            this.Libelle = Libelle_;
        }
    }
}
