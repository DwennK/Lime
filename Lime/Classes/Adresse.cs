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
    //Spécifie le nom de la table à Utiliser pour Dapper Contrib (Obligatoire)
    [Table("Adresses")]
    public class Adresse
    {
        
        public int ID { get; set; }
        public string adresse { get; set; }
        public string NPA { get; set; }
        public string Ville { get; set; }

        public Adresse(int ID, string adresse, string NPA, string Ville)
        {
            this.ID = ID;
            this.adresse = adresse;
            this.NPA = NPA;
            this.Ville = Ville;
        }


    }
}
