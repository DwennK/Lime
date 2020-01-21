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
    public partial class FormChercherArticle
    {
        public Article article = new Article();
        public IEnumerable<Article> ListeArticles;

        //Constructeur pour Insert
        public FormChercherArticle()
        {
            InitializeComponent();

            if(Connexion.CheckForInternetConnection())
            {
                ListeArticles = Connexion.maBDD.GetAll<Article>();
            }

            this.DataContext = this.ListeArticles;
            radGridView.ItemsSource = ListeArticles;
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

        private void btnValider_Click(object sender, RoutedEventArgs e)
        {
            if(radGridView.SelectedItem != null)
            {
                //Récupération de l'article
                if (Connexion.CheckForInternetConnection())
                {
                    var temp = (Article)radGridView.SelectedItem;
                    this.article = Connexion.maBDD.Get<Article>(temp.ID);
                }

                this.Close();
            }
            else //Si la sélection est vide
            {
                Alerte.SelectionVide();
            }

        }
    }
}
