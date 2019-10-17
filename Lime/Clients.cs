using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace Lime
{
    class Clients
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

        public Connexion Connexion1 = new Connexion();
        public void GetAllClients()
        {
            if (Connexion.CheckForInternetConnection())
            {
                var maQuery = Connexion.maBDD.Query<Clients>("" +
                "SELECT * " +
                "FROM Clients " +
                "LIMIT @Limit " +
                ";"
                , new
                {
                    Limit = Properties.Settings.Default.Limit
                });

                IEnumerable<Clients> Client = maQuery;
                //RadGridView1.ItemsSource = Client;

            }
        }

        private void updateClient(int ID)
        {

        }

        private void deleteClient(int ID)
        {
        }
    }
}
