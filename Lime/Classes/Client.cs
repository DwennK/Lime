using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Dapper.Contrib;
using Dapper.Contrib.Extensions;

namespace Lime
{
    //Spécifie le nom de la table à Utiliser pour Dapper Contrib (Obligatoire)
    [Table("Clients")]
    public class Client
    {
        [Key]
        public int ID { get; set; }
        public int ID_AdresseFacturation { get; set; }
        public int ID_AdresseLivraison { get; set; }
        public string Nom { get; set; }
        public string Telephone1 { get; set; }
        public string Telephone2 { get; set; }
        public string Email1 { get; set; }
        public string Email2 { get; set; }
        public string Commentaire { get; set; }
        public double RemisePermanente { get; set; }
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
            var isSuccess = Connexion.maBDD.Update(new Client
            {
                ID = client.ID,
                ID_AdresseFacturation = client.ID_AdresseFacturation,
                ID_AdresseLivraison = client.ID_AdresseLivraison,
                Nom = client.Nom,
                Telephone1 = client.Telephone1,
                Telephone2 = client.Telephone2,
                Email1 = client.Email1,
                Email2 = client.Email2,
                Commentaire = client.Commentaire,
                RemisePermanente = client.RemisePermanente,
                PersonneDeContact = client.PersonneDeContact,
            }); ;
            return isSuccess;

        }

        public bool DeleteClient(int ID)
        {
            var isSuccess = Connexion.maBDD.Delete(new Client {ID = ID});
            return isSuccess;
        }
    }
}
