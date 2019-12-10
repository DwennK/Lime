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
        public List<Documents_Lignes> Lignes = new List<Documents_Lignes>();
        public string str1 = "sss";

        public double TotalRemise;
        public double TotalHT;
        public double TotalTVA;
        public double TotalTTC;
        public double TotalRegle;
        public double NetAPayer;

                                    

        //Constructeur INSERT
        public FormDocument(PriseEnCharge priseEnCharge, int ID_TypeDocuments, List<Documents_Lignes> documents_Lignes)
        {
            InitializeComponent();
            this.action = "Insert";
            this.priseEnCharge = priseEnCharge;
            client = Connexion.maBDD.Get<Client>(this.priseEnCharge.ID_Clients);
            this.typeDocument = Connexion.maBDD.GetAll<TypeDocuments>().Where(x => x.ID == ID_TypeDocuments).FirstOrDefault();
            this.Lignes = documents_Lignes; //Sert dans le cas ou on transforme crée, par exemple, une Facture sur la base d'un devis : On va y copier toutes les lignes qui étaients présentes.



            //var xx = Connexion.maBDD.GetAll<Documents_Lignes>().Where(x => x.ID_Documents == document.ID && document.ID_PriseEnCharge == priseEnCharge.ID);


            //On crée un DataContext qui contient nos variables. Comme ça, on peut accéder auy sous-géléments en XAML avec par exemple Text = "{Binding priseEnCharge.nom}" ))  :)
            DataContext = new
            {
                priseEnCharge,
                client,
                Lignes,
                typeDocument,
                document,
                TotalRemise,
                TotalHT,
                TotalTVA,
                TotalTTC,
                TotalRegle,
                NetAPayer,
                str1
            };




            //Affectation des valeurs au document.
            document.ID_PriseEnCharge = priseEnCharge.ID;
            document.ID_TypeDocument = ID_TypeDocuments;

            //Permet de Reorder les lignes //
            RowReorderBehavior.SetIsEnabled(this.radGridView, true);
            SetDataContext();
            CalculerTotaux();
            Populate();
        }


        //Constructeur UPDATE
        public FormDocument(PriseEnCharge priseEnCharge, Document document)
        {
            InitializeComponent();
            this.action = "Update";
            this.priseEnCharge = priseEnCharge;
            this.document = document;
            this.client = Connexion.maBDD.Get<Client>(this.priseEnCharge.ID_Clients);
            this.typeDocument = Connexion.maBDD.GetAll<TypeDocuments>().Where(x => x.ID == document.ID_TypeDocument).FirstOrDefault();

            //On récupère Toutes les lignes appartenant à ce document
            Lignes = Connexion.maBDD.GetAll<Documents_Lignes>().Where(x => x.ID_Documents == document.ID).ToList();


            //On crée un DataContext qui contient nos variables. Comme ça, on peut accéder auy sous-géléments en XAML avec par exemple Text="{Binding priseEnCharge.nom}" ))  :)
            DataContext = new
            {
                priseEnCharge,
                client,
                Lignes,
                typeDocument,
                document,
                TotalRemise,
                TotalHT,
                TotalTVA,
                TotalTTC,
                TotalRegle,
                NetAPayer,
                str1
            };


            //Permet de Reorder les lignes //
            RowReorderBehavior.SetIsEnabled(this.radGridView, true);
            SetDataContext();
            CalculerTotaux();
            Populate();
        }

        public void SetDataContext()
        {
            DataContext = new
            {
                priseEnCharge,
                client,
                Lignes,
                typeDocument,
                document,
                TotalRemise,
                TotalHT,
                TotalTVA,
                TotalTTC,
                TotalRegle,
                NetAPayer,
                str1
            };
        }


        public void Populate()
        {
            #region Titre de la fenêtre
            this.Header = typeDocument.Libelle+" n° "+document.ID;
            #endregion


            #region Populate ListBox MethodePaiement
            //On récupère la liste des Methodes de paiement dans la BDD
            var listMethodePaiements = Connexion.maBDD.GetAll<MethodePaiement>().ToList();

            //Insertion de la liste des methodes de paiement dans la Listbox correspondante.
            ListboxMethodePaiement.Items.Clear();

            ListboxMethodePaiement.ItemsSource = listMethodePaiements;
            ListboxMethodePaiement.DisplayMemberPath = "Libelle"; //Valeur à afficher
            ListboxMethodePaiement.SelectedValuePath = "ID"; //Valeur à selectionner en faisant .SelectedItem

            #endregion


            #region Cacher le bouton de transformation du même type de document que celui existant
            switch(document.ID_TypeDocument)
            {
                
                case 1: //DEVIS
                    btnDevis.IsEnabled = false;
                    break;
                case 2: //DEVIS ASSURANCE
                    btnDevis.IsEnabled = false;
                    btnDevisAssurance.IsEnabled = false;
                    break;
                case 3: //COMMANDE PIECE
                    btnDevis.IsEnabled = false;
                    btnDevisAssurance.IsEnabled = false;
                    btnCommandePieces.IsEnabled = false;
                    break;
                case 4: //REPARATION
                    btnDevis.IsEnabled = false;
                    btnDevisAssurance.IsEnabled = false;
                    btnCommandePieces.IsEnabled = false;
                    btnReparation.IsEnabled = false;
                    break;
                case 5: //FACTURE
                    btnDevis.IsEnabled = false;
                    btnDevisAssurance.IsEnabled = false;
                    btnCommandePieces.IsEnabled = false;
                    btnReparation.IsEnabled = false;
                    btnFacture.IsEnabled = false;
                    break;
                case 6: //SAV
                    btnDevis.IsEnabled = false;
                    btnDevisAssurance.IsEnabled = false;
                    btnCommandePieces.IsEnabled = false;
                    btnReparation.IsEnabled = false;
                    btnFacture.IsEnabled = false;
                    btnSAV.IsEnabled = false;
                    break;

            }

            #endregion


            #region Remplissage ListeReglements

            //var ListeRèglements = 
            #endregion

        }

        public void CalculerTotaux()
        {
            //Cet event sera appelé après chaque modification de valeur dans le GridView.
            //Cet event va nous servir à mettre à jour les totaux etc.


            //Reset des valeurs à zero
            TotalRemise = 0;
            TotalHT = 0;
            TotalTVA = 0;
            TotalTTC = 0;
            TotalRegle = 0;
            NetAPayer = 0;




            foreach (var item in Lignes) //Ces variables sont dans le DataContext
            {
                //ITEM/////////////////////

                //Total TTC ITEM
                if (item.TauxRemise > 0)
                {
                    item.PrixTTC = (item.PrixUniteTTC * item.Quantite) *item.TauxRemise/100;
                }
                else
                {
                    item.PrixTTC = (item.PrixUniteTTC * item.Quantite);
                }

                //Total TVA ITEM
                item.TotalTVA = (item.PrixTTC * item.TauxTVA/100);
                // FIN ITEM////////////////


                double TotalTaxesItem = (item.PrixTTC * item.Quantite) * (double)item.TauxTVA/100;
                double TotalRemiseItem = (item.PrixUniteTTC * item.Quantite) * item.TauxRemise / 100;

                //GLOBAL DOCUMENT//////////
                    //Total TTC
                    TotalTTC += item.PrixTTC * item.Quantite;

                    //TotalTVA
                    TotalTVA += TotalTaxesItem;

                    //TotalRemise
                    if(item.TauxRemise > 0)
                    TotalRemise += (item.PrixTTC * item.TauxRemise) / 100;
                    else
                    TotalRemise += 0;

                    //TotalHT
                    TotalHT += item.PrixTTC - TotalTaxesItem;

                    


                //FIN GOBAL DOCUMENT///////

            }



            #region Calcul montant TotalPaiements et Ajout dans le RadGridView Correspondant.

            double TotalDesPaiements = 0;
            //Récupération de la liste des paiements appartenant à ce document.
            var ListeDesReglements = Connexion.maBDD.GetAll<Reglement>().Where(x => x.ID_Documents == document.ID);



            //TODO TO DO TO-DO
            //GridViewReglements
            radGridViewReglements.Items.Clear();
            string SQL = "SELECT Montant, Date FROM Reglements WHERE ID_Documents = @ID_DOCUMENT;";
            var ListeNewxxxx = Connexion.maBDD.Query(SQL, new { ID_DOCUMENT = document.ID });
            radGridViewReglements.ItemsSource = ListeNewxxxx;
            //radGridViewReglements.ItemsSource = ListeDesReglements;


            foreach (var item in ListeDesReglements)
            {
                TotalDesPaiements += item.Montant;
            }
            //TotalRéglé
            TotalRegle = TotalDesPaiements;

            #endregion

            #region NetAPayer

            //NetAPayer
            NetAPayer = TotalTTC - TotalRegle;

            #endregion

            SetDataContext();
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


                foreach (Documents_Lignes item in Lignes)
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
            Documents_Lignes item = new Documents_Lignes(document.ID);
            this.Lignes.Add(item);
            radGridView.Rebind();
            CalculerTotaux();
        }

        private void Update_Click(object sender, RoutedEventArgs e)
        {
            if (radGridView.SelectedItem != null)
            {
                radGridView.BeginEdit();
                radGridView.Rebind();
                CalculerTotaux();
            }
            else
            {
                RadWindow.Alert(new DialogParameters
                {
                    Header = "Attention",
                    Content = "Veuillez chosir un élément dans la liste.",
                    Theme = new CrystalTheme()
                });
            }


        }

        private void Duplicate_Click(object sender, RoutedEventArgs e)
        {
            if (radGridView.SelectedItem != null)
            {
                //Récupération de la Row à Copier.
                var aCopier = ((Lime.Documents_Lignes)radGridView.SelectedItem);

                //Création et affectation de la nouvelle ligne.
                Documents_Lignes item;
                item = (Lime.Documents_Lignes)aCopier.Clone();
                //Ajout de la ligne
                this.Lignes.Add(item);
                radGridView.Rebind();
                CalculerTotaux();
            }
            else
            {
                RadWindow.Alert(new DialogParameters
                {
                    Header = "Attention",
                    Content = "Veuillez chosir un élément dans la liste.",
                    Theme = new CrystalTheme()
                });
            }


        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            
            if(radGridView.SelectedItem != null)
            {
                var item = (Lime.Documents_Lignes)radGridView.SelectedItem;
                Lignes.Remove(item);
                Connexion.maBDD.Delete(item);
                radGridView.Rebind();
                CalculerTotaux();
            }
            else
            {
                RadWindow.Alert(new DialogParameters
                {
                    Header = "Attention",
                    Content = "Veuillez chosir un élément dans la liste.",
                    Theme = new CrystalTheme()
                });
            }

        }

        private void radGridView_CellEditEnded(object sender, GridViewCellEditEndedEventArgs e)
        {
            CalculerTotaux();

        }

        private void radGridView_RowEditEnded(object sender, GridViewRowEditEndedEventArgs e)
        {
            CalculerTotaux();
        }

        private void btnFermer_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnRegler_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ListboxMethodePaiement_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //On déclare un item qui représente celui que l'utilisateur a cliqué
            MethodePaiement methodePaiement = (MethodePaiement)ListboxMethodePaiement.SelectedItem;

            if (methodePaiement != null && NetAPayer > 0)
            {
                //Affectation des variables
                Reglement reglement = new Reglement();
                reglement.ID_Documents = document.ID;
                reglement.ID_MethodePaiement = methodePaiement.ID;
                reglement.Montant = NetAPayer;
                reglement.Date = DateTime.Now;

                //Insertion dans la BDD
                Connexion.maBDD.Insert<Reglement>(reglement);
            }
        }


        #region Transformer le document en un autre type de document. (Devis->Facture, Devis->Commande, Commande->Réparation etc)
            private void btnDevis_Click(object sender, RoutedEventArgs e)
            {
                
            }

            private void btnDevisAssurance_Click(object sender, RoutedEventArgs e)
            {
                //DEVIS = 2
                int ID_TypeDocument = 2;
                FormDocument maFenetre = new FormDocument(priseEnCharge, ID_TypeDocument, Lignes);
                maFenetre.Show();

            }

            private void btnCommandePieces_Click(object sender, RoutedEventArgs e)
            {

            }

            private void btnReparation_Click(object sender, RoutedEventArgs e)
            {

            }

            private void btnFacture_Click(object sender, RoutedEventArgs e)
            {

            }

            private void btnSAV_Click(object sender, RoutedEventArgs e)
            {

            }
        #endregion

        private void btnReglements_Click(object sender, RoutedEventArgs e)
        {
            //Sélection du tabItem contenant les reglements.
            tabControl1.SelectedIndex = 1;

        }

        private void InsertReglement_Click(object sender, RoutedEventArgs e)
        {

        }

        private void UpdateReglement_Click(object sender, RoutedEventArgs e)
        {

        }

        private void DuplicateReglement_Click(object sender, RoutedEventArgs e)
        {

        }

        private void DeleteReglement_Click(object sender, RoutedEventArgs e)
        {

        }

        private void DescendreReglement_Click(object sender, RoutedEventArgs e)
        {

        }

        private void MonterReglement_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}

