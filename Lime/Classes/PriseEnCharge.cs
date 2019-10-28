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
        public int? ID_Adressess { get; set; } //Le "?" Sert à ce que le champs accepte un Null dans Dapper
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
        public TimeSpan HeureDebut { get; set; }
        public DateTime DateEcheance { get; set; }
        public TimeSpan HeureEcheance { get; set; }
        public string CodeAppareil { get; set; }
        public string CodeSIM { get; set; }
        public string IMEI { get; set; }
        public string SerialNumber { get; set; }
        public string Commentaire { get; set; }
        public decimal RemisePermanente { get; set; }
        public string PersonneDeContact { get; set; }
        public bool PaiementSurFacture { get; set; }
        public bool AppareilRenduAuClient { get; set; }
        public bool Cloturé { get; set; }

        public PriseEnCharge(int iD, int? iD_Clients, int? iD_Adressess, int iD_MagasinSource, int iD_MagasinDestination, int iD_LieuActuelAppareil, string nom, string telephone1, string telephone2, string email1, string email2, DateTime dateDebut, TimeSpan heureDebut, DateTime dateEcheance, TimeSpan heureEcheance, string codeAppareil, string codeSIM, string iMEI, string serialNumber, string commentaire, decimal remisePermanente, string personneDeContact, bool paiementSurFacture, bool appareilRenduAuClient, bool cloturé)
        {
            ID = iD;
            ID_Clients = iD_Clients;
            ID_Adressess = iD_Adressess;
            ID_MagasinSource = iD_MagasinSource;
            ID_MagasinDestination = iD_MagasinDestination;
            ID_LieuActuelAppareil = iD_LieuActuelAppareil;
            Nom = nom;
            Telephone1 = telephone1;
            Telephone2 = telephone2;
            Email1 = email1;
            Email2 = email2;
            DateDebut = dateDebut;
            HeureDebut = heureDebut;
            DateEcheance = dateEcheance;
            HeureEcheance = heureEcheance;
            CodeAppareil = codeAppareil;
            CodeSIM = codeSIM;
            IMEI = iMEI;
            SerialNumber = serialNumber;
            Commentaire = commentaire;
            RemisePermanente = remisePermanente;
            PersonneDeContact = personneDeContact;
            PaiementSurFacture = paiementSurFacture;
            AppareilRenduAuClient = appareilRenduAuClient;
            Cloturé = cloturé;
        }

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
