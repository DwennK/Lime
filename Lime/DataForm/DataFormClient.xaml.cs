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
using Dapper;
using Dapper.Contrib;
using Dapper.Contrib.Extensions;

namespace Lime
{
    /// <summary>
    /// Interaction logic for DataFormClient.xaml
    /// </summary>
    public partial class DataFormClient
    {
        public DataFormClient()
        {
            InitializeComponent();
            RemplirFormulaire();
        }

        private void RemplirFormulaire()
        {
            //Connexion.maBDD.Open();
            

            //DataFormx.ItemsSource = xx;
            //Connexion.maBDD.Close();

        }
    }
}
