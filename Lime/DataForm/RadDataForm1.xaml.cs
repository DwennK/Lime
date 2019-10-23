﻿using System;
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

        IEnumerable<Client> _mesData;
        public RadDataFormClient(IEnumerable<Client> mesData)
        {
            InitializeComponent();

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
            //On met à jour dans la BDD les objets de la liste qui ont étés modifiés
            Connexion.maBDD.Update(_mesData);
        }
    }
}
