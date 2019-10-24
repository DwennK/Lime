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
            adresseFacturation.adresse = tbxAdresseFacturation.Text;
            adresseFacturation.NPA = tbxNPAFacturation.Text;
            adresseFacturation.Ville = tbxVilleFacturation.Text;
            //On l'insére et on réccupère son ID une fois inséré
            int idAdresseFacturation =(int)Connexion.maBDD.Insert<Adresse>(adresseFacturation);
            adresseFacturation.ID = idAdresseFacturation;

            //On copie le contenu de adresseFacturaiton dans adresseLivraison. (Si le client a 2 adresses, le prochain IF vient régler le problème )
            adresseLivraison.adresse = adresseFacturation.adresse;
            adresseLivraison.NPA = adresseFacturation.NPA;
            adresseLivraison.Ville = adresseFacturation.Ville;

            //On vérifie si l'adresse de livraison était la même que celle de facturation.
            //Si elle n'est pas pareille, nous allons modifier l'adresse de livraison.
            if (tbxAdresseFacturation.Text != tbxAdresseLivraison.Text && tbxNPAFacturation != tbxNPALivraison && tbxVilleFacturation != tbxVilleLivraison)
            {
                //Vu que les adresses sont différentes, on va spécifiquement créer une adresse de livraison et l'insérer dans la BDD
                adresseLivraison.adresse = tbxAdresseLivraison.Text;
                adresseLivraison.NPA = tbxNPALivraison.Text;
                adresseLivraison.Ville = tbxVilleLivraison.Text;

                //On l'insére et on réccupère son ID une fois inséré
                int idAdresseLivraison =  (int)Connexion.maBDD.Insert<Adresse>(adresseLivraison);
                adresseLivraison.ID = idAdresseLivraison;
            }

            //Une fois les deux adresse créées, on va finalement créer insérer le client dans la BDD.
            Client client = new Client
            {
                ID_AdresseFacturation = adresseFacturation.ID,
                ID_AdresseLivraison = adresseLivraison.ID,
                Nom = tbxNom.Text,
                Telephone1 = tbxTelephone1.Text,
                Telephone2 = tbxTelephone2.Text,
                Email1 = tbxEmail1.Text,
                Email2 = tbxEmail2.Text,
                Commentaire = tbxCommentaire.Text,
                RemisePermanente = (int)tbxRemisePermanente.Value,
                PersonneDeContact = tbxPersonneDeContact.Text
            };
            Connexion.maBDD.Insert<Client>(client);


            //Ferme la fenêtre
            this.Close();
        }
    }
}
