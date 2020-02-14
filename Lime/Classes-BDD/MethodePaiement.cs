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
using System.Configuration;
using MySql.Data.MySqlClient;

namespace Lime
{
    [Serializable]
    //Spécifie le nom de la table à Utiliser pour Dapper Contrib (Obligatoire)
    [Table("MethodePaiements")]
    public class MethodePaiement
    {

        [Computed]
        [Browsable(false)] //Permet de ne pas afficher la colonne dans les DataGrid par exemple.
        public int ID { get; set; }
        public string Libelle { get; set; }

        public MethodePaiement()
        {

        }

        public MethodePaiement(int ID_, string Libelle_)
        {
            this.ID = ID_;
            this.Libelle = Libelle_;
        }
    }


}
