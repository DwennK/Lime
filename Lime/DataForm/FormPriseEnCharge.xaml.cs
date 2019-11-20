﻿using System;
using System.Collections.Generic;
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

using Telerik.Windows.Controls;
using Dapper;
using Dapper.Contrib;
using Dapper.Contrib.Extensions;

namespace Lime
{
    /// <summary>
    /// Interaction logic for FormPriseEnCharge.xaml
    /// </summary>
    public partial class FormPriseEnCharge
    {

        string action = "";
        Client client = new Client();
        PriseEnCharge priseEnCharge = new PriseEnCharge();






        public FormPriseEnCharge()
        {
            InitializeComponent();
            this.DataContext = this.priseEnCharge;
            this.action = "Insert";

            grpDocuments.IsEnabled = false;
            //Insertion automatique de la Date dans le DatePic1kerDebut
            priseEnCharge.DateDebut = DateTime.Now;
            this.DatePickerDebut.IsEnabled = false;

            //Vu que la date de fin sera sûrement la même que aujourd'hui, on la mets automatiquement aussi dans le DatePickerEcheance
            priseEnCharge.DateEcheance = DateTime.Now;


            Populate();
        }

        public FormPriseEnCharge(int ID_PriseEnCharge)
        {
            InitializeComponent();
            this.tbxNom.Visibility = Visibility.Hidden;
            this.btnInsertClient.Visibility = Visibility.Hidden;
            this.priseEnCharge = Connexion.maBDD.Get<PriseEnCharge>(ID_PriseEnCharge);
            this.DataContext = priseEnCharge;
            this.action = "Update";


            grpDocuments.IsEnabled = true;
            //On met le client dans le GridView.
            this.client = Connexion.maBDD.Get<Client>(priseEnCharge.ID_Clients);
            RadGridView1.ItemsSource = client;
            RadGridView1.SelectedItem = client;


            this.DatePickerDebut.IsEnabled = false;

            Populate();
        }

        private void Populate()
        {

            #region Combobox Liste des Magasins Source
                //On vide, puis insère la liste des magasins dans le combobox approprié.
                ComboBoxMagasinSource.Items.Clear();
                ComboBoxMagasinSource.ItemsSource = Connexion.maBDD.GetAll<Magasin>();
                //Ce qu'on affiche textuellemtn dans le combobox.
                ComboBoxMagasinSource.DisplayMemberPath = "Libelle";
                //Ce qu'on veut comme valeur réelle qui sera sauvée (Donc l'ID du Magasin dans la BDD)
                ComboBoxMagasinSource.SelectedValuePath = "ID";

                //Sélectionne la valeur sauvée dans les paramètres
                priseEnCharge.ID_MagasinSource = Properties.Settings.Default.ID_Magasin;
            #endregion

            #region Combobox Liste des Magasins Destination
            //On vide, puis insère la liste des magasins dans le combobox approprié.
            ComboBoxMagasinDestination.Items.Clear();
                ComboBoxMagasinDestination.ItemsSource = Connexion.maBDD.GetAll<Magasin>();
                //Ce qu'on affiche textuellemtn dans le combobox.
                ComboBoxMagasinDestination.DisplayMemberPath = "Libelle";
                //Ce qu'on veut comme valeur réelle qui sera sauvée (Donc l'ID du Magasin dans la BDD)
                ComboBoxMagasinDestination.SelectedValuePath = "ID";

                //Sélectionne la valeur sauvée dans les paramètres
                priseEnCharge.ID_MagasinDestination = Properties.Settings.Default.ID_Magasin;
            #endregion


            #region Combobox Lieu actuel de l'appareil
            //On vide, puis insère la liste des magasins dans le combobox approprié.
            ComboBoxLieuActuelAppareil.Items.Clear();
                ComboBoxLieuActuelAppareil.ItemsSource = Connexion.maBDD.GetAll<LieuActuelAppareil>();
                //Ce qu'on affiche textuellemtn dans le combobox.
                ComboBoxLieuActuelAppareil.DisplayMemberPath = "Libelle";
                //Ce qu'on veut comme valeur réelle qui sera sauvée (Donc l'ID du Magasin dans la BDD)
                ComboBoxLieuActuelAppareil.SelectedValuePath = "ID";
            #endregion


        }

        private void btnValider_Click(object sender, RoutedEventArgs e)
        {
            //Ces actions sont définies par le constructeur appelé
            if(DonnéesValides())
            {


                if (action == "Insert")
                {
                    //On insère la prise en charge dans la BDD, et on récupère l'ID.
                    var id = Connexion.maBDD.Insert(priseEnCharge);
                    this.priseEnCharge.ID = (int)id;
                }
                else if (action == "Update")
                {
                    Connexion.maBDD.Update<PriseEnCharge>(priseEnCharge);
                }

                //On enable les boutons en dessous
                grpDocuments.IsEnabled = true;
            }

        }

        private bool DonnéesValides()
        {
            string messageErreur = string.Empty;
            bool isValidData = true;

            if (client.ID == 0)
            {
                messageErreur += "Veuillez sélectionner un client existant dans la liste.\n";
            }
            if(priseEnCharge.ID_LieuActuelAppareil == 0)
            {
                messageErreur += "Veuillez sélectionner le lieu actuel de l'appareil\n";
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

        private void btnInsertClient_Click(object sender, RoutedEventArgs e)
        {
            FormClient maFenetre = new FormClient("Insert");
            maFenetre.ShowDialog();

            client = maFenetre.client;
            priseEnCharge.Nom = client.Nom;
            priseEnCharge.ID_Adresses = client.ID_Adresse;

        }


        private void tbxNom_TextChanged(object sender, TextChangedEventArgs e)
        {
            //On rempli le gridview de la liste des clients qui ont ce nom.
            var NomClient = tbxNom.Text;
            var sql = "SELECT * FROM Clients WHERE Nom LIKE @NomClient ";
            IEnumerable<Client> ListClient = Connexion.maBDD.Query<Client>(sql, new { NomClient = "%"+NomClient+"%" });

            RadGridView1.ItemsSource = ListClient;
        }


        //Après un click sur un Client dans le GridView, on l'affecte.
        private void RadGridView1_SelectionChanged(object sender, SelectionChangeEventArgs e)
        {
            this.client = (Client)RadGridView1.SelectedItem;
            priseEnCharge.Nom = client.Nom;
            priseEnCharge.Telephone1 = client.Telephone1;
            priseEnCharge.Telephone2 = client.Telephone2;
            priseEnCharge.Email1 = client.Email1;
            priseEnCharge.Email2 = client.Email2;
            priseEnCharge.PersonneDeContact = client.PersonneDeContact;
            priseEnCharge.RemisePermanente = client.RemisePermanente;
            priseEnCharge.PersonneDeContact = client.PersonneDeContact;
        }

        private void btnDevis_Click(object sender, RoutedEventArgs e)
        {
            FormDocument maFenetre = new FormDocument(this.priseEnCharge, 1);
            maFenetre.Show();
        }
    }
}
