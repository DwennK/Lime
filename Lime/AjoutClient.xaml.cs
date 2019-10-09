using Dapper;
using MySql.Data.MySqlClient;
using System;
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

using Telerik.Windows.Controls;

namespace Lime
{
    /// <summary>
    /// Interaction logic for TelerikScenario2.xaml
    /// </summary>
    public partial class AjoutClient
    {
        public AjoutClient()
        {
            InitializeComponent();
        }
        //GLOBAL
        string strConnexionString = ConfigurationManager.ConnectionStrings["ConnexionString"].ConnectionString;

        private void BtnCreerClient_Click(object sender, RoutedEventArgs e)
        {

            using (MySqlConnection Connexion = new MySqlConnection(strConnexionString))
            {
                //On crée l'adresse de facturation
                Connexion.Execute("INSERT INTO Adresses (Adresse, NPA,Ville) " +
                       "VALUES (" +
                       "@Adresse, " +
                       "@NPA, " +
                       "@Ville" +
                       ");"
                       , new
                       {
                           Adresse = tbxAdresseFacturation.Text,
                           NPA = tbxNPAFacturation.Text,
                           Ville = tbxNPAFacturation.Text
                       });

                //Une fois l'adresse de facturation créée, on va vérifier si elle est égale à l'adresse de livraison. Si elle n'est pas pareille, nous allons créer une adresse de livraison.
                if (tbxAdresseFacturation.Text != tbxAdresseLivraison.Text && tbxNPAFacturation != tbxNPALivraison && tbxVilleFacturation != tbxVilleLivraison)
                {
                    //Vu que les adresses sont différentes, on va spécifiquement créer une adresse de livraison
                    Connexion.Execute("INSERT INTO Adresses (Adresse, NPA,Ville) " +
                           "VALUES (" +
                           "@Adresse, " +
                           "@NPA, " +
                           "@Ville" +
                           ");"
                           , new
                           {
                               Adresse = tbxAdresseLivraison.Text,
                               NPA = tbxNPALivraison.Text,
                               Ville = tbxNPALivraison.Text
                           });
                }


                  Connexion.Execute("INSERT INTO Clients (Nom,Telephone1,Telephone2,Email1,Email2,Commentaire,RemisePermanente,PersonneDeContact) " +
                    "VALUES (@Nom, " +
                    "@Telephone1, " +
                    "@Telephone2," +
                    "@Email1, " +
                    "@Email2," +
                    "@Commentaire," +
                    "@RemisePermanente," +
                    "@PersonneDeContact );"
                    , new {
                        Nom = tbxNom.Text,
                        Telephone1 = tbxTelephone1.Value,
                        Telephone2 = tbxTelephone2.Value,
                        Email1 = tbxEmail1.Text,
                        Email2 = tbxEmail2.Text,
                        Commentaire = tbxCommentaire.Text,
                        RemisePermanente = (tbxRemisePermanente.Value < 0) ? 0 : tbxRemisePermanente.Value, //Si la valeur est < 0 on affecte 0 comme remise.
                        PersonneDeContact = tbxPersonneDeContact.Text
                    });

                //Ferme la fenêtre
                this.Close();
            }
        }
    }
}
