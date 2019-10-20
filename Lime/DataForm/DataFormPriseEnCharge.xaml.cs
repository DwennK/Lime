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
    /// Interaction logic for TelerikScenario1.xaml
    /// </summary>
    public partial class TelerikScenario1
    {
        public TelerikScenario1()
        {
            InitializeComponent();
            RemplirFormulaire();
        }

        private void RadDataForm_AutoGeneratingField(object sender, Telerik.Windows.Controls.Data.DataForm.AutoGeneratingFieldEventArgs e)
        {
            //Articles xx = new Articles(22, 22, 22, 22, "Libelle", 22.0, 22.0, true, 22, 22);
            //DataFormx.CurrentItem = xx;

        }

        private void RemplirFormulaire()
        {
            Articles xx = new Articles();
            DataFormx.CurrentItem = xx;
        }
    }
}
