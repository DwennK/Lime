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
using System.Collections.ObjectModel;

namespace Lime
{
    /// <summary>
    /// Interaction logic for FormPriseEnCharge.xaml
    /// </summary>
    public partial class FormPriseEnCharge
    {

        public string action = "";

        public Client client = new Client();
        public List<Client> listeClients = new List<Client>();

        public PriseEnCharge priseEnCharge = new PriseEnCharge();

        //INSERT
        public FormPriseEnCharge()
        {
            InitializeComponent();
            this.DataContext = this.priseEnCharge;
            this.action = "Insert";

            //Insertion automatique de la Date dans le DatePic1kerDebut
            priseEnCharge.DateDebut = DateTime.Now;
            this.DatePickerDebut.IsEnabled = false;

            //Vu que la date de fin sera sûrement la même que aujourd'hui, on la mets automatiquement aussi dans le DatePickerEcheance
            priseEnCharge.DateEcheance = DateTime.Now;


            Populate();
        }

        //UPDATE
        public FormPriseEnCharge(PriseEnCharge priseEnCharge)
        {

            InitializeComponent();
            this.action = "Update";


            //Vu que la prise en Charge existe déjà, le client existe déjà lui aussi.
            this.priseEnCharge = priseEnCharge;
            this.DataContext = this.priseEnCharge;

            //On affecte le client (vide pour l'instant) avec les infos déjà présentes dans la PriseEnCharge
            this.client.ID = (int)priseEnCharge.ID_Clients;
            this.client.Nom = priseEnCharge.Nom;
            this.client.ID_Adresse = priseEnCharge.ID_Adresses;
            this.client.PersonneDeContact = priseEnCharge.PersonneDeContact;
            this.client.RemisePermanente = priseEnCharge.RemisePermanente;
            this.client.Telephone1 = priseEnCharge.Telephone1;
            this.client.Telephone2 = priseEnCharge.Telephone2;
            this.client.PersonneDeContact = priseEnCharge.PersonneDeContact;

            //On met le client qu'on vient d'affecter dans le GridView.
            listeClients.Clear();
            listeClients.Add(client);
            RadGridView1.ItemsSource = listeClients;
            RadGridView1.SelectedItem = client;

            this.tbxNom.Visibility = Visibility.Hidden;
            this.btnInsertClient.Visibility = Visibility.Hidden;




            ////De cette manière, le Nom du client, qui se trouve à la colonne 0 dans le GridView, ne sera pas modifiable.
            //RadGridView1.Columns[0].IsReadOnly = true;

            this.DatePickerDebut.IsEnabled = false;

            Populate();
        }

        private void Populate()
        {

            #region Combobox Liste des Magasins Source
                //On vide, puis insère la liste des magasins dans le combobox approprié.
                ComboBoxMagasinSource.Items.Clear();
                ComboBoxMagasinSource.ItemsSource = Connexion.maBDD.GetAll<Magasin>();
                //Ce qu'on affiche textuellemtn dans le combobox.
                ComboBoxMagasinSource.DisplayMemberPath = "Libelle";
                //Ce qu'on veut comme valeur réelle qui sera sauvée (Donc l'ID du Magasin dans la BDD)
                ComboBoxMagasinSource.SelectedValuePath = "ID";

                //Sélectionne la valeur sauvée dans les paramètres
                priseEnCharge.ID_MagasinSource = Properties.Settings.Default.ID_Magasin;
            #endregion

            #region Combobox Liste des Magasins Destination
            //On vide, puis insère la liste des magasins dans le combobox approprié.
            ComboBoxMagasinDestination.Items.Clear();
                ComboBoxMagasinDestination.ItemsSource = Connexion.maBDD.GetAll<Magasin>();
                //Ce qu'on affiche textuellemtn dans le combobox.
                ComboBoxMagasinDestination.DisplayMemberPath = "Libelle";
                //Ce qu'on veut comme valeur réelle qui sera sauvée (Donc l'ID du Magasin dans la BDD)
                ComboBoxMagasinDestination.SelectedValuePath = "ID";

                //Sélectionne la valeur sauvée dans les paramètres
                priseEnCharge.ID_MagasinDestination = Properties.Settings.Default.ID_Magasin;
            #endregion


            #region Combobox Lieu actuel de l'appareil
            //On vide, puis insère la liste des magasins dans le combobox approprié.
            ComboBoxLieuActuelAppareil.Items.Clear();
                ComboBoxLieuActuelAppareil.ItemsSource = Connexion.maBDD.GetAll<LieuActuelAppareil>();
                //Ce qu'on affiche textuellemtn dans le combobox.
                ComboBoxLieuActuelAppareil.DisplayMemberPath = "Libelle";
                //Ce qu'on veut comme valeur réelle qui sera sauvée (Donc l'ID du Magasin dans la BDD)
                ComboBoxLieuActuelAppareil.SelectedValuePath = "ID";
            #endregion


        }

