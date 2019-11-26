using Microsoft.Win32;
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




            //Registry.SetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Internet Explorer\MAIN\FeatureControl\FEATURE_BROWSER_EMULATION",
            //System.AppDomain.CurrentDomain.FriendlyName.Replace(".exe", ".vshost.exe"), 8000);



            webBrowser.Navigate("https://messages.google.com/web/", null, null,
                    "User-Agent: Chrome/74.0.3729.169");
        }
    }
}
