using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Lime
{
    // <summary>
    // Logique d'interaction pour App.xaml
    // </summary>  
    public partial class App : Application
    {
        public App()
        {

        }
        //Ceci va nous permettre de lancer la fenêtre de Login au démarrage de l'application.
        protected override void OnStartup(StartupEventArgs e)
        {
            new Login().Show();
            base.OnStartup(e);
        }
    }
}
