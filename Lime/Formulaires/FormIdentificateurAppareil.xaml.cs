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
    public partial class FormIdentificateurAppareil
    {

        public IList<string> ListeModeles;
        public string URL;
        public string marque;
        public string model;

        //Constructeur pour Insert
        public FormIdentificateurAppareil()
        {
            InitializeComponent();



            this.DataContext = this.ListeModeles;
        }


        private void cmbMarque_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            marque = cmbMarque.Text;
        }

        private void tbxModel_TextChanged(object sender, TextChangedEventArgs e)
        {
            //On set le nom du modèle
            model = tbxModel.Text;

            //Sélection de la méthode à appeler en fonction de la marque choisie (Vu que on va demander ça a des sites différents)
            switch (marque)
            {
                case "Apple":
                    LookupApple();
                    break;

                case "Android":
                    LookupAndroid();
                    break;

                default: //Aucun
                    break;
            }
        }

        private void LookupApple()
        { 
            URL = "https://everymac.com/ultimate-mac-lookup/?search_keywords=";
            Browser.Address = URL + model;
        }

        private void LookupAndroid()
        {
            URL = "https://www.gsmarena.com/res.php3?sSearch=";
            Browser.Address = URL + model;
        }

    }
}
