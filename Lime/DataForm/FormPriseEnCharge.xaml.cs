using System;
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
        PriseEnCharge priseEnCharge;
        public FormPriseEnCharge()
        {
            InitializeComponent();
            this.action = "Insert";
            
            //Insertion automatique de la Date dans le DatePic1kerDebut
            this.DatePickerDebut.SelectedValue = DateTime.Now;
            this.DatePickerDebut.IsEnabled = false;

            //Vu que la date de fin sera sûrement la même que aujourd'hui, on la mets automatiquement aussi dans le DatePickerEcheance
            this.DatePickerEcheance.SelectedValue = DateTime.Now;


            Populate();

        }

        public FormPriseEnCharge(PriseEnCharge priseEnCharge)
        {
            InitializeComponent();
            this.action = "Update";
            this.priseEnCharge = priseEnCharge;
            Populate();
        }

        private void Populate()
        {
            #region Combobox Liste des Magasins
                //On vide, puis insère la liste des magasins dans le combobox approprié.
                ComboBoxMagasin.Items.Clear();
                ComboBoxMagasin.ItemsSource = Connexion.maBDD.GetAll<Magasin>();
                //Ce qu'on affiche textuellemtn dans le combobox.
                ComboBoxMagasin.DisplayMemberPath = "Libelle";
                //Ce qu'on veut comme valeur réelle qui sera sauvée (Donc l'ID du Magasin dans la BDD)
                ComboBoxMagasin.SelectedValuePath = "ID";
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
            if (action == "Insert")
            {
                //InsertClient();
            }
            else if (action == "Update")
            {
                //UpdateClient();
            }
        }

        private bool DonnéesValides()
        {
            string messageErreur = string.Empty;
            bool isValidData = true;

            //if (tbxNom.Text == "")
            //{
            //    messageErreur += "Veuillez rentrer le nom du client.\n";
            //}

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

        }

        private void btnSearchClient_Click(object sender, RoutedEventArgs e)
        {
            FormClient maFenetre = new FormClient();
        }
    }
}
