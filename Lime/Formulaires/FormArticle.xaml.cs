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
using Dapper;
using Dapper.Contrib;
using Dapper.Contrib.Extensions;
using System.Net;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Lime
{
    /// <summary>
    /// Interaction logic for FormClient.xaml
    /// </summary>
    public partial class FormArticle
    {
        public Article article = new Article();
        string Action;

        //Constructeur pour Insert
        public FormArticle(string action, string NomDuClient)
        {
            InitializeComponent();
            tbxLibelle.Focus();
            this.DataContext = this.article;
            Action = "Insert";



            CheckGestionStock();
        }

        private void CheckGestionStock()
        {
            if (article.GererStock == true)
            {
                tbxQuantiteStock.IsEnabled = true;
                tbxSeuilAlerte.IsEnabled = true;
            }
            else
            {
                tbxQuantiteStock.IsEnabled = false;
                tbxSeuilAlerte.IsEnabled = false;
            }
        }

        //Constructeur pour Update
        public FormClient(Client client)
        {
            InitializeComponent();
            tbxNom.Focus();
            this.client = client;
            this.DataContext = this.client;
            Action = "Update";


            Adresse adresseFacturation = Connexion.maBDD.Get<Adresse>(client.ID_Adresse);
            if (adresseFacturation != null)
            {
                if (adresseFacturation.adresse != null) { tbxAdresse.Text = adresseFacturation.adresse; }

                if (adresseFacturation.NPA != null) { tbxNPA.Text = adresseFacturation.NPA; }
                if (adresseFacturation.Ville != null) { tbxVille.Text = adresseFacturation.Ville; }
            }

            this.tbxVille.IsDropDownOpen = false;

        }


        private void InsertClient()
        {
            if (DonnéesValides())
            {

                //Une fois les deux adresse créées, on va finalement créer et insérer le client dans la BDD.
                client.ID_Adresse = idAdresseFacturation;
                Connexion.maBDD.Insert<Client>(client);

                //Ferme la Fenêtre
                this.Close();
            }

        }


        private void UpdateClient()
        {
            if (DonnéesValides())
            {

                //On update le client
                Connexion.maBDD.Update<Client>(client);

                //Ferme la fenêtre
                this.Close();

            }
        }

        private void btnValider_Click(object sender, RoutedEventArgs e)
        {
            //Ces actions sont définies par le constructeur appelé
            if (Action == "Insert")
            {
                InsertClient();
            }
            else if (Action == "Update")
            {
                UpdateClient();
            }
        }

        private bool DonnéesValides()
        {
            string messageErreur = string.Empty;
            bool isValidData = true;

            if (tbxNom.Text == "")
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
