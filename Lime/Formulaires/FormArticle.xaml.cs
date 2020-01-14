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
        public FormArticle(Article _article)
        {
            InitializeComponent();
            tbxLibelle.Focus();

            this.article = _article;
            this.DataContext = this.article;

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

        private void GererStock_changed(object sender, RoutedEventArgs e)
        {
            CheckGestionStock();
        }


        private void Upsert()
        {
            if (DonnéesValides())
            {

                //On check si la ligne existe. Si elle existe on la met à jour, autrement on l'insert.
                var exists = Connexion.maBDD.ExecuteScalar<bool>("SELECT COUNT(1) FROM Articles WHERE ID=@ID", new { article.ID });
                if (exists)
                {
                    //Insertion des la ligne dans la BDD.
                    Connexion.maBDD.Update(article);
                }
                else //La Ligne n'existe pas dans la BDD, il faut donc l'insérer.
                {
                    //Check si le code Article existe



                    //Insertion des la ligne dans la BDD.
                    Connexion.maBDD.Insert(article);
                }

                //Ferme la Fenêtre
                this.Close();
            }

        }


        private void btnValider_Click(object sender, RoutedEventArgs e)
        {
            //Update or Insert, depends if item already exists.
            Upsert();
        }

        private bool DonnéesValides()
        {
            string messageErreur = string.Empty;
            bool isValidData = true;

            if (tbxLibelle.Text == "")
            {
                messageErreur += "Veuillez rentrer le Libellé de l'article.\n";
            }

            if (tbxPrixVente.Value == 0)
            {
                messageErreur += "Veuillez rentrer le Prix de Vente de l'article.\n";
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
