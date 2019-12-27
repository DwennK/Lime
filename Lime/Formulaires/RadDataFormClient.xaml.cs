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
    /// Interaction logic for DataForm.xaml
    /// </summary>
    public partial class RadDataFormClient
    {

        List<Client> _mesData;
        string _Action;
        public RadDataFormClient(string action, List<Client> mesData)
        {
            InitializeComponent();
            _Action = action;
            _mesData = mesData;
            RemplirFormulaire();
        }

        private void RemplirFormulaire()
        {
            //On remplis le formulaire avec la lise d'objets passé en paramètre.
            DataFormx.ItemsSource = _mesData;
        }

        private void btnValider_Click(object sender, RoutedEventArgs e)
        {
            if (_Action == "Insert")
            {
                //On insert dans la BDD le nouveau client
                Connexion.maBDD.Insert<Client>(_mesData[0]);
            }
            else if (_Action == "Update")
            {
                //On met à jour dans la BDD le/les objets de la liste qui ont étés modifiés
                Connexion.maBDD.Update(_mesData);
            }
            else
            { }


            //Fermeture de la fenêtre.
            this.Close();
        }
    }
}
