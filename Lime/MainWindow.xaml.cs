using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Configuration;
using MySql.Data.MySqlClient; //MYSQL
using Telerik.Windows.Controls;
using Telerik.Windows.Controls.GridView;
using System.Text.RegularExpressions;
using Dapper;
using Dapper.Contrib;
using Dapper.Contrib.Extensions;
using System.Data.SqlClient;
using System.Globalization;
using System.Threading;

namespace Lime
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //GLOBAL VARIABLES
        readonly static string strConnexionString = ConfigurationManager.ConnectionStrings["ConnexionString"].ConnectionString;
        SqlConnectionStringBuilder sqlString = new SqlConnectionStringBuilder(strConnexionString);

        public MainWindow()
        {
            InitializeComponent();
            Properties.Settings.Default.Reload();
            this.Limite.Value = Properties.Settings.Default.Limite;

     // Change current culture
            CultureInfo culture;
                culture = CultureInfo.CreateSpecificCulture("fr-FR");

            Thread.CurrentThread.CurrentCulture = culture;
            Thread.CurrentThread.CurrentUICulture = culture;

            //IP Server dans la statusBar
            this.lblStatusConnexion.Content = "Server :" + sqlString.DataSource;
            this.lblDatabase.Content = "Database :" + sqlString.InitialCatalog;
        }

      

        private void tabClients_Click(object sender, RoutedEventArgs e)
        {
            UpdateGridView(Client.GetAllClients().ToList());
        }

        
        //On recoit un IEnumerable, contenant un type de IEnumerable inconnu (Client ? Factures ? Prise en charge?), et donc, comme type, on met Ienumerable<object>, vu qu'ils en dérivent tous.
        public void UpdateGridView(IEnumerable<object> mesData)
        {
            this.RadGridView1.ItemsSource = mesData;
        }

        private void Limite_LostFocus(object sender, RoutedEventArgs e)
        {
            //Sauvegarde de la limite dans les paramètres//
            Properties.Settings.Default.Limite = Convert.ToInt32(Limite.Value);
            Properties.Settings.Default.Save();
            Properties.Settings.Default.Reload();
        }


        private void AjoutClient_Click(object sender, RoutedEventArgs e)
        {
            FormClient maFenetre = new FormClient("Insert");
            maFenetre.Closed += FormClientHandler;
            maFenetre.Show();
        }

        //Se fait appeler quand une modification/ajout d'un client a eu lieu, mais dans une autre fenêtre que celle-ci (la methode UpdateGridView ne peux pas se faire appeler depuis une autre fenetre)
        public void FormClientHandler(object sender, EventArgs e)
        {
            UpdateGridView(Connexion.maBDD.GetAll<Client>());
        }

        //Se fait appeler quand une modification/ajout a eu lieu, mais dans une autre fenêtre que celle-ci (la methode UpdateGridView ne peux pas se faire appeler depuis une autre fenetre)
        public void FormPriseEnChargeHandler(object sender, EventArgs e)
        {
            UpdateGridView(Connexion.maBDD.GetAll<PriseEnCharge>());
        }


        private void ModifierClient_Click(object sender, RoutedEventArgs e)
        {
            Client client = (Client)RadGridView1.SelectedItem;
            FormClient maFenetre2 = new FormClient(client);
            maFenetre2.Closed += FormClientHandler;
            maFenetre2.Show();
        }

        private void SupprimmerClient_Click(object sender, RoutedEventArgs e)
        {
            RadWindow.Confirm(new DialogParameters
            {
                Header = "Attention",
                Content = "Êtes-vous sûr de vouloir supprimer ce client ?\nCette action est définitive",
                Closed = this.SupprimmerClient_Click_OnClosed,  
                Theme = new CrystalTheme()
            });

        }

        private void SupprimmerClient_Click_OnClosed(object sender, WindowClosedEventArgs e)
        {
            if(Connexion.CheckForInternetConnection())
            {
                //Si le client confirme la supression, alors son supprime vraiment l'item.
                var result = e.DialogResult;
                if (result == true)
                {
                    Client client = (Client)RadGridView1.SelectedItem;
                    Connexion.maBDD.Delete<Client>(client);
                    UpdateGridView(Connexion.maBDD.GetAll<Client>());
                }
            }
        }

        private void RadRibbonButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void tabClients_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (Connexion.CheckForInternetConnection())
            {
                UpdateGridView(Connexion.maBDD.GetAll<Client>());
            }
        }

        private void tabArticles_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (Connexion.CheckForInternetConnection())
            {
                UpdateGridView(Connexion.maBDD.GetAll<Article>());
            }
        }

        private void tabPriseEnCharge_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if(Connexion.CheckForInternetConnection())
            {
                UpdateGridView(Connexion.maBDD.GetAll<PriseEnCharge>());
            }
        }

        private void InsertPriseEnCharge(object sender, RoutedEventArgs e)
        {
            FormPriseEnCharge maFenetre = new FormPriseEnCharge();
            maFenetre.Closed += FormPriseEnChargeHandler;
            maFenetre.Show();
        }

        private void UpdatePriseEnCharge_Click(object sender, RoutedEventArgs e)
        {
            if(RadGridView1.SelectedItem != null)
            {
                PriseEnCharge priseEnCharge = (PriseEnCharge)RadGridView1.SelectedItem;


                FormPriseEnCharge maFenetre = new FormPriseEnCharge(priseEnCharge);
                maFenetre.Closed += FormPriseEnChargeHandler;
                maFenetre.Show();
            }

        }

        private void DeletePriseEnCharge_Click(object sender, RoutedEventArgs e)
        {


            RadWindow.Confirm(new DialogParameters
            {
                Header = "Attention",
                Content = "Êtes-vous sûr de vouloir supprimer cet élément ?\nCette action est définitive",
                Closed = DeletePriseEnCharge_Click_OnClosed,
                Theme = new CrystalTheme()
            });

        }

        private void DeletePriseEnCharge_Click_OnClosed(object sender, WindowClosedEventArgs e)
        {
            if (Connexion.CheckForInternetConnection())
            {
                //Si le client confirme la supression, alors on supprime vraiment l'item.
                var result = e.DialogResult;
                if (result == true)
                {
                    PriseEnCharge priseEnCharge = (PriseEnCharge)RadGridView1.SelectedItem;
                    Connexion.maBDD.Delete<PriseEnCharge>(priseEnCharge);
                    UpdateGridView(Connexion.maBDD.GetAll<PriseEnCharge>());
                }
            }
        }

    }
}
