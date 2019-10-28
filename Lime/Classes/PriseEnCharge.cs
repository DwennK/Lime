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
