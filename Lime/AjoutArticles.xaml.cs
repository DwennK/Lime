using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace Lime
{
    /// <summary>
    /// Logique d'interaction pour AjoutArticles.xaml
    /// </summary>
    public partial class AjoutArticles : Window
    {
        public AjoutArticles()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            System.Windows.Data.CollectionViewSource clientViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("clientViewSource")));
            // Charger les données en définissant la propriété CollectionViewSource.Source :
            // clientViewSource.Source = [source de données générique]
            System.Windows.Data.CollectionViewSource typeDocumentsViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("typeDocumentsViewSource")));
            // Charger les données en définissant la propriété CollectionViewSource.Source :
            // typeDocumentsViewSource.Source = [source de données générique]
        }
    }
}
