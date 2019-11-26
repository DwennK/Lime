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
using System.ComponentModel.DataAnnotations;
using System.Collections;
using System.Collections.ObjectModel;
using System.Globalization;

namespace Lime
{
    /// <summary>
    /// Interaction logic for FormDocument.xaml
    /// </summary>
    public partial class FormDocument
    {
        //Globals
        string action = "";
        public Document document = new Document();
        public TypeDocuments typeDocument;
        public PriseEnCharge priseEnCharge = new PriseEnCharge();
        public Client client = new Client();
        public List<Documents_Lignes> Lignes;
        public IList<Documents_Lignes> Lignesx = new ObservableCollection<Documents_Lignes>();


        //Constructeur INSERT
        public FormDocument(PriseEnCharge priseEnCharge, int ID_TypeDocuments)
        {
            InitializeComponent();
            this.action = "Insert";



            //TODO TO DO TO-DO
            Lignes = Connexion.maBDD.GetAll<Documents_Lignes>().Where(x => x.ID_Documents == document.ID && document.ID_PriseEnCharge == priseEnCharge.ID).ToList();
            var xx = Connexion.maBDD.GetAll<Documents_Lignes>().Where(x => x.ID_Documents == document.ID && document.ID_PriseEnCharge == priseEnCharge.ID);
            foreach (Documents_Lignes value in xx)
            {
                Lignesx.Add(value);
            }

            //On crée un DataContext qui contient nos variables. Comme ça, on peut accéder auy souséléments en XAML avec par exemple Text="{Binding priseEnCharge.nom}" ))  :)
            DataContext = new
            {
                priseEnCharge = priseEnCharge,
                client = Connexion.maBDD.Get<Client>(this.priseEnCharge.ID_Clients),
                Lignes,
                Lignesx,
                document,
                typeDocument = typeDocument
            };

            //Affectation des valeurs au document.
            document.ID_PriseEnCharge = priseEnCharge.ID;
            document.ID_TypeDocument = ID_TypeDocuments;

            //Permet de Reorder les lignes //
            this.radGridView.ItemsSource = Lignesx;
            RowReorderBehavior.SetIsEnabled(this.radGridView, true);

        }

        //Constructeur UPDATE
        public FormDocument(PriseEnCharge priseEnCharge, Document document)
        {
            InitializeComponent();
            this.action = "Update";
            this.document = document;



            //On récupère Toutes les lignes appartenant à ce document
            Lignes = Connexion.maBDD.GetAll<Documents_Lignes>().Where(x => x.ID_Documents == document.ID).ToList();

            Lignesx.Clear();
            foreach (Documents_Lignes value in Lignes)
            {
                Lignesx.Add(value);
            }


            //On crée un DataContext qui contient nos variables. Comme ça, on peut accéder aux sous-éléments en XAML avec par exemple Text="{Binding priseEnCharge.nom}" ))  :)
            DataContext = new
            {
                priseEnCharge = priseEnCharge,
                client = Connexion.maBDD.Get<Client>(this.priseEnCharge.ID_Clients),
                Lignes,
                Lignesx,
                this.document,
                typeDocument = typeDocument
            };



            //Permet de Reorder les lignes //
            this.radGridView.ItemsSource = Lignesx;
            RowReorderBehavior.SetIsEnabled(this.radGridView, true);

        }

        private void btnValider_Click(object sender, RoutedEventArgs e)
        {


                if(this.action=="Insert")
                {
                    //On récupère le numéro à insérer. (On prends le numéro maximum correspondant à ce type de document, et on incrémente
                    string SQL = "SELECT MAX(Numero) FROM Documents WHERE ID_TypeDocument = @ID_TypeDocument;";
                    var numeroActuel = Connexion.maBDD.ExecuteScalar<int>(SQL, new { ID_TypeDocument = document.ID_TypeDocument });
                    numeroActuel += 1;
                    document.Numero = numeroActuel;
                    Connexion.maBDD.Insert(document);
                }


                foreach (Documents_Lignes item in Lignesx)
                {
                    //Pour chaque ligne, on leur attribue l'ID de document pour les lier.
                    item.ID_Documents = document.ID;


                    //On check si la ligne existe. Si elle existe on la met à jour, autrement on l'insert.
                    var exists = Connexion.maBDD.ExecuteScalar<bool>("SELECT COUNT(1) FROM Documents_Lignes WHERE ID=@ID", new { item.ID });

                    if(exists)
                    {
                        //Insertion des la ligne dans la BDD.
                        Connexion.maBDD.Update(item);
                    }
                    else //La Ligne n'existe pas dans la BDD, il faut donc l'insérer.
                    {
                        //Insertion des la ligne dans la BDD.
                        Connexion.maBDD.Insert(item);
                    }
                }

                this.Close();
        }

        private void Insert_Click(object sender, RoutedEventArgs e)
        {
            Documents_Lignes item = new Documents_Lignes();
            this.Lignesx.Add(item);
        }

        private void Update_Click(object sender, RoutedEventArgs e)
        {
            radGridView.BeginEdit();
        }

        private void Duplicate_Click(object sender, RoutedEventArgs e)
        {
            //Récupération de la Row à Copier.
            var aCopier = ((Lime.Documents_Lignes)radGridView.SelectedItem);
           
            //Création et affectation de la nouvelle ligne.
            Documents_Lignes item;
            item = (Lime.Documents_Lignes)aCopier.Clone();
            //Ajout de la ligne
            this.Lignesx.Add(item);
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            var item = (Lime.Documents_Lignes)radGridView.SelectedItem;
            Connexion.maBDD.Delete(item);
            Lignesx.Remove(item);
        }
    }
}

