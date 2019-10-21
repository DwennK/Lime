using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Dapper.Contrib.Extensions;

namespace Lime
{
    public class Clients
    {
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

        public static IEnumerable<Clients> GetAllClients()
        {
            if (Connexion.CheckForInternetConnection())
            {
                IEnumerable<Clients> Client  = Connexion.maBDD.Query<Clients>("" +
                "SELECT * " +
                "FROM Clients " +
                "LIMIT @Limit " +
                ";"
                , new
                {
                    Limit = Properties.Settings.Default.Limite
                });
                return Client;
            }
            else 
            {
                //Retourne vide
                return Enumerable.Empty<Clients>();
            }
        }

        public static Clients getClient(int ID)
        {
            //Récupère le client avec l'ID passé en paramètre.
            return Connexion.maBDD.Get<Clients>(ID);

        }

        public static void UpdateClient(int ID)
        {

        }

        public static void DeleteClient(int ID)
        {
        }
    }
}
