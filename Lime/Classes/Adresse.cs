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
        [Computed]
        public int ID { get; set; }
        public string adresse { get; set; }
        public string NPA { get; set; }
        public string Ville { get; set; }


        public static Adresse GetAdresse(int ID)
        {
            var Adresse = Connexion.maBDD.Get<Adresse>(ID);
            //Récupère l'objet avec l'ID passé en paramètre.
            return Adresse;

        }

        public static void InsertAdresse(Adresse adresse)
        {
            //Insère le client passé en paramètre
            Connexion.maBDD.Insert<Adresse>(adresse);

        }

        public bool UpdateAdresse(Adresse adresse)
        {
            var isSuccess = Connexion.maBDD.Update<Adresse>(adresse);
            return isSuccess;
        }

        public bool DeleteAdresse(int ID)
        {
            var isSuccess = Connexion.maBDD.Delete(new Adresse { ID = ID });
            return isSuccess;
        }

    }
}
