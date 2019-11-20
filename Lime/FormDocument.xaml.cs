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

namespace Lime
{
    /// <summary>
    /// Interaction logic for FormDocument.xaml
    /// </summary>
    public partial class FormDocument
    {
        //Globals
        public Document document = new Document();
        public TypeDocuments typeDocument;
        public PriseEnCharge priseEnCharge = new PriseEnCharge();
        public Client client = new Client();
        public List<Documents_Lignes> Lignes;
        public IList<Documents_Lignes> Lignesx = new ObservableCollection<Documents_Lignes>();



        public FormDocument(PriseEnCharge priseEnCharge, int ID_TypeDocuments)
        {
            InitializeComponent();



            Lignes = Connexion.maBDD.GetAll<Documents_Lignes>().ToList();
            var xx = Connexion.maBDD.GetAll<Documents_Lignes>();
            foreach (Documents_Lignes value in xx)
            {
                Lignesx.Add(value);
            }

            //On crée un DataContext qui contient nos variables. Comme ça, on peut accéder auy souséléments en XAML avec par exemple Text="{Binding priseEnCharge.nom}" ))  :)
            DataContext = new
            {
                priseEnCharge = priseEnCharge,
                client = Connexion.maBDD.Get<Client>(this.priseEnCharge.ID_Clients),
                Lignes = Connexion.maBDD.GetAll<Documents_Lignes>().ToList(),
                Lignesx,
                document,
                typeDocument = typeDocument
            };

            //Affectation des valeurs au document.
            document.ID_PriseEnCharge = priseEnCharge.ID;
            document.ID_TypeDocument = ID_TypeDocuments;

            //TEST //
            //this.radGridViewx.ItemsSource = MessageViewModel.Generate();
            //RowReorderBehavior.SetIsEnabled(this.radGridViewx, true);
            this.radGridView.ItemsSource = Lignesx;
            RowReorderBehavior.SetIsEnabled(this.radGridView, true);
            //FIN /

        }
        
        private void btnValider_Click(object sender, RoutedEventArgs e)
        {
            //On récupère le numéro à insérer. (On prends le numéro maximum correspondant à ce type de document, et on incrémente
            string SQL = "SELECT MAX(Numero) FROM Documents WHERE ID_TypeDocument = @ID_TypeDocument;";
            var numeroActuel = Connexion.maBDD.ExecuteScalar<int>(SQL, new { ID_TypeDocument = document.ID_TypeDocument });
            

            numeroActuel += 1;
            document.Numero = numeroActuel;


            //Insertion du document dans la BDD
            Connexion.maBDD.Insert(document);

            //Insertion des lignes dans la BDD.
            Connexion.maBDD.Insert(Lignesx);

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
            this.Lignesx.Remove((Lime.Documents_Lignes)radGridView.SelectedItem);
        }
    }
}

