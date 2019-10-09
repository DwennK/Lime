using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
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
//MYSQL
using MySql.Data.MySqlClient;
using Telerik.Windows.Controls;
using Telerik.Windows.Controls.GridView;
using System.Text.RegularExpressions;
using Dapper; //Dapper Micro ORM


using System.Net; //Permet d'utiliser WebClient, nécessaire à tester la connection à internet.

namespace Lime
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            
        }
        //GLOBAL VARIABLES
        string strConnexionString = ConfigurationManager.ConnectionStrings["ConnexionString"].ConnectionString;




        //RowActivaed = DoubleClick sur un ligne
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
            if(CheckForInternetConnection())
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

        public static bool CheckForInternetConnection()
        {
            try
            {
                using (var client = new WebClient())
                using (client.OpenRead("http://clients3.google.com/generate_204"))
                {
                    return true;
                }
            }
            catch
            {
                RadWindow.Alert(new DialogParameters
                {
                    Header = "Aucun accès à Internet",
                    Content = "Voici quelques conseils : \n\n• Vérifiez les câbles réseau, le modem et le routeur.\n• Reconnectez - vous au réseau Wi - Fi\n• Exécutez les diagnostics réseau de Windows\n",
                    //Closed = maMethode(),  // Sert à appeler une methode quand on le ferme
                    Theme = new CrystalTheme()
                });
                return false;
            }
        }

        private void btnFactures_Click(object sender, RoutedEventArgs e)
        { 
            //TODO()
        }

        private void btnClients_Click(object sender, RoutedEventArgs e)
        {
            if (CheckForInternetConnection())
            {
                using (MySqlConnection Connexion = new MySqlConnection(strConnexionString))
                {
                    var maQuery = Connexion.Query<Clients>("" +
                    "SELECT * " +
                    "FROM Clients " +
                    "LIMIT @Limit " +
                    ";"
                    , new
                    {
                        Limit = Limite.Value
                    });

                    IEnumerable<Clients> Client = maQuery;
                    RadGridView1.ItemsSource = Client;
                }
            }

        }

        private void btnArticles_Click(object sender, RoutedEventArgs e)
        {
            if (CheckForInternetConnection())
            {
                using (MySqlConnection Connexion = new MySqlConnection(strConnexionString))
                {
                    var maQuery = Connexion.Query<Articles>("" +
                    "SELECT * " +
                    "FROM Articles " +
                    "LIMIT @Limit " +
                    ";"
                    , new
                    {
                        Limit = Limite.Value
                    });

                    IEnumerable<Articles> Article = maQuery;
                    RadGridView1.ItemsSource = Article;
                }
            }

        }

        private void btnMethodePaiement_Click(object sender, RoutedEventArgs e)
        {
            if (CheckForInternetConnection())
            {
                using (MySqlConnection Connexion = new MySqlConnection(strConnexionString))
                {
                    var maQuery = Connexion.Query<TypeDocuments>("" +
                        "SELECT * " +
                        "FROM MethodePaiements " +
                        "LIMIT " + Limite.Value);

                    IEnumerable<TypeDocuments> TypeDocument = maQuery;
                    RadGridView1.ItemsSource = TypeDocument;
                }
            }
        }

        private void AjoutClient_Click(object sender, RoutedEventArgs e)
        {
            //On ouvre la nouvelle fenêtre d'insertion client.
            AjoutClient maFenetre = new AjoutClient();
            maFenetre.Show();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(xxx.Value);
        }
    }
}
