using System;
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
using System.ComponentModel; //Sert à changer l'affichage du nom de la propritéé dans la BDD par un texte(Last Name au lieu de lastname par exemple)
using System.ComponentModel.DataAnnotations;

namespace Lime
{
    /// <summary>
    /// Interaction logic for DataFormClient.xaml
    /// </summary>
    public partial class DataFormClient
    {
        public DataFormClient()
        {
            InitializeComponent();
        }

        private void BtnValider_Click(object sender, RoutedEventArgs e)
        {
            //On crée les deux adresses, vide au début.
            Adresse adresseFacturation = new Adresse();
            Adresse adresseLivraison = new Adresse();

            //On modifie l'adresse de Facturation, et la sauve dans la BDD.
            adresseFacturation.UpdateAdresse(new Adresse
            {
                adresse = tbxAdresseFacturation.Text,
                NPA = tbxNPAFacturation.Text,
                Ville = tbxVilleFacturation.Text
            });
            Adresse.InsertAdresse(adresseFacturation);

            //On copie le contenu de adresseFacturaiton dans adresseLivraison. (Si c'est pas le cas, le prochain IF vient régler le problème )
            adresseLivraison = adresseFacturation;

            //On vérifie si l'adresse de livraison était la même que celle de facturation.
            //Si elle n'est pas pareille, nous allons modifier l'adresse de livraison.
            if (tbxAdresseFacturation.Text != tbxAdresseLivraison.Text && tbxNPAFacturation != tbxNPALivraison && tbxVilleFacturation != tbxVilleLivraison)
            {
                //Vu que les adresses sont différentes, on va spécifiquement créer une adresse de livraison et l'insérer dans la BDD
                adresseLivraison = (new Adresse
                {
                    adresse = tbxAdresseLivraison.Text,
                    NPA = tbxNPALivraison.Text,
                    Ville = tbxVilleLivraison.Text
                });
                Adresse.InsertAdresse(adresseLivraison);
            }

            //Une fois les deux adresse créées, on va finalement insérer le client.
            Client client = (new Client
            {
                ID_AdresseFacturation = adresseFacturation.ID,
                ID_AdresseLivraison = adresseLivraison.ID,
                Nom = tbxNom.Text,
                Telephone1 = tbxTelephone1.Text,
                Telephone2 = tbxTelephone2.Text,
                Email1 = tbxEmail1.Text,
                Email2 = tbxEmail2.Text,
                Commentaire = tbxCommentaire.Text,
                RemisePermanente = (double)tbxRemisePermanente.Value,
                PersonneDeContact = tbxPersonneDeContact.Text
            }); ;
            Client.InsertClient(client);


            //Ferme la fenêtre
            this.Close();
        }
    }
}
