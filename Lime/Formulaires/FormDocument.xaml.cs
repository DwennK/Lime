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
using Telerik.Windows.Documents.Fixed.Model;
using Telerik.Windows.Documents.Fixed.Model.Editing;
using Telerik.Windows.Documents.Fixed.FormatProviders.Pdf;
using System.IO;
using Block = Telerik.Windows.Documents.Fixed.Model.Editing.Block;
using TableRow = Telerik.Windows.Documents.Fixed.Model.Editing.Tables.TableRow;
using Table = Telerik.Windows.Documents.Fixed.Model.Editing.Tables.Table;
using Border = Telerik.Windows.Documents.Fixed.Model.Editing.Border;
using Telerik.Windows.Documents.Fixed.Model.ColorSpaces;
using Telerik.Windows.Documents.Fixed.Model.Editing.Tables;
using System.Threading.Tasks;

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
        public ObservableCollection<Documents_Lignes> Lignes = new ObservableCollection<Documents_Lignes>();
        public ObservableCollection<Reglement> ListeReglements = new ObservableCollection<Reglement>();
        public Adresse adresse = new Adresse();
        public List<MethodePaiement>methodePaiement = Connexion.maBDD.GetAll<MethodePaiement>().ToList();


        public double TotalRemise;
        public double TotalHT;
        public double TotalTVA;
        public double TotalTTC;
        public double TotalRegle;
        public double NetAPayer;

                                    

        //Constructeur INSERT
        public FormDocument(PriseEnCharge priseEnCharge, int ID_TypeDocuments, ObservableCollection<Documents_Lignes> documents_Lignes)
        {
            InitializeComponent();
            this.action = "Insert";
            this.priseEnCharge = priseEnCharge;
            client = Connexion.maBDD.Get<Client>(this.priseEnCharge.ID_Clients);
            adresse = Connexion.maBDD.Get<Adresse>(client.ID_Adresse);
            this.typeDocument = Connexion.maBDD.GetAll<TypeDocuments>().Where(x => x.ID == ID_TypeDocuments).FirstOrDefault();
            this.Lignes = documents_Lignes; //Sert dans le cas ou on transforme crée, par exemple, une Facture sur la base d'un devis : On va y copier toutes les lignes qui étaients présentes.


            //On crée un DataContext qui contient nos variables. Comme ça, on peut accéder auy sous-éléments en XAML avec par exemple Text = "{Binding priseEnCharge.nom}" ))  :)
            DataContext = new
            {
                this.priseEnCharge,
                client,
                Lignes,
                typeDocument,
                methodePaiement,
                document,
                TotalRemise,
                TotalHT,
                TotalTVA,
                TotalTTC,
                TotalRegle,
                NetAPayer
            };

            //Affectation des valeurs au document.
            document.ID_PriseEnCharge = priseEnCharge.ID;
            document.ID_TypeDocument = ID_TypeDocuments;

            //Permet de Reorder les lignes //
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
            adresse = Connexion.maBDD.Get<Adresse>(client.ID_Adresse);
            this.typeDocument = Connexion.maBDD.GetAll<TypeDocuments>().Where(x => x.ID == document.ID_TypeDocument).FirstOrDefault();

            //On récupère Toutes les lignes appartenant à ce document, et  on les place dans une liste
            var ListeLignes = Connexion.maBDD.GetAll<Documents_Lignes>().Where(x => x.ID_Documents == document.ID).ToList();
            //On met cette liste dans un ObservableCollection
            Lignes = new ObservableCollection<Documents_Lignes>(ListeLignes as List<Documents_Lignes>);


            //On crée un DataContext qui contient nos variables. Comme ça, on peut accéder aux sous-géléments en XAML avec par exemple Text="{Binding priseEnCharge.nom}" ))  :)
            DataContext = new
            {
                this.priseEnCharge,
                client,
                Lignes,
                typeDocument,
                methodePaiement,
                document,
                TotalRemise,
                TotalHT,
                TotalTVA,
                TotalTTC,
                TotalRegle,
                NetAPayer
                
            };


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
                methodePaiement,
                document,
                TotalRemise,
                TotalHT,
                TotalTVA,
                TotalTTC,
                TotalRegle,
                NetAPayer
                
            };

        }


        public void Populate()
        {
            #region Titre de la fenêtre
            this.Header = typeDocument.Libelle+" n° "+document.Numero;
            #endregion


            #region Populate ListBox MethodePaiement
            //On récupère la liste des Methodes de paiement dans la BDD
            var listMethodePaiements = Connexion.maBDD.GetAll<MethodePaiement>().ToList();

            //Insertion de la liste des methodes de paiement dans la Listbox correspondante.
            ListboxMethodePaiement.ItemsSource = listMethodePaiements;
            ListboxMethodePaiement.DisplayMemberPath = "Libelle"; //Valeur à afficher
            ListboxMethodePaiement.SelectedValuePath = "ID"; //Valeur à selectionner en faisant .SelectedItem

            #endregion

            #region Populate Combobox LieuActuelAppareil
            //On récupère la liste des Lieus Actuels
            var listLieuActuelAppareil = Connexion.maBDD.GetAll<LieuActuelAppareil>().ToList();

            //Insertion de la liste dans le combobox correspondant.
            ComboboxLieuActuelAppareil.ItemsSource = listLieuActuelAppareil;
            ComboboxLieuActuelAppareil.DisplayMemberPath = "Libelle"; //Valeur à afficher
            ComboboxLieuActuelAppareil.SelectedValuePath = "ID"; //Valeur à selectionner en faisant .SelectedItem

            //On a la valeur stockée dans la prise en charge, on l'affecte donc au Combobox
            ComboboxLieuActuelAppareil.SelectedIndex = priseEnCharge.ID_LieuActuelAppareil;

            #endregion


            #region Cacher le bouton de transformation du même type de document que celui existant
            switch (document.ID_TypeDocument)
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


            #region Remplissage ListeReglements dans gridView des Règlements
            ListeReglements.Clear();
            var temp = Connexion.maBDD.GetAll<Reglement>().Where(x => x.ID_PriseEnCharges == priseEnCharge.ID);
            foreach( var item in temp)
            {
                ListeReglements.Add(item);
            }
            radGridViewReglements.ItemsSource = ListeReglements;
            #endregion
        }

        public void CalculerTotaux()
        {
            if(Lignes != null)
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
                        item.PrixTTC = (item.PrixUniteTTC*item.Quantite) - (item.PrixUniteTTC * item.Quantite) * item.TauxRemise / 100;
                    }
                    else
                    {
                        item.PrixTTC = (item.PrixUniteTTC * item.Quantite);
                    }

                    //Total TVA ITEM
                    item.TotalTVA = (item.PrixTTC * item.TauxTVA / 100);
                    // FIN ITEM////////////////


                    double TotalTaxesItem = (item.PrixTTC * item.Quantite) * (double)item.TauxTVA / 100;
                    double TotalRemiseItem = (item.PrixUniteTTC * item.Quantite) * item.TauxRemise / 100;

                    //GLOBAL DOCUMENT//////////
                    //Total TTC
                    TotalTTC += item.PrixTTC * item.Quantite;

                    //TotalTVA
                    TotalTVA += TotalTaxesItem;

                    //TotalRemise
                    if (item.TauxRemise > 0)
                        TotalRemise += TotalRemiseItem;
                    else
                        TotalRemise += 0;

                    //TotalHT
                    TotalHT += item.PrixTTC - TotalTaxesItem;




                    //FIN GOBAL DOCUMENT///////

                }



                #region Calcul montant TotalPaiements et Ajout dans le RadGridView Correspondant.

                double TotalDesPaiements = 0;
                //Récupération de la liste des paiements appartenant à ce document.
                var ListeDesReglements = Connexion.maBDD.GetAll<Reglement>().Where(x => x.ID_PriseEnCharges == priseEnCharge.ID);



                //TODO TO DO TO-DO
                //GridViewReglements
                string SQL = "SELECT Montant, Date FROM Reglements WHERE ID_PriseEnCharges = @ID_PriseEnCharges;";
                var ListeNewxxxx = Connexion.maBDD.Query(SQL, new { ID_PriseEnCharges = priseEnCharge.ID });
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


                //On set le dataContext
                SetDataContext();

            }
        }

        private void ValiderDocument()
        {
            radGridView.CommitEdit();
            radGridViewReglements.CommitEdit();


            int numeroActuel = 0;
            if (this.action == "Insert")
            {
                //On récupère le numéro à insérer. (On prends le numéro maximum correspondant à ce type de document, et on incrémente
                string SQL = "SELECT MAX(Numero) FROM Documents WHERE ID_TypeDocument = @ID_TypeDocument;";
                numeroActuel = Connexion.maBDD.ExecuteScalar<int>(SQL, new { ID_TypeDocument = document.ID_TypeDocument });
                numeroActuel += 1;
                document.Numero = numeroActuel;
            }


            //On fait un UPSERT sur le document (Update or Insert)
                var exists = Connexion.maBDD.ExecuteScalar<bool>("SELECT COUNT(1) FROM Documents WHERE ID=@ID", new { ID =document.ID});
                if (exists)
                {
                    //Insertion dans la BDD.
                    Connexion.maBDD.Update(document);
                }
                else //n'existe pas dans la BDD, il faut donc l'insérer.
                {
                    //Insertion dans la BDD.
                    Connexion.maBDD.Insert(document);
                }



            // INSERTION OU UPDATE DES LIGNES ARTICLES
            foreach (Documents_Lignes item in Lignes)
            {


                //Pour chaque ligne, on leur attribue l'ID de document pour les lier.
                item.ID_Documents = document.ID;


                //On check si la ligne existe. Si elle existe on la met à jour, autrement on l'insert.
                exists = Connexion.maBDD.ExecuteScalar<bool>("SELECT COUNT(1) FROM Documents_Lignes WHERE ID=@ID", new { item.ID });

                if (exists)
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

            // INSERTION OU UPDATE DES LIGNES REGLEMENT
            foreach (Reglement item in ListeReglements)
            {
                //Pour chaque ligne, on leur attribue l'ID de document pour les lier.
                item.ID_PriseEnCharges = priseEnCharge.ID;

                //On check si la ligne existe. Si elle existe on la met à jour, autrement on l'insert.
                exists = Connexion.maBDD.ExecuteScalar<bool>("SELECT COUNT(1) FROM Reglements WHERE ID=@ID", new { item.ID });

                if (exists)
                {
                    //Insertion des la ligne dans la BDD.
                    Connexion.maBDD.Update(item);
                }
                else //La Ligne n'existe pas dans la BDD, il faut donc l'insérer.
                {
                    //Insertion des lignes dans la BDD.
                    Connexion.maBDD.Insert(item);
                }
            }

            //Update de la PriseEnCharge
            Connexion.maBDD.Update(priseEnCharge);
            //Update du Document
            Connexion.maBDD.Update(document);
        }

        private void btnValider_Click(object sender, RoutedEventArgs e)
        {
            ValiderDocument();
            this.Close();
        }

        private void Insert_Click(object sender, RoutedEventArgs e)
        {
            //Création de la nouvelle Ligne
            Documents_Lignes item = new Documents_Lignes(document.ID);

            //On récupère le nombre de d'items dans la liste, et on rajoute 1 (comme ça il sera placé en dernier)
            item.Ordre = Lignes.Count+1;

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
                Alerte.SelectionVide();
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
                Lignes.Add(item);
                CalculerTotaux();
            }
            else
            {
                Alerte.SelectionVide();
            }


        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            if(radGridView.SelectedItem != null)
            {
                var item = (Lime.Documents_Lignes)radGridView.SelectedItem;
                Lignes.Remove(item);
                Connexion.maBDD.Delete(item);
                CalculerTotaux();
            }
            else
            {
                Alerte.SelectionVide();
            }

        }

        private void MoveUp_Click(object sender, RoutedEventArgs e)
        {

            if (radGridView.SelectedItem != null)
            {
                //On récupère l'index de la ligne
                int index = this.Lignes.IndexOf((radGridView.SelectedItem as Documents_Lignes));


                if (index > 0)
                {
                    //Copie de la ligne à bouger
                    var LigneActuelle = Lignes[index];

                    //Copie de la ligne sur laquelle on va déplacer
                    var LigneNouvelle = Lignes[index - 1];

                    ////On change l'ordre de celle à déplacer
                    Lignes[index].Ordre = LigneNouvelle.Ordre;

                    ////On change l'ordre de la Ligne nouvelle, pour la mettre à celui de la LigneActuelle
                    Lignes[index - 1].Ordre = LigneActuelle.Ordre+1;

                    //Maintenant qu'on a correctement changé la valeur ordre pour ces deux Lignes, on fait le tri grâce à OrderBy , en fonction de la valeur Ordre de chaque objet
                    OrderLignes();
                }

            }
            else
            {
                Alerte.SelectionVide();
            }



        }

        private void MoveDown_Click(object sender, RoutedEventArgs e)
        {

            if (radGridView.SelectedItem != null)
            {
                //On récupère l'index de la ligne
                int index = this.Lignes.IndexOf((radGridView.SelectedItem as Documents_Lignes));


                if(index < Lignes.Count()-1)
                {
                    //Copie de la ligne à bouger
                    var LigneActuelle = Lignes[index];

                    //Copie de la ligne sur laquelle on va déplacer
                    var LigneNouvelle = Lignes[index + 1];

                    ////On change l'ordre de celle à déplacer
                    Lignes[index].Ordre = LigneNouvelle.Ordre;

                    ////On change l'ordre de la Ligne nouvelle, pour la mettre à celui de la LigneActuelle
                    Lignes[index + 1].Ordre = LigneActuelle.Ordre-1;

                    //Maintenant qu'on a correctement changé la valeur ordre pour ces deux Lignes, on fait le tri grâce à OrderBy , en fonction de la valeur Ordre de chaque objet
                    OrderLignes();
                }

            }
            else
            {
                Alerte.SelectionVide();
            }

        }

        private void OrderLignes()
        {
            //Maintenant qu'on a correctement changé la valeur ordre pour ces deux Lignes, on fait le tri grâce à OrderBy , en fonction de la valeur Ordre de chaque objet
            var maList = Lignes.OrderBy(x => x.Ordre).ToList();

            Lignes.Clear();
            foreach (var item in maList)
            {
                Lignes.Add(item);
            }
        }

        private void btnFermer_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void ListboxMethodePaiement_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //On déclare un item qui représente celui que l'utilisateur a cliqué
            MethodePaiement methodePaiement = (MethodePaiement)ListboxMethodePaiement.SelectedItem;

            if (methodePaiement != null && NetAPayer > 0)
            {
                //Affectation des variables
                Reglement reglement = new Reglement();
                reglement.ID_PriseEnCharges = priseEnCharge.ID;
                reglement.ID_MethodePaiement = methodePaiement.ID;
                reglement.Montant = NetAPayer;
                reglement.Date = DateTime.Now;

                //Insertion dans la BDD
                Connexion.maBDD.Insert<Reglement>(reglement);
                CalculerTotaux();
                Populate();


            }
            tabControl1.SelectedItem = tabReglements;
        }


        #region Transformer le document en un autre type de document. (Devis->Facture, Devis->Commande, Commande->Réparation etc)
            private void btnDevis_Click(object sender, RoutedEventArgs e)
            {
                
            }

            private void btnDevisAssurance_Click(object sender, RoutedEventArgs e)
            {
                //On Clôture le document
                document.Closed = true;
                //On valide ce document
                btnValider_Click(sender, e);



                //Copie des Lignes dans une Liste temporaire
                ObservableCollection<Documents_Lignes> LignesPourLeNouveauDocument = new ObservableCollection<Documents_Lignes>();
                foreach(var item in Lignes) //Rempli la Nouvelle liste depuis celle actuelle (appartenant à ce document)
                {
                    item.ID = 0; 
                    item.ID_Documents = 0; //Le 0 est traité plus tard dans la methode de validation du nouveau doucment. (une fois que le document a un ID, il l'affecte)
                    LignesPourLeNouveauDocument.Add(item);
                }

                //DEVIS ASSURANCE = 2
                int ID_TypeDocument = 2;
                FormDocument maFenetre = new FormDocument(priseEnCharge, ID_TypeDocument, LignesPourLeNouveauDocument);
                maFenetre.Show();
                this.Close();
            }

            private void btnCommandePieces_Click(object sender, RoutedEventArgs e)
            {
                //On Clôture le document
                document.Closed = true;
                //On valide ce document
                btnValider_Click(sender, e);


                //Copie des Lignes dans une Liste temporaire
                ObservableCollection<Documents_Lignes> LignesPourLeNouveauDocument = new ObservableCollection<Documents_Lignes>();
                foreach (var item in Lignes) //Rempli la Nouvelle liste depuis celle actuelle (appartenant à ce document)
                {
                    item.ID = 0;
                    item.ID_Documents = 0; //Le 0 est traité plus tard dans la methode de validation du nouveau doucment. (une fois que le document a un ID, il l'affecte)
                    LignesPourLeNouveauDocument.Add(item);
                }

                //COMMANDE PEICE  = 3
                int ID_TypeDocument = 3;
                FormDocument maFenetre = new FormDocument(priseEnCharge, ID_TypeDocument, LignesPourLeNouveauDocument);
                maFenetre.Show();
                this.Close();
             }

            private void btnReparation_Click(object sender, RoutedEventArgs e)
            {
                //On Clôture le document
                document.Closed = true;
                //On valide ce document
                btnValider_Click(sender, e);


            //Copie des Lignes dans une Liste temporaire
            ObservableCollection<Documents_Lignes> LignesPourLeNouveauDocument = new ObservableCollection<Documents_Lignes>();
                foreach (var item in Lignes) //Rempli la Nouvelle liste depuis celle actuelle (appartenant à ce document)
                {
                    item.ID = 0;
                    item.ID_Documents = 0; //Le 0 est traité plus tard dans la methode de validation du nouveau doucment. (une fois que le document a un ID, il l'affecte)
                    LignesPourLeNouveauDocument.Add(item);
                }

                //REPARATION  = 4
                int ID_TypeDocument = 4;
                FormDocument maFenetre = new FormDocument(priseEnCharge, ID_TypeDocument, LignesPourLeNouveauDocument);
                maFenetre.Show();
                this.Close();
            }

            private void btnFacture_Click(object sender, RoutedEventArgs e)
            {
                //On Clôture le document
                document.Closed = true;
                //On valide ce document
                btnValider_Click(sender, e);


            //Copie des Lignes dans une Liste temporaire
            ObservableCollection<Documents_Lignes> LignesPourLeNouveauDocument = new ObservableCollection<Documents_Lignes>();
                foreach (var item in Lignes) //Rempli la Nouvelle liste depuis celle actuelle (appartenant à ce document)
                {
                    item.ID = 0;
                    item.ID_Documents = 0; //Le 0 est traité plus tard dans la methode de validation du nouveau doucment. (une fois que le document a un ID, il l'affecte)
                    LignesPourLeNouveauDocument.Add(item);
                }

                //FACTURE  = 5
                int ID_TypeDocument = 5;
                FormDocument maFenetre = new FormDocument(priseEnCharge, ID_TypeDocument, LignesPourLeNouveauDocument);
                maFenetre.Show();
                this.Close();
            }

            private void btnSAV_Click(object sender, RoutedEventArgs e)
            {
                //On Clôture le document
                document.Closed = true;
                //On valide ce document
                btnValider_Click(sender, e);


            //Copie des Lignes dans une Liste temporaire
            ObservableCollection<Documents_Lignes> LignesPourLeNouveauDocument = new ObservableCollection<Documents_Lignes>();
                foreach (var item in Lignes) //Rempli la Nouvelle liste depuis celle actuelle (appartenant à ce document)
                {
                    item.ID = 0;
                    item.ID_Documents = 0; //Le 0 est traité plus tard dans la methode de validation du nouveau doucment. (une fois que le document a un ID, il l'affecte)
                    LignesPourLeNouveauDocument.Add(item);
                }

                //SAV  = 6
                int ID_TypeDocument = 3;
                FormDocument maFenetre = new FormDocument(priseEnCharge, ID_TypeDocument, LignesPourLeNouveauDocument);
                maFenetre.Show();
                this.Close();


            }
        #endregion

        private void btnReglements_Click(object sender, RoutedEventArgs e)
        {
            //Sélection du tabItem contenant les reglements.
            tabControl1.SelectedIndex = 1;

        }

        private void UpdateReglement_Click(object sender, RoutedEventArgs e)
        {
            if (radGridViewReglements.SelectedItem != null)
            {
                radGridViewReglements.BeginEdit();
            }
            else
            {
                Alerte.SelectionVide();
            }
        }


        private void DeleteReglement_Click(object sender, RoutedEventArgs e)
        {
            if (radGridViewReglements.SelectedItem != null)
            {
                var item = (Lime.Reglement)radGridViewReglements.SelectedItem;
                ListeReglements.Remove(item);
                Connexion.maBDD.Delete(item);
                CalculerTotaux();
                Populate();
            }
            else
            {
                Alerte.SelectionVide();
            }
        }


        private void radGridView_CellUnloaded(object sender, Telerik.Windows.Controls.GridView.CellEventArgs e)
        {



        }

        private void radGridView_CellEditEnded(object sender, GridViewCellEditEndedEventArgs e)
        {
            CalculerTotaux();

        }

        private void radGridView_CellValidated(object sender, GridViewCellValidatedEventArgs e)
        {

            radGridView.UpdateLayout();

            //Refresh de l'UI du GridView
            //radGridView.Items.Refresh();
        }

        private void radGridView_CellValidating(object sender, GridViewCellValidatingEventArgs e)
        {



        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            radGridView.Rebind();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            radGridView.Items.Refresh();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            radGridView.UpdateLayout();
        }

        private void radGridView_RowEditEnded(object sender, GridViewRowEditEndedEventArgs e)
        {
            radGridView.Items.Refresh();
        }


        private string MakePDF()
        {
            ValiderDocument();

            string chemin = Properties.Settings.Default.EmplacementParDefaultDocuments + "\\";
            string nomFichier = Connexion.maBDD.Get<TypeDocuments>(document.ID_TypeDocument).Prefixe + "°"+  document.Numero.ToString() + "-"  + DateTime.Now.Date.Year.ToString() + "." + DateTime.Now.Date.Month.ToString() + "." + DateTime.Now.Date.Day.ToString() + " (" + DateTime.Now.Millisecond.ToString() + ")";
            string extension = ".pdf";

            // Obtain the settings of the default printer
            System.Drawing.Printing.PrinterSettings printerSettings
                = new System.Drawing.Printing.PrinterSettings()
                {
                    PrinterName = "Microsoft Print to PDF",
                    PrintToFile = true,
                    PrintFileName = chemin + nomFichier + extension
                };

            // The standard print controller comes with no UI
            System.Drawing.Printing.PrintController standardPrintController =
                new System.Drawing.Printing.StandardPrintController();

            // Print the report using the custom print controller
            Telerik.Reporting.Processing.ReportProcessor reportProcessor
                = new Telerik.Reporting.Processing.ReportProcessor();

            //reportProcessor.PrintController = standardPrintController;

            Telerik.Reporting.UriReportSource uriReportSource =
                new Telerik.Reporting.UriReportSource();

            // Specifying an URL or a file path of the Report
            uriReportSource.Uri = "Reports/Document.trdp";

            // Adding the initial parameter values
            uriReportSource.Parameters.Add(new Telerik.Reporting.Parameter("NumeroDocument", document.Numero));
            uriReportSource.Parameters.Add(new Telerik.Reporting.Parameter("IDTypeDocument", document.ID_TypeDocument));
            uriReportSource.Parameters.Add(new Telerik.Reporting.Parameter("IDPriseEnCharge", priseEnCharge.ID));
            uriReportSource.Parameters.Add(new Telerik.Reporting.Parameter("TotalRegle", TotalRegle));
            uriReportSource.Parameters.Add(new Telerik.Reporting.Parameter("NetAPayer", NetAPayer));


            //Print to PDF
            reportProcessor.PrintReport(uriReportSource, printerSettings);

            //Retour du nom du fichier (Concaténé)
            return chemin + nomFichier + extension;
        }

        private void btnPDF_Click(object sender, RoutedEventArgs e)
        {
            //On valide le document
            btnValider_Click(sender, e);

            //Creaton du PDF et on récupère le chemin
            MakePDF();

        }


        private void radGridViewReglements_RowEditEnded(object sender, GridViewRowEditEndedEventArgs e)
        {
        }

        private void Chercher_Click(object sender, RoutedEventArgs e)
        {
            FormChercherArticle maFenetre = new FormChercherArticle();
            var result = maFenetre.ShowDialog();

            Article article = maFenetre.article;

            if(article.Libelle != null)
            {
                //On crée la ligne à partir de l'article
                Documents_Lignes ligne = new Documents_Lignes();
                ligne.ID_Documents = document.ID;
                ligne.Libelle = article.Libelle;
                ligne.Ordre = Lignes.Count + 1;
                ligne.PrixAchatUnite = article.PrixAchat;
                ligne.PrixUniteTTC = article.Prixvente;
                ligne.PrixTTC = article.Prixvente;
                ligne.Quantite = 1;
                ligne.TauxTVA = Connexion.maBDD.Get<Parametre>(1).TauxTVAParDefaut;

                //Ajout de la ligne à la liste de Lignes
                Lignes.Add(ligne);
                CalculerTotaux();
            }
        }

        private void btnApercu_Click(object sender, RoutedEventArgs e)
        {
            string chemin = MakePDF();


            //Attends que le fichier soit prêt.
            while (!IsFileReady(chemin)) {
                
            }
            System.Diagnostics.Process.Start(chemin);
                                          
        }

        private void btnImprimer_Click(object sender, RoutedEventArgs e)
        {
            document.Printed = true;
            MakePDF();
            
        }


        public static bool IsFileReady(string filename)
        {
            // If the file can be opened for exclusive access it means that the file
            // is no longer locked by another process.
            try
            {
                using (FileStream inputStream = File.Open(filename, FileMode.Open, FileAccess.Read, FileShare.None))
                    return inputStream.Length > 0;
            }
            catch (Exception)
            {
                return false;
            }
        }

        private void btnMail_Click(object sender, RoutedEventArgs e)
        {
            if(priseEnCharge.Email1 != null && priseEnCharge.Email1 != string.Empty)
            {
                document.Mailed = true;
                string chemin = MakePDF();

                //Juste pour la clarté pour le nom de paramètre, plus clair "pièceJointe" que "chemin"
                string pieceJointe = chemin;


                //Attends que le fichier soit prêt.
                while (!IsFileReady(chemin))
                {

                }
                Mail.MailDocument(priseEnCharge.Email1, pieceJointe);
            }
            else
            {
                Alerte.NoMailAddressProvided();
            }

        }
    }
}

