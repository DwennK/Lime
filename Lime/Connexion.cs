using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Telerik.Windows.Controls;

namespace Lime
{
    class Connexion
    {


        public static bool CheckForInternetConnection()
        {
            try
            {
                using (var client = new WebClient())
                using (client.OpenRead("http://clients3.google.com/generate_204"))
                {
                    return true;
                }
            }
            catch
            {
                RadWindow.Alert(new DialogParameters
                {
                    Header = "Aucun accès à Internet",
                    Content = "Voici quelques conseils : \n\n• Vérifiez les câbles réseau, le modem et le routeur.\n• Reconnectez - vous au réseau Wi - Fi\n• Exécutez les diagnostics réseau de Windows\n",
                    //Closed = maMethode(),  // Sert à appeler une methode quand on le ferme
                    Theme = new CrystalTheme()
                });
                return false;
            }
        }
    }
}
