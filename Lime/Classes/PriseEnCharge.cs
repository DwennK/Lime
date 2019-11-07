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
        public int? ID_Clients { get; set; }        //Le "?" Sert à ce que le champs accepte un Null dans Dapper
        [Display(Name = "ID Adresse")]
        public int? ID_Adresses { get; set; } //Le "?" Sert à ce que le champs accepte un Null dans Dapper
        [Display(Name = "ID Magasin Source")]
        public int ID_MagasinSource { get; set; }
        [Display(Name = "ID Magasin Destination")]
        public int ID_MagasinDestination { get; set; }
        [Display(Name = "ID LieuActuelAppareil")]
        public int ID_LieuActuelAppareil { get; set; }
        public string Nom { get; set; }
        [Display(Name = "Téléphone 1")]
        public string Telephone1 { get; set; }
        [Display(Name = "Téléphone 2")]
        public string Telephone2 { get; set; }
        [Display(Name = "E-mail 1")]
        public string Email1 { get; set; }
        [Display(Name = "E-mail 2")]
        public string Email2 { get; set; }
        public DateTime DateDebut { get; set; }
        public DateTime DateEcheance { get; set; }
        public string CodeAppareil { get; set; }
        public string CodeSIM { get; set; }
        public string IMEI { get; set; }
        public string SerialNumber { get; set; }
        public string Commentaire { get; set; }
        public decimal RemisePermanente { get; set; }
        public string PersonneDeContact { get; set; }
        public bool PaiementSurFacture { get; set; }
        public bool AppareilRenduAuClient { get; set; }
        public bool Closed { get; set; }

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
