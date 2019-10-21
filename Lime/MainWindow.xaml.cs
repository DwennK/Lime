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

namespace Lime
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //Petit trick qui Va nous permettre d'accéder aux contrôle depuis une autre classe. (Par exemple : Lime.MainWindow.AppWindow.maFonction();
        public static MainWindow AppWindow;


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
            //Cet évènement est déclenché lors d'un double clic sur une Row dans le datagrid.

            //On récupère la ligne en entier ou l'utilisateur a cliqué
            var maRow = ((DataRowView)RadGridView1.SelectedItem).Row;
            //On récupére le contenu de la première Colonne, dans ce cas-ci, l'ID de la ligne dans la BDD
            string ID = maRow[0].ToString();
            MessageBox.Show("ID De ce tuple: "+ID,"ID :");

            //Une fois le DataGrid rempli, on cache la Colonne ID 
            //RadGridView1.Columns[0].Visibility = Visibility.Hidden;
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
                //On boucle dans chauqe ligne dans le dataSet
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

        private void AjoutClient_Click(object sender, RoutedEventArgs e)
        {
            //On ouvre la nouvelle fenêtre d'insertion client.
            AjoutClient maFenetre = new AjoutClient();
            maFenetre.Show();
        }


        private void TabClients_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            UpdateGridView(Client.GetAllClients());
        }

        private void TabArticles_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            UpdateGridView(Article.GetAllArticles());
        }
        
        //On recoit un IEnumerable, contenant un type de IEnumerable inconnu (Client ? Factures ? Prise en charge?), et donc, comme type, on met Ienumerable<object>, vu qu'ils en dérivent tous.
        private void UpdateGridView(IEnumerable<object> mesData)
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
            DataFormPriseEnCharge maFenetre = new DataFormPriseEnCharge();
            maFenetre.Show();

            DataFormClient maFenetre2 = new DataFormClient();
            maFenetre2.Show();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            //Récupère le client avec l'ID 1.
            
        }
    }
}
