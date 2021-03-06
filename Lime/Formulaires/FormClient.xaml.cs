﻿using System;
using System.Collections.Generic;
using System.Configuration;
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
using System.Net;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Lime
{
    /// <summary>
    /// Interaction logic for FormClient.xaml
    /// </summary>
    public partial class FormClient
    {
        public Client client = new Client();
        string Action;

        //Constructeur pour Insert
        public FormClient(string action, string NomDuClient)
        {
            InitializeComponent();
            tbxNom.Focus();
            this.DataContext = this.client;
            Action = "Insert";
            client.Nom = NomDuClient; //Lors de l'appel via FormPriseEnCharge, si la rehcerche n'a rien donnée, le client clique un bouton pour cérer un client avec le nom déjà rempli.


        }

        //Constructeur pour Update
        public FormClient(Client client)
        {
            InitializeComponent();
            tbxNom.Focus();
            this.client = client;
            this.DataContext = this.client;
            Action = "Update";


            Adresse adresseFacturation = Connexion.maBDD.Get<Adresse>(client.ID_Adresse);
            if (adresseFacturation != null)
            {
                if (adresseFacturation.adresse != null) { tbxAdresse.Text = adresseFacturation.adresse; }

                if (adresseFacturation.NPA != null) { tbxNPA.Text = adresseFacturation.NPA; }
                if (adresseFacturation.Ville != null) { tbxVille.Text = adresseFacturation.Ville; }
            }

            this.tbxVille.IsDropDownOpen = false;

        }


        private void InsertClient()
        {
            if (DonnéesValides())
            {
                //On crée les deux adresses, vide au début.
                Adresse adresseFacturation = new Adresse();
                int? idAdresseFacturation = null;


                //Si le client a une adresse
                if (tbxAdresse.Text != string.Empty)
                {
                    //On modifie l'adresse de Facturation, et la sauve dans la BDD.
                    adresseFacturation.adresse = tbxAdresse.Text;
                    adresseFacturation.NPA = tbxNPA.Text;
                    adresseFacturation.Ville = tbxVille.Text;
                    //On l'insére et on réccupère son ID une fois inséré
                    idAdresseFacturation = (int)Connexion.maBDD.Insert<Adresse>(adresseFacturation);


                }

                //Une fois les deux adresse créées, on va finalement créer et insérer le client dans la BDD.
                client.ID_Adresse = idAdresseFacturation;
                Connexion.maBDD.Insert<Client>(client);

                //Ferme la Fenêtre
                this.Close();
            }

        }


        private void UpdateClient()
        {
            if (DonnéesValides())
            {
                Adresse AdresseFacturationActuelle = Connexion.maBDD.Get<Adresse>(client.ID_Adresse);


                //On regarde s'il avait une adresse de facturation, s'il n'en avait pas, on la crée
                if (AdresseFacturationActuelle == null || client.ID_Adresse == null)
                {
                    AdresseFacturationActuelle = new Adresse
                    {
                        adresse = tbxAdresse.Text,
                        NPA = tbxNPA.Text,
                        Ville = tbxVille.Text,
                    };

                    //On récupère l'ID de l'adresse qu'on insert, et on l'affecte au client.
                    int ID_Adresse = (int)Connexion.maBDD.Insert<Adresse>(AdresseFacturationActuelle);
                    client.ID_Adresse = ID_Adresse;
                }

                //On regarde si l'adresse a été changée, et si oui, on la modifie
                if (tbxAdresse.Text != AdresseFacturationActuelle.adresse || tbxNPA.Text != AdresseFacturationActuelle.NPA || tbxVille.Text != AdresseFacturationActuelle.Ville)
                {
                    //Du coup, on update l'adresse

                    AdresseFacturationActuelle.adresse = tbxAdresse.Text;
                    AdresseFacturationActuelle.NPA = tbxNPA.Text;
                    AdresseFacturationActuelle.Ville = tbxVille.Text;
                    Connexion.maBDD.Update<Adresse>(AdresseFacturationActuelle);
                }


                //On update le client
                Connexion.maBDD.Update<Client>(client);

                //Ferme la fenêtre
                this.Close();

            }
        }

        private void btnValider_Click(object sender, RoutedEventArgs e)
        {
            //Ces actions sont définies par le constructeur appelé
            if (Action == "Insert")
            {
                InsertClient();
            }
            else if (Action == "Update")
            {
                UpdateClient();
            }
        }

        private bool DonnéesValides()
        {
            string messageErreur = string.Empty;
            bool isValidData = true;

            if (client.Nom == "")
            {
                messageErreur += "Veuillez rentrer le nom du client.\n";
            }

            //Si Email1 est vide mais que Email2 ne l'est pas 
            if(String.IsNullOrEmpty(client.Email1) && !String.IsNullOrEmpty(client.Email2))
            {
                Alerte.AlerteCustom("Email 1 est vide, mais Email 2 contient une valeur. \n"
                                    +"Email 2 a donc remplacé Email 1.");

                client.Email1 = client.Email2;
                client.Email2 = null;
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


        public List<string> GetCityName(string NPA)
        {
            string URL = "http://api.geonames.org/postalCodeSearchJSON?postalcode=" + NPA + "&country=ch&maxRows=10&username=dwenn";

            //Création et envoi de la requête sur l'API
            WebRequest request = HttpWebRequest.Create(URL);
            WebResponse response = request.GetResponse();
            StreamReader reader = new StreamReader(response.GetResponseStream());

            //Conversion de la réponse en JSON
            string maRep_JSON = reader.ReadToEnd();

            //Désérialization de l'object en Dynamic
            dynamic parsedObject = JsonConvert.DeserializeObject(maRep_JSON);

            //On crée la liste dans laquelle on va mettre tout les resultats
            List<string> NomVilles = new List<string>();

            //On obucle dans les résultats pour les ajouter dans la Liste
            var iNombreDeResultats = parsedObject.postalCodes.Count;
            for (int iCpt = 0; iCpt < iNombreDeResultats; iCpt++)
            {
                string xtemp = parsedObject.postalCodes[iCpt]["placeName"].Value;
                NomVilles.Add(xtemp);
            }

            //On retourne la Liste contenant tous les noms de localités trouvés. (Par exemple pour Zurich, il y en a 7)
            return NomVilles;
        }

        //Quand on presse Enter, cela appelle cette méthode, qui va ensuite presser le bouton de validation du formulaire.
        private void OnKeyDownHandler(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                //On doit focus autre chose que le nom, comme ça les Bindings modifient correctement le client (Quand on leave le focus c'est là que l'objet se modifie)
                btnValider.Focus();
                btnValider_Click(sender, e);
            }
        }

        private void tbxNPA_TextChanged(object sender, Telerik.Windows.RadRoutedEventArgs e)
        {
            //On vide le contenu des propositions de Combobox, au cas ou il y en avait deja.
            tbxVille.ItemsSource = null;

            string NPA = tbxNPA.Value.ToString();
            List<string> NomVilles = new List<string>();

            if (NPA.Length == 4)
            {
                NomVilles = GetCityName(NPA);

                //Sî'il y a au moins 1 ville, on ajoute la liste des villes dans le combobox
                if (NomVilles.Count > 0)
                {
                    tbxVille.ItemsSource = NomVilles;
                }

                //Si y'a que une Ville qui a ce NPA, on sélectionne direct la bonne.
                if (NomVilles.Count == 1)
                {
                    tbxVille.SelectedIndex = 0;
                }
                else if (NomVilles.Count > 1) //Si y'a plus que 1 ville, on ouvre le Dropdown pour les afficher.
                {

                    tbxVille.IsDropDownOpen = true;
                }

            }


        }
    }
}
