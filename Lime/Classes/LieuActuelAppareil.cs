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

namespace Lime.Classes
{
    public class LieuActuelAppareil
    {
        public int ID { get; set; }
        public string Libelle { get; set; }

        public LieuActuelAppareil()
        {

        }


        public LieuActuelAppareil(int ID_, string Libelle_)
        {
            this.ID = ID_;
            this.Libelle = Libelle_;
        }
    }
}
