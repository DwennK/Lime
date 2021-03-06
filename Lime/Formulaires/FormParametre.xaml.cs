﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Dapper;
using Dapper.Contrib;
using Dapper.Contrib.Extensions;
using System.Net;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Telerik.Windows.Controls;

namespace Lime
{
    /// <summary>
    /// Interaction logic for FormClient.xaml
    /// </summary>
    public partial class FormParametre
    {
        public Client client = new Client();

        public FormParametre()
        {
            InitializeComponent();

            //LIMITE DE LIGNES
            this.Limite.Value = Properties.Settings.Default.Limite;


            // TAUX TVA PAR DEFAUT
            if(Connexion.CheckForInternetConnection())
            {
                string SQL = "SELECT TauxTVAParDefaut FROM Parametres WHERE ID=@ID";
                Double TauxTVA = (Double)Connexion.maBDD.ExecuteScalar(SQL, new { ID = 1 }) ;

                this.TauxTVAParDefaut.Value = TauxTVA;
            }

            //emplacement de sauvegarde des documents
            EmplacementSauvegardeDocuments.FilePath = Properties.Settings.Default.EmplacementParDefaultDocuments;

        }



        private void btnValider_Click(object sender, RoutedEventArgs e)
        {
            //Sauvegarde de la limite dans les paramètres//
            Properties.Settings.Default.Limite = Convert.ToInt32(Limite.Value);
            Properties.Settings.Default.Save();
            Properties.Settings.Default.Reload();


            //Sauvegarde de la TVA Par défaut dans la BDD
            if (Connexion.CheckForInternetConnection())
            {
                string SQL = "UPDATE Parametres SET TauxTVAParDefaut=@NewtauxTVA WHERE ID=@ID";
                Connexion.maBDD.Query(SQL, new { NewtauxTVA=this.TauxTVAParDefaut.Value, ID = 1 });
            }


            //Sauvegarde de l'emplacement de sauvegarde des documents dans les paramètres
            Properties.Settings.Default.EmplacementParDefaultDocuments = EmplacementSauvegardeDocuments.FilePath;
            Properties.Settings.Default.Save();
            Properties.Settings.Default.Reload();

            this.Close();
        }


        private bool DonnéesValides()
        {
            string messageErreur = string.Empty;
            bool isValidData = true;

            if (isValidData == false)
            {
                messageErreur += "Veuillez rentrer le nom du client.\n";
            }

            //S'il y a des erreurs, on les affiche
            if (messageErreur != "")
            {
                RadWindow.Alert(new DialogParameters
                {
                    Header = "Erreur",
                    Content = messageErreur,
                    //Closed = maMethode(),  // Sert à appeler une methode quand on le ferme
                    Theme = new CrystalTheme()
                });
            }

            //On teste, et renvoie pour dire si les données sont valides
            if (messageErreur == string.Empty)
            {
                isValidData = true;
            }
            else
            {
                isValidData = false;
            }

            return isValidData;
        }


        //Quand on presse Enter, cela appelle cette méthode, qui va ensuite presser le bouton de validation du formulaire.
        private void OnKeyDownHandler(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                //On doit focus autre chose que le nom, comme ça les Bindings modifient correctement le client (Quand on leave le focus c'est là que l'objet se modifie)
                btnValider.Focus();
                btnValider_Click(sender, e);
            }
        }
    }
}
