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
using Dapper.Contrib.Extensions;

namespace Lime
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login
    {
        Magasin magasin = new Magasin();

        public Login()
        {
            InitializeComponent();

            #region Populate Combobox Liste des Magasins
            //On vide, puis insère la liste des magasins dans le combobox approprié.
            cmbMagasin.Items.Clear();
            cmbMagasin.ItemsSource = Connexion.maBDD.GetAll<Magasin>();
            //Ce qu'on affiche textuellemtn dans le combobox.
            cmbMagasin.DisplayMemberPath = "Libelle";
            //Ce qu'on veut comme valeur réelle qui sera sauvée (Donc l'ID du Magasin dans la BDD)
            cmbMagasin.SelectedValuePath = "ID";
            #endregion

            this.DataContext = magasin;

            //Si un magasin a déjà été sélectionné une fois auparavant (et donc sauvé dans les settings), on le sélectionne automatiquement.
            magasin.ID = Properties.Settings.Default.ID_Magasin;

        }

        private void RadButton_Click(object sender, RoutedEventArgs e)
        {
            //Sauvegarde du magasins dans les paramètres//
            Properties.Settings.Default.ID_Magasin = Convert.ToInt32(magasin.ID);
            Properties.Settings.Default.Save();
            Properties.Settings.Default.Reload();


            //On ouvre la MainWindow
            MainWindow main = new MainWindow();
            main.Show();

            this.Close();
        }
    }
}
