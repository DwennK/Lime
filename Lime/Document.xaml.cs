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

namespace Lime
{
    /// <summary>
    /// Interaction logic for Document.xaml
    /// </summary>
    public partial class Document
    {
        //Globals
        PriseEnCharge priseEnCharge;
        List<Documents_Lignes> Lignes;


        public Document(PriseEnCharge priseEnCharge)
        {
            InitializeComponent();

            //On crée un DataContext qui contient deux variables. Comme ça, on peut accéder auy souséléments en XAML avec par exemple Text="{Binding priseEnCharge.nom}" ))  :)
            DataContext = new
            {
                priseEnCharge,
                Lignes
            };


        }






    }
}

