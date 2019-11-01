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
            
            //Insertion automatique de la Date dans le DatePickerDebut
            this.DatePickerDebut.SelectedDate = DateTime.Now;
            //Vu que la date de fin sera sûrement la même que aujourd'hui, on la mets automatiquement aussi dans le DatePickerEcheance
            this.DatePickerEcheance.SelectedDate = DateTime.Now;
        }

        public FormPriseEnCharge(PriseEnCharge priseEnCharge)
        {
            InitializeComponent();
            this.action = "Update";
            this.priseEnCharge = priseEnCharge;
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
    }
}
