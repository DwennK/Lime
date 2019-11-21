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
    [Table("Clients")]
    public class Client
    {
        [Dapper.Contrib.Extensions.ExplicitKey]
        [Browsable(false)] //Permet de ne pas afficher la colonne dans les DataGrid par exemple.
        [Computed]
        public int ID { get; set; }
        [Browsable(false)] //Permet de ne pas afficher la colonne dans les DataGrid par exemple.
        [Display(Name = "ID Adresse")]
        //Le "?" Sert à ce que le champs accepte un Null dans Dapper
        public int? ID_Adresse { get; set; }
        public string Nom { get; set; }
        [Display(Name = "Téléphone 1")]
        public string Telephone1 { get; set; }
        [Display(Name = "Téléphone 2")]
        public string Telephone2 { get; set; }
        [Display(Name = "E-mail 1")]
        public string Email1 { get; set; }
        [Display(Name = "E-mail 2")]
        public string Email2 { get; set; }
        public string Commentaire { get; set; }
        [Display(Name = "Remise permanente")]
        [Description("Le rabais automatique appliqué, en pourcentage, dont disposera le client.")]
        public int RemisePermanente { get; set; }
        [Display(Name = "Personne de contact")]
        public string PersonneDeContact { get; set; }

        public static IEnumerable<Client> GetAllClients()
        {
            if (Connexion.CheckForInternetConnection())
            {
                IEnumerable<Client> Clients = Connexion.maBDD.Query<Client>("" +
                "SELECT * " +
                "FROM Clients " +
                "LIMIT @Limit " +
                ";"
                , new
                {
                    Limit = Properties.Settings.Default.Limite
                });
                return Clients;
            }
            else
            {
                //Retourne vide
                return Enumerable.Empty<Client>();
            }
            
        }

        public static Client GetClient(int ID)
        {
            var leClient = Connexion.maBDD.Get<Client>(ID);
            //Récupère le client avec l'ID passé en paramètre.
            return leClient;

        }

        public static void InsertClient(Client client)
        {
            //Insère le client passé en paramètre
            Connexion.maBDD.Insert<Client>(client);

        }

        public bool UpdateClient(Client client)
        {
           var isSuccess =  Connexion.maBDD.Update<Client>(client);
            return isSuccess;
        }

        public bool DeleteClient(int ID)
        {
            var isSuccess = Connexion.maBDD.Delete(new Client {ID = ID});
            return isSuccess;
        }
    }
}