        private void btnValider_Click(object sender, RoutedEventArgs e)
        {
            //Si l'utilisateur n'as pas sélectionné de client dans la liste, on le sélectionnne.
            if(client==null)
            {
                this.client = listeClients.First();
            }

            //Ces actions sont définies par le constructeur appelé
            if (DonnéesValides())
            {
                AffecterPriseEnCharge();

                if (action == "Insert")
                {

                    //On insère la prise en charge dans la BDD, et on récupère l'ID.
                    var id = Connexion.maBDD.Insert(priseEnCharge);
                    this.priseEnCharge.ID = (int)id;
                }
                else if (action == "Update")
                {
                    //Si des données ont été modifiées (par exemple en changeant le numéro de téléphone), on vient modifier ça dans la priseEnCahrge
                    Connexion.maBDD.Update<PriseEnCharge>(priseEnCharge);
                }

                //Fermture de la fenêtre.
                this.Close();
            }

        }

        private bool DonnéesValides()
        {
            string messageErreur = string.Empty;
            bool isValidData;

            if (client.ID == 0)
            {
                messageErreur += "Veuillez sélectionner un client existant dans la liste.\n";
            }
            if(priseEnCharge.ID_LieuActuelAppareil == 0)
            {
                messageErreur += "Veuillez sélectionner le lieu actuel de l'appareil\n";
            }


            //S'il y a des erreurs, on les affiche
            if (messageErreur != "")
            {
                RadWindow.Alert(new DialogParameters
                {
                    Header = "Erreur",
                    Content = messageErreur,
                    //Closed = maMethode(),  // Sert à appeler une methode quand on le ferme
                    Theme = new CrystalTheme()
                });
            }

            //On teste, et renvoie pour dire si les données sont valides
            if (messageErreur == string.Empty)
            {
                isValidData = true;
            }
            else
            {
                isValidData = false;
            }

            return isValidData;
        }

        private void btnInsertClient_Click(object sender, RoutedEventArgs e)
        {
            FormClient maFenetre = new FormClient("Insert", tbxNom.Text);
            maFenetre.ShowDialog();

            client = maFenetre.client;
            priseEnCharge.Nom = client.Nom;
            priseEnCharge.ID_Adresses = client.ID_Adresse;

        }


        private void tbxNom_TextChanged(object sender, TextChangedEventArgs e)
        {
            //Si le client Existe
            if (client != null)
            {
                if (this.action == "Insert")
                {
                    var NomClient = tbxNom.Text;
                    var sql = "SELECT * FROM Clients WHERE Nom LIKE @NomClient ";

                    listeClients.Clear();
                    listeClients = Connexion.maBDD.Query<Client>(sql, new { NomClient = "%" + NomClient + "%" }).ToList();
                    //On rempli le gridview de la liste des clients qui ont ce nom.
                    RadGridView1.ItemsSource = listeClients;
                }
            }
        }


        //Après un click sur un Client dans le GridView, on l'affecte.
        private void RadGridView1_SelectionChanged(object sender, SelectionChangeEventArgs e)
        {
            this.client = (Client)RadGridView1.SelectedItem;

            AffecterPriseEnCharge();
        }

        private void btnDevis_Click(object sender, RoutedEventArgs e)
        {

        }


        private void AffecterPriseEnCharge()
        {
            priseEnCharge.Nom = client.Nom;
            priseEnCharge.ID_Clients = client.ID;
            priseEnCharge.ID_Adresses = client.ID_Adresse;
            priseEnCharge.Telephone1 = client.Telephone1;
            priseEnCharge.Telephone2 = client.Telephone2;
            priseEnCharge.Email1 = client.Email1;
            priseEnCharge.Email2 = client.Email2;
            priseEnCharge.PersonneDeContact = client.PersonneDeContact;
            priseEnCharge.RemisePermanente = client.RemisePermanente;
            priseEnCharge.PersonneDeContact = client.PersonneDeContact;
        }

    }
}
