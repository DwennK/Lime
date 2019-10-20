﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;

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

        public static void GetAllClients()
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
                    Limit = Properties.Settings.Default.Limite
                });

                IEnumerable<Clients> Client = maQuery;

                //On update le GridView dans la fenêtre principale
                MainWindow.AppWindow.UpdateGridView(Client);

            }
        }

        public static void UpdateClient(int ID)
        {

        }

        public static void DeleteClient(int ID)
        {
        }
    }
}
