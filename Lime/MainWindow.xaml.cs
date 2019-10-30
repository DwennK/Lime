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
using System.Runtime.InteropServices;

namespace Lime
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //Petit trick qui Va nous permettre d'accéder aux contrôle depuis une autre classe. (Par exemple : Lime.MainWindow.AppWindow.maFonction();
        public static MainWindow AppWindow;
        //Petit trick qui Va nous permettre d'accéder aux contrôle depuis une autre classe. (Par exemple : Lime.MainWindow.AppWindow.maFonction();
        void Awake()
        {
            AppWindow = this;
        }


        public MainWindow()
        {
            InitializeComponent();
            Properties.Settings.Default.Reload();
            this.Limite.Value = Properties.Settings.Default.Limite;
            
        }

        //GLOBAL VARIABLES
        readonly string strConnexionString = ConfigurationManager.ConnectionStrings["ConnexionString"].ConnectionString;




        //RowActivated = DoubleClick sur un ligne
        private void RadGridView1_RowActivated(object sender, Telerik.Windows.Controls.GridView.RowEventArgs e)
        {
            //A modifier pour modifier aussi les autres types de documents !
            ModifierClient_Click(sender, e);
        }
        

        private void GetData(string strCommandeSQL)
        {
            if(Connexion.CheckForInternetConnection())
            {
        
                MySqlConnection xxxConnexion = new MySqlConnection(strConnexionString);
                lblStatusConnexion.Content = strConnexionString;

                MySqlCommand cmd = new MySqlCommand(strCommandeSQL, xxxConnexion);
                MySqlDataAdapter sda = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable("xxxDataGrid");
                sda.Fill(dt);


                //RETIRER TOUT LES CRLF Des chamnps !
                int numberOfColumns = dt.Columns.Count;
                //On boucle dans chaque ligne dans le dataSet
                foreach (DataRow dr in dt.Rows)
                {
                    //Maintenant, on boucle dans chaque cellule de la ligne en cours
                    for (int i = 0; i < numberOfColumns; i++)
                    {
                        // access cell as set or get
                        // dr[i] = "something";
                        // string something = Convert.ToString(dr[i]);

                        //A l'aide d'un Régex, on remplace tout les \r, \n, et \t avec un string vide. :) Ceci causait un problème d'afichage plus loin une fois mise dans le RadGridView.
                        if (dr[i] is string) //Test de string Afin de ne pas avoir d'erreur sur la clé primaire, les dates etc etc..
                        {
                            dr[i] = Regex.Replace((string)dr[i], "[\\r\\n\\t]", string.Empty);
                        }

                    }

                }
                //RETIRER TOUT LES CRLF Des chamnps !
                RadGridView1.ItemsSource = dt.DefaultView;
            }
            

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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //RadDataFormClient maFenetre2 = new RadDataFormClient(Get);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Connexion.maBDD.Open();
            var clients = Connexion.maBDD.GetAll<Client>().ToList();

            clients[1].Nom = "x0";


            Connexion.maBDD.Update(clients);

            Connexion.maBDD.Close();



        }

        private void AjoutClient_Click(object sender, RoutedEventArgs e)
        {
            FormClient maFenetre = new FormClient();
            maFenetre.Closed += FormClientHandler;
            maFenetre.Show();
        }

        //Se fait appeler quand une modification/ajout d'un client a eu lieu, mais dans une autre fenêtre que celle-ci (la methode UpdateGridView ne peux pas se faire appeler depuis une autre fenetre)
        public void FormClientHandler(object sender, EventArgs e)
        {
            UpdateGridView(Connexion.maBDD.GetAll<Client>());
        }

        //Se fait appeler quand une modification/ajout d'un client a eu lieu, mais dans une autre fenêtre que celle-ci (la methode UpdateGridView ne peux pas se faire appeler depuis une autre fenetre)
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

            //Si le client confirme la supression, alor son supprime vraiment le client.
            var result = e.DialogResult;
            if (result == true)
            {
                Client client = (Client)RadGridView1.SelectedItem;
                Connexion.maBDD.Delete<Client>(client);
                UpdateGridView(Connexion.maBDD.GetAll<Client>());
            }
        }

        private void RadRibbonButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void tabClients_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            UpdateGridView(Connexion.maBDD.GetAll<Client>());
        }

        private void tabArticles_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            UpdateGridView(Connexion.maBDD.GetAll<Article>());
        }

        private void tabPriseEnCharge_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            UpdateGridView(Connexion.maBDD.GetAll<PriseEnCharge>());
        }

        private void InsertPriseEnCharge(object sender, RoutedEventArgs e)
        {
            FormPriseEnCharge maFenetre = new FormPriseEnCharge();
            maFenetre.Closed += FormPriseEnChargeHandler;
            maFenetre.Show();
        }

        private void UpdatePriseEnCharge_Click(object sender, RoutedEventArgs e)
        {

        }

        private void DeletePriseEnCharge_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
