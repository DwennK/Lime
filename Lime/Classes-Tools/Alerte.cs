using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telerik.Windows.Controls;

namespace Lime
{
    static class Alerte
    {
        public static void AlerteCustom(string messageAlerte)
        {
            RadWindow.Alert(new DialogParameters
            {
                Header = "Attention",
                Content = messageAlerte,
                Theme = new CrystalTheme()
            });

        }

        public static void SelectionVide()
        {
            RadWindow.Alert(new DialogParameters
            {
                Header = "Attention",
                Content = "Veuillez sélectionner un élément dans la liste.",
                Theme = new CrystalTheme()
            });

        }

        public static void NoMailAddressProvided()
        {
            RadWindow.Alert(new DialogParameters
            {
                Header = "Attention",
                Content = "La prise en charge ne contient pas d'adresse mail.",
                Theme = new CrystalTheme()
            });

        }


    }
}
