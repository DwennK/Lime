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
            adresse = Connexion.maBDD.Get<Adresse>(client.ID_Adresse);
            this.typeDocument = Connexion.maBDD.GetAll<TypeDocuments>().Where(x => x.ID == document.ID_TypeDocument).FirstOrDefault();

            //On récupère Toutes les lignes appartenant à ce document, et  on les place dans une liste
            var ListeLignes = Connexion.maBDD.GetAll<Documents_Lignes>().Where(x => x.ID_Documents == document.ID).ToList();
            //On met cette liste dans un ObservableCollection
            Lignes = new ObservableCollection<Documents_Lignes>(ListeLignes as List<Documents_Lignes>);


            //On crée un DataContext qui contient nos variables. Comme ça, on peut accéder aux sous-géléments en XAML avec par exemple Text="{Binding priseEnCharge.nom}" ))  :)
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
            this.Header = typeDocument.Libelle+" n° "+document.ID;
            #endregion


            #region Populate ListBox MethodePaiement
            //On récupère la liste des Methodes de paiement dans la BDD
            var listMethodePaiements = Connexion.maBDD.GetAll<MethodePaiement>().ToList();

            //Insertion de la liste des methodes de paiement dans la Listbox correspondante.
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



        private void btnValider_Click(object sender, RoutedEventArgs e)
        {
            int numeroActuel = 0;
            if(this.action=="Insert")
            {
                //On récupère le numéro à insérer. (On prends le numéro maximum correspondant à ce type de document, et on incrémente
                string SQL = "SELECT MAX(Numero) FROM Documents WHERE ID_TypeDocument = @ID_TypeDocument;";
                numeroActuel = Connexion.maBDD.ExecuteScalar<int>(SQL, new { ID_TypeDocument = document.ID_TypeDocument });
                numeroActuel += 1;
                document.Numero = numeroActuel;
                Connexion.maBDD.Insert(document);
            }


            // INSERTION OU UPDATE DES LIGNES ARTICLES
            foreach (Documents_Lignes item in Lignes)
            {
             

                //Pour chaque ligne, on leur attribue l'ID de document pour les lier.
                item.ID_Documents = document.ID;


                //On check si la ligne existe. Si elle existe on la met à jour, autrement on l'insert.
                var exists = Connexion.maBDD.ExecuteScalar<bool>("SELECT COUNT(1) FROM Documents_Lignes WHERE ID=@ID", new { item.ID });

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
            foreach(Reglement item in ListeReglements)
            {
                //Pour chaque ligne, on leur attribue l'ID de document pour les lier.
                item.ID_PriseEnCharges = priseEnCharge.ID;

                //On check si la ligne existe. Si elle existe on la met à jour, autrement on l'insert.
                var exists = Connexion.maBDD.ExecuteScalar<bool>("SELECT COUNT(1) FROM Reglements WHERE ID=@ID", new { item.ID });

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

                //On le sauve dans la BDD
                Connexion.maBDD.Insert(item);

                //Ajout de la ligne
                Lignes.Add(item);
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
                RadWindow.Alert(new DialogParameters
                {
                    Header = "Attention",
                    Content = "Veuillez chosir un élément dans la liste.",
                    Theme = new CrystalTheme()
                });
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
                RadWindow.Alert(new DialogParameters
                {
                    Header = "Attention",
                    Content = "Veuillez chosir un élément dans la liste.",
                    Theme = new CrystalTheme()
                });
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

        private void InsertReglement_Click(object sender, RoutedEventArgs e)
        {

        }

        private void UpdateReglement_Click(object sender, RoutedEventArgs e)
        {
            if (radGridViewReglements.SelectedItem != null)
            {
                radGridViewReglements.BeginEdit();
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
                RadWindow.Alert(new DialogParameters
                {
                    Header = "Attention",
                    Content = "Veuillez chosir un élément dans la liste.",
                    Theme = new CrystalTheme()
                });
            }
        }

        private void DescendreReglement_Click(object sender, RoutedEventArgs e)
        {

        }

        private void MonterReglement_Click(object sender, RoutedEventArgs e)
        {

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

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            Documents_Lignes item = new Documents_Lignes(5);
            Lignes.Add(item);
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            GridViewComboBoxColumn colonne = new GridViewComboBoxColumn();
            colonne.Name = "MethodePaiementxxx";
            colonne.UniqueName = "MethodePaiementxxx";
            colonne.Header = "MethodePaiementxxx";
            colonne.ItemsSource = this.methodePaiement;
            colonne.SelectedValueMemberPath = "ID";
            colonne.DisplayMemberPath = "Libelle";
            colonne.Width = 200;
            colonne.IsComboBoxEditable = true;
            colonne.IsReadOnly = false;
            this.radGridViewReglements.Columns.Add(colonne);
        }

        private void test_Click(object sender, RoutedEventArgs e)
        {

            Populate();
        }

        private void radGridViewReglements_LostFocus(object sender, RoutedEventArgs e)
        {
            
        }


        private void MakePDF()
        {
            // Obtain the settings of the default printer
            System.Drawing.Printing.PrinterSettings printerSettings
                = new System.Drawing.Printing.PrinterSettings();

            // The standard print controller comes with no UI
            System.Drawing.Printing.PrintController standardPrintController =
                new System.Drawing.Printing.StandardPrintController();

            // Print the report using the custom print controller
            Telerik.Reporting.Processing.ReportProcessor reportProcessor
                = new Telerik.Reporting.Processing.ReportProcessor();

            reportProcessor.PrintController = standardPrintController;

            Telerik.Reporting.UriReportSource uriReportSource =
                new Telerik.Reporting.UriReportSource();

            // Specifying an URL or a file path of the Report
            uriReportSource.Uri = @"D:\Users\Kafe\Desktop\temp\Invoice.trdp";

            // Adding the initial parameter values
            uriReportSource.Parameters.Add(new Telerik.Reporting.Parameter("NumeroDocument", 1));
            uriReportSource.Parameters.Add(new Telerik.Reporting.Parameter("IDTypeDocument", 1));


            //Print to PDF
            reportProcessor.PrintReport(uriReportSource, printerSettings);

        }

        private void btnPDF_Click(object sender, RoutedEventArgs e)
        {
            //Céraiton du PDF et on récupère le chemin
            MakePDF();

            //////Création du document
            ////RadFixedDocument document = new RadFixedDocument();
            ////RadFixedDocumentEditor editor = new RadFixedDocumentEditor(document);


            //////Ajout du contenu du document
            ////editor.ParagraphProperties.HorizontalAlignment = Telerik.Windows.Documents.Fixed.Model.Editing.Flow.HorizontalAlignment.Right;
            ////editor.InsertParagraph();
            ////editor.CharacterProperties.FontSize = 36;
            ////editor.InsertRun(typeDocument.Libelle);
            ////editor.InsertLineBreak();


            //////Table Infos Document
            //////Table contenant les lignes Articles du document
            ////editor.ParagraphProperties.HorizontalAlignment = Telerik.Windows.Documents.Fixed.Model.Editing.Flow.HorizontalAlignment.Right;
            ////editor.InsertParagraph();
            ////Table tableInfosDocument = new Table();
            ////Border cellborderInfosDocument = new Border(1, new RgbColor(0, 0, 0));
            ////Border tableborderInfosDocument = new Border(1, new RgbColor(0, 0, 0));
            ////tableInfosDocument.Borders = new TableBorders(tableborderInfosDocument);

            ////tableInfosDocument.DefaultCellProperties.Borders = new TableCellBorders(cellborderInfosDocument, cellborderInfosDocument, cellborderInfosDocument, cellborderInfosDocument);
            ////tableInfosDocument.DefaultCellProperties.Padding = new Thickness(5, 5, 5, 5);
            ////tableInfosDocument.DefaultCellProperties.Background = new RgbColor(250, 250, 250);

            //////Table Header
            ////TableRow headerRowInfosDocument = tableInfosDocument.Rows.AddTableRow();
            ////headerRowInfosDocument.Cells.AddTableCell().Blocks.AddBlock().InsertText("Numéro");
            ////headerRowInfosDocument.Cells.AddTableCell().Blocks.AddBlock().InsertText("Date");
            ////headerRowInfosDocument.Cells.AddTableCell().Blocks.AddBlock().InsertText("Echéance");


            ////TableRow firstRowInfosDocument = tableInfosDocument.Rows.AddTableRow();
            //////Les "varibale" ?? "" servent à , si jamais la variable est nul, à renvoyer un string vide :)     
            ////firstRowInfosDocument.Cells.AddTableCell().Blocks.AddBlock().InsertText(this.document.Numero.ToString());
            ////firstRowInfosDocument.Cells.AddTableCell().Blocks.AddBlock().InsertText(this.document.DateCreation.ToShortDateString());
            ////firstRowInfosDocument.Cells.AddTableCell().Blocks.AddBlock().InsertText(this.priseEnCharge.DateEcheance.ToShortDateString());


            ////editor.InsertTable(tableInfosDocument);
            ////editor.InsertLineBreak();


            //////Infos Entreprise
            ////editor.ParagraphProperties.HorizontalAlignment = Telerik.Windows.Documents.Fixed.Model.Editing.Flow.HorizontalAlignment.Left;
            ////editor.InsertParagraph();
            ////editor.CharacterProperties.FontSize = 12;
            ////editor.InsertLine("Microwest");
            ////editor.InsertLine("Rue de la Pierre-à-Mazel 2");
            ////editor.InsertLine("Tel : 032 841 50 88");
            ////editor.InsertLine("Email : info@microwest.ch");
            ////editor.InsertLine("TVA : CHE-351.511.695");
            ////editor.InsertLineBreak();


            //////Infos Client
            ////editor.ParagraphProperties.HorizontalAlignment = Telerik.Windows.Documents.Fixed.Model.Editing.Flow.HorizontalAlignment.Right;
            ////editor.InsertParagraph();
            ////editor.CharacterProperties.FontSize = 12;
            ////editor.InsertLine(client.Nom);
            ////editor.InsertLine(adresse.adresse);
            ////editor.InsertLine(adresse.NPA + " " + adresse.Ville);
            ////editor.InsertLine(client.Telephone1);
            ////editor.InsertLine(client.Email1);
            ////editor.InsertLineBreak();




            //////Table contenant les lignes Articles du document
            ////editor.InsertParagraph();
            ////Table table = new Table();
            ////Border cellborder = new Border(1, new RgbColor(0, 0, 0));
            ////Border tableborder = new Border(2, new RgbColor(0, 0, 0));
            ////table.Borders = new TableBorders(tableborder);

            ////table.DefaultCellProperties.Borders = new TableCellBorders(cellborder, cellborder, cellborder, cellborder);
            ////table.DefaultCellProperties.Padding = new Thickness(5, 5, 5, 5);
            ////table.DefaultCellProperties.Background = new RgbColor(250, 250, 250);


            //////Table Header
            ////TableRow headerRow = table.Rows.AddTableRow();
            ////headerRow.Cells.AddTableCell().Blocks.AddBlock().InsertText("Code");
            ////headerRow.Cells.AddTableCell().Blocks.AddBlock().InsertText("Description");
            ////headerRow.Cells.AddTableCell().Blocks.AddBlock().InsertText("Qté");
            ////headerRow.Cells.AddTableCell().Blocks.AddBlock().InsertText("Taux Remise");
            ////headerRow.Cells.AddTableCell().Blocks.AddBlock().InsertText("Taux TVA");
            ////headerRow.Cells.AddTableCell().Blocks.AddBlock().InsertText("Prix Unité");
            ////headerRow.Cells.AddTableCell().Blocks.AddBlock().InsertText("Prix Total TTC");

            ////foreach (var item in Lignes)
            ////{

            ////    TableRow firstRow = table.Rows.AddTableRow();

            ////    //Les "varibale" ?? "" servent à , si jamais la variable est nul, à renvoyer un string vide :)     
            ////    firstRow.Cells.AddTableCell().Blocks.AddBlock().InsertText(item.CodeArticle ?? "");
            ////    firstRow.Cells.AddTableCell().Blocks.AddBlock().InsertText(item.Libelle ?? "");
            ////    firstRow.Cells.AddTableCell().Blocks.AddBlock().InsertText(item.Quantite.ToString() ?? "");
            ////    firstRow.Cells.AddTableCell().Blocks.AddBlock().InsertText(item.TauxRemise.ToString() ?? "");
            ////    firstRow.Cells.AddTableCell().Blocks.AddBlock().InsertText(item.TauxTVA.ToString() ?? "");
            ////    firstRow.Cells.AddTableCell().Blocks.AddBlock().InsertText(item.PrixUniteTTC.ToString() ?? "");
            ////    firstRow.Cells.AddTableCell().Blocks.AddBlock().InsertText(item.PrixTTC.ToString() ?? ""); ;
            ////}

            ////editor.InsertTable(table);
            ////editor.InsertLineBreak();


            //////Table contenant les Totaux
            ////editor.InsertParagraph();
            ////Table tableTotaux = new Table();
            ////Border borderTotauxCell = new Border(1, new RgbColor(0, 0, 0));
            ////Border borderTotauxTable = new Border(2, new RgbColor(0, 0, 0));
            ////tableTotaux.Borders = new TableBorders(borderTotauxTable);

            ////tableTotaux.DefaultCellProperties.Borders = new TableCellBorders(borderTotauxCell, borderTotauxCell, borderTotauxCell, borderTotauxCell);
            ////tableTotaux.DefaultCellProperties.Padding = new Thickness(5, 5, 5, 5);
            ////tableTotaux.DefaultCellProperties.Background = new RgbColor(250, 250, 250);

            //////Header Totaux
            ////TableRow headerRowTotaux = tableTotaux.Rows.AddTableRow();
            ////headerRowTotaux.Cells.AddTableCell().Blocks.AddBlock().InsertText("Total Remise");
            ////headerRowTotaux.Cells.AddTableCell().Blocks.AddBlock().InsertText("Total HT");
            ////headerRowTotaux.Cells.AddTableCell().Blocks.AddBlock().InsertText("Total TVA");
            ////headerRowTotaux.Cells.AddTableCell().Blocks.AddBlock().InsertText("Total TTC");
            ////headerRowTotaux.Cells.AddTableCell().Blocks.AddBlock().InsertText("Total Reglé");
            ////headerRowTotaux.Cells.AddTableCell().Blocks.AddBlock().InsertText("Net à payer");


            //////Lignes Contenant les totaux (BODY du table)
            ////TableRow rowTotaux = tableTotaux.Rows.AddTableRow();
            ////rowTotaux.Cells.AddTableCell().Blocks.AddBlock().InsertText(TotalRemise.ToString() ?? "");
            ////rowTotaux.Cells.AddTableCell().Blocks.AddBlock().InsertText(TotalHT.ToString() ?? "");
            ////rowTotaux.Cells.AddTableCell().Blocks.AddBlock().InsertText(TotalTVA.ToString() ?? "");
            ////rowTotaux.Cells.AddTableCell().Blocks.AddBlock().InsertText(TotalTTC.ToString() ?? "");
            ////rowTotaux.Cells.AddTableCell().Blocks.AddBlock().InsertText(TotalRegle.ToString() ?? "");
            ////rowTotaux.Cells.AddTableCell().Blocks.AddBlock().InsertText(NetAPayer.ToString() ?? "");

            ////editor.InsertTable(tableTotaux);



            ////editor.ParagraphProperties.HorizontalAlignment = Telerik.Windows.Documents.Fixed.Model.Editing.Flow.HorizontalAlignment.Left;
            ////editor.InsertParagraph();
            ////editor.InsertLineBreak();
            //////Liste des règlements
            ////editor.InsertLine("Règlements :");
            ////foreach (var item in ListeReglements)
            ////{
            ////    editor.InsertRun(item.Date.ToShortDateString());
            ////    editor.InsertRun(" / " + item.Montant.ToString() + " CHF");
            ////    editor.InsertRun(" / " + Connexion.maBDD.Get<MethodePaiement>(item.ID_MethodePaiement).Libelle);
            ////    editor.InsertLineBreak();
            ////    editor.InsertParagraph();
            ////}



            //////Export en PDF
            ////PdfFormatProvider provider = new PdfFormatProvider();
            ////using (Stream output = File.OpenWrite(@"D:\Users\Kafe\Desktop\temp\Hello.pdf"))
            ////{
            ////    provider.Export(document, output);
            ////}

        }
    }
}

