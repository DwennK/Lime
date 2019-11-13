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
using System.ComponentModel.DataAnnotations;

namespace Lime
{
    /// <summary>
    /// Interaction logic for Document.xaml
    /// </summary>
    public partial class Document
    {
        //Globals
        PriseEnCharge priseEnCharge = new PriseEnCharge();
        Client client = new Client();
        List<Documents_Lignes> Lignes = new List<Documents_Lignes>();
        


        public Document(PriseEnCharge priseEnCharge)
        {
            InitializeComponent();


            //On crée un DataContext qui contient nos variables. Comme ça, on peut accéder auy souséléments en XAML avec par exemple Text="{Binding priseEnCharge.nom}" ))  :)
            DataContext = new
            {
                priseEnCharge = priseEnCharge,
                client = Connexion.maBDD.Get<Client>(this.priseEnCharge.ID_Clients),
                Lignes
            };
        }

        private void btnValider_Click(object sender, RoutedEventArgs e)
        {
            



            this.Close();
        }
    }
}

