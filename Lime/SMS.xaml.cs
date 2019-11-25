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
    /// Logique d'interaction pour SMS.xaml
    /// </summary>
    public partial class SMS : Window
    {
        public SMS()
        {
            InitializeComponent();

            webBrowser.Navigate("http://perdu.com", null, null,
                    "User-Agent: Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/74.0.3729.169 Safari/537.36");
        }
    }
}
