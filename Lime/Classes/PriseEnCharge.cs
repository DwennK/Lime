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
    [Table("PriseEnCharges")]
    public class PriseEnCharge
    {
        [Computed]
        public int ID { get; set; }
        [Display(Name = "ID Client")]
        //Le "?" Sert à ce que le champs accepte un Null dans Dapper
        public int? ID_Client { get; set; }

        public static IEnumerable<PriseEnCharge> GetAllPriseEnCharge()
        {
            if (Connexion.CheckForInternetConnection())
            {
                IEnumerable<PriseEnCharge> priseEnCharge = Connexion.maBDD.Query<PriseEnCharge>("" +
                "SELECT * " +
                "FROM PriseEnCharge " +
                "LIMIT @Limit " +
                ";"
                , new
                {
                    Limit = Properties.Settings.Default.Limite
                });
                return priseEnCharge;
            }
            else
            {
                //Retourne vide
                return Enumerable.Empty<PriseEnCharge>();
            }
            
        }
    }
}
