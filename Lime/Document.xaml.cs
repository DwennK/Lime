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

        public Document(PriseEnCharge priseEnCharge)
        {
            InitializeComponent();
            this.priseEnCharge = priseEnCharge;
            this.DataContext = this.priseEnCharge;
        }


    }
}
