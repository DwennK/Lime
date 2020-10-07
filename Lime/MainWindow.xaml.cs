using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Configuration;
using MySql.Data.MySqlClient; //MYSQL
using Telerik.Windows.Controls;
using Telerik.Windows.Controls.GridView;
using System.Text.RegularExpressions;
using Dapper;
using Dapper.Contrib;
using Dapper.Contrib.Extensions;
using System.Data.SqlClient;
using System.Globalization;
using System.Threading;
using Telerik.Windows.Documents.Fixed.Model;
using Telerik.Windows.Documents.Fixed.Model.Editing;
using Telerik.Windows.Documents.Fixed.FormatProviders.Pdf;
using System.IO;
using Telerik.Reporting;

namespace Lime
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //GLOBAL VARIABLES
        readonly static string strConnexionString = ConfigurationManager.ConnectionStrings["ConnexionString"].ConnectionString;
        SqlConnectionStringBuilder sqlString = new SqlConnectionStringBuilder(strConnexionString);

        public MainWindow()
        {
            //Theme Global
            //StyleManager.ApplicationTheme = new CrystalTheme();
            InitializeComponent();
            Properties.Settings.Default.Reload();

            // Change current culture
            CultureInfo culture;
            culture = CultureInfo.CreateSpecificCulture("fr-FR");

            Thread.CurrentThread.CurrentCulture = culture;
            Thread.CurrentThread.CurrentUICulture = culture;


            Populate();
        }


        public void Populate()
        {
            //IP Server dans la statusBar
            this.lblStatusConnexion.Content = "Server :" + sqlString.DataSource;
            this.lblDatabase.Content = "Database :" + sqlString.InitialCatalog;

            //Nom du magasin acutellement connecté
            if (Connexion.CheckForInternetConnection())
            {
                this.lblNomDuMagasin.Text = Connexion.maBDD.Get<Magasin>(Properties.Settings.Default.ID_Magasin).Libelle;
            }

            //Nombre de prises en charges aujourd'hui
            if (Connexion.CheckForInternetConnection())
            {
                this.lblNombreDePriseEnChargeAujourdhui.Text = Connexion.maBDD.GetAll<PriseEnCharge>().Where(x => x.DateDebut.Date == DateTime.Now.Date).Count<PriseEnCharge>().ToString();
            }

            //Nombre de factures crées aujourd'hui
            if (Connexion.CheckForInternetConnection())
            {
                this.lblNombreDeFactureAujourdhui.Text = Connexion.maBDD.GetAll<Document>().Where(x => x.DateCreation.Date == DateTime.Today.Date).Where(x => x.ID_TypeDocument == 5).Count<Document>().ToString();
            }
        }
      

        private void tabClients_Click(object sender, RoutedEventArgs e)
        {
            UpdateGridView(Client.GetAllClients().ToList());
        }

        
        //On recoit un IEnumerable, contenant un type de IEnumerable inconnu (Client ? Factures ? Prise en charge?), et donc, comme type, on met Ienumerable<object>, vu qu'ils en dérivent tous.
        public void UpdateGridView(IEnumerable<object> mesData)
        {
            this.RadGridView1.ItemsSource = mesData;
        }



        private void AjoutClient_Click(object sender, RoutedEventArgs e)
        {
            FormClient maFenetre = new FormClient("Insert", "");
            maFenetre.Closed += FormClientHandler;
            maFenetre.Show();
        }

        //Se fait appeler quand une modification/ajout d'un client a eu lieu, mais dans une autre fenêtre que celle-ci (la methode UpdateGridView ne peux pas se faire appeler depuis une autre fenetre)
        public void FormClientHandler(object sender, EventArgs e)
        {
            UpdateGridView(Connexion.maBDD.GetAll<Client>());
        }

        //Se fait appeler quand une modification/ajout a eu lieu, mais dans une autre fenêtre que celle-ci (la methode UpdateGridView ne peux pas se faire appeler depuis une autre fenetre)
        public void FormPriseEnChargeHandler(object sender, EventArgs e)
        {
            UpdateGridView(Connexion.maBDD.GetAll<PriseEnCharge>());
        }


        private void ModifierClient_Click(object sender, RoutedEventArgs e)
        {
            Client client = (Client)RadGridView1.SelectedItem;
            FormClient maFenetre2 = new FormClient(client);
            maFenetre2.Closed += FormClientHandler;
            maFenetre2.Show();
        }

        private void SupprimmerClient_Click(object sender, RoutedEventArgs e)
        {
            RadWindow.Confirm(new DialogParameters
            {
                Header = "Attention",
                Content = "Êtes-vous sûr de vouloir supprimer ce client ?\nCette action est définitive",
                Closed = this.SupprimmerClient_Click_OnClosed,  
                Theme = new CrystalTheme()
            });

        }

        private void SupprimmerClient_Click_OnClosed(object sender, WindowClosedEventArgs e)
        {
            if(Connexion.CheckForInternetConnection())
            {
                //Si le client confirme la supression, alors son supprime vraiment l'item.
                var result = e.DialogResult;
                if (result == true)
                {
                    Client client = (Client)RadGridView1.SelectedItem;
                    Connexion.maBDD.Delete<Client>(client);
                    UpdateGridView(Connexion.maBDD.GetAll<Client>());
                }
            }
        }

        private void RadRibbonButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void tabClients_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (Connexion.CheckForInternetConnection())
            {
                RadTabbedWindow1.SelectedItem = RadTabLignes;
                UpdateGridView(Connexion.maBDD.GetAll<Client>());
            }
        }


        private void tabPriseEnCharge_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if(Connexion.CheckForInternetConnection())
            {
                RadTabbedWindow1.SelectedItem = RadTabLignes;
                UpdateGridView(Connexion.maBDD.GetAll<PriseEnCharge>());
            }
        }

        private void InsertPriseEnCharge(object sender, RoutedEventArgs e)
        {
            FormPriseEnCharge maFenetre = new FormPriseEnCharge();
            maFenetre.Closed += FormPriseEnChargeHandler;
            maFenetre.Show();
        }

        private void UpdatePriseEnCharge_Click(object sender, RoutedEventArgs e)
        {
            if(RadGridView1.SelectedItem != null)
            {
                PriseEnCharge priseEnCharge = (PriseEnCharge)RadGridView1.SelectedItem;


                FormPriseEnCharge maFenetre = new FormPriseEnCharge(priseEnCharge);
                maFenetre.Closed += FormPriseEnChargeHandler;
                maFenetre.Show();
            }

        }

        private void DeletePriseEnCharge_Click(object sender, RoutedEventArgs e)
        {


            RadWindow.Confirm(new DialogParameters
            {
                Header = "Attention",
                Content = "Êtes-vous sûr de vouloir supprimer cet élément ?\nCette action est définitive",
                Closed = DeletePriseEnCharge_Click_OnClosed,
                Theme = new CrystalTheme()
            });

        }

        private void DeletePriseEnCharge_Click_OnClosed(object sender, WindowClosedEventArgs e)
        {
            if (Connexion.CheckForInternetConnection())
            {
                //Si le client confirme la supression, alors on supprime vraiment l'item.
                var result = e.DialogResult;
                if (result == true)
                {
                    PriseEnCharge priseEnCharge = (PriseEnCharge)RadGridView1.SelectedItem;
                    Connexion.maBDD.Delete<PriseEnCharge>(priseEnCharge);
                    UpdateGridView(Connexion.maBDD.GetAll<PriseEnCharge>());
                }
            }
        }

        private void btnDevis_Click(object sender, RoutedEventArgs e)
        {
            if(RadGridView1.SelectedItem != null)
            {
                //DEVIS
                int ID_TypeDocuments = 1; //Représente le numéro de ce Type de Document dans la BDD
                Document document = GetDocument(ID_TypeDocuments);

                //Récupération de la prise en charge
                PriseEnCharge priseEnCharge = (PriseEnCharge)RadGridView1.SelectedItem;


                if (document != null)//Si le document existe déjà.
                {
                    //UPDATE
                    FormDocument maFenetre = new FormDocument(priseEnCharge, document);
                    maFenetre.Show();
                }
                else //Si le document n'existe pas encore.
                {
                    //INSERT
                    ObservableCollection<Documents_Lignes> Lignes = new ObservableCollection<Documents_Lignes>(); //Vide.
                    FormDocument maFenetre = new FormDocument(priseEnCharge, ID_TypeDocuments, Lignes);
                    maFenetre.Show();
                }
            }
            else 
            {
                Alerte.SelectionVide();
            }
        }


        private void btnConstatAssurance_Click(object sender, RoutedEventArgs e)
        {
            if (RadGridView1.SelectedItem != null)
            {
                //CONSTAT ASSURANCE
                int ID_TypeDocuments = 2; //Représente le numéro de ce Type de Document dans la BDD
                Document document = GetDocument(ID_TypeDocuments);

                //Récupération de la prise en charge
                PriseEnCharge priseEnCharge = (PriseEnCharge)RadGridView1.SelectedItem;


                if (document != null)//Si le document existe déjà.
                {
                    //UPDATE
                    FormDocument maFenetre = new FormDocument(priseEnCharge, document);
                    maFenetre.Show();
                }
                else //Si le document n'existe pas encore.
                {
                    //INSERT
                    ObservableCollection<Documents_Lignes> Lignes = new ObservableCollection<Documents_Lignes>(); //Vide.
                    FormDocument maFenetre = new FormDocument(priseEnCharge, ID_TypeDocuments, Lignes);
                    maFenetre.Show();
                }
            }
            else
            {
                Alerte.SelectionVide();
            }
        }

        private void btnCommandePieces_Click(object sender, RoutedEventArgs e)
        {
            if (RadGridView1.SelectedItem != null)
            {
                //COMMANDE PIECE
                int ID_TypeDocuments = 3; //Représente le numéro de ce Type de Document dans la BDD
                Document document = GetDocument(ID_TypeDocuments);

                //Récupération de la prise en charge
                PriseEnCharge priseEnCharge = (PriseEnCharge)RadGridView1.SelectedItem;


                if (document != null)//Si le document existe déjà.
                {
                    //UPDATE
                    FormDocument maFenetre = new FormDocument(priseEnCharge, document);
                    maFenetre.Show();
                }
                else //Si le document n'existe pas encore.
                {
                    //INSERT
                    ObservableCollection<Documents_Lignes> Lignes = new ObservableCollection<Documents_Lignes>(); //Vide.
                    FormDocument maFenetre = new FormDocument(priseEnCharge, ID_TypeDocuments, Lignes);
                    maFenetre.Show();
                }
            }
            else
            {
                Alerte.SelectionVide();
            }
        }

        private void btnReparation_Click(object sender, RoutedEventArgs e)
        {
            if (RadGridView1.SelectedItem != null)
            {
                //Reparation
                int ID_TypeDocuments = 4; //Représente le numéro de ce Type de Document dans la BDD
                Document document = GetDocument(ID_TypeDocuments);

                //Récupération de la prise en charge
                PriseEnCharge priseEnCharge = (PriseEnCharge)RadGridView1.SelectedItem;


                if (document != null)//Si le document existe déjà.
                {
                    //UPDATE
                    FormDocument maFenetre = new FormDocument(priseEnCharge, document);
                    maFenetre.Show();
                }
                else //Si le document n'existe pas encore.
                {
                    //INSERT
                    ObservableCollection<Documents_Lignes> Lignes = new ObservableCollection<Documents_Lignes>(); //Vide.
                    FormDocument maFenetre = new FormDocument(priseEnCharge, ID_TypeDocuments, Lignes);
                    maFenetre.Show();
                }
            }
            else
            {
                Alerte.SelectionVide();
            }
        }

        private void btnFacture_Click(object sender, RoutedEventArgs e)
        {
            if (RadGridView1.SelectedItem != null)
            {
                //Facture
                int ID_TypeDocuments = 5; //Représente le numéro de ce Type de Document dans la BDD
                Document document = GetDocument(ID_TypeDocuments);

                //Récupération de la prise en charge
                PriseEnCharge priseEnCharge = (PriseEnCharge)RadGridView1.SelectedItem;


                if (document != null)//Si le document existe déjà.
                {
                    //UPDATE
                    FormDocument maFenetre = new FormDocument(priseEnCharge, document);
                    maFenetre.Show();
                }
                else //Si le document n'existe pas encore.
                {
                    //INSERT
                    ObservableCollection<Documents_Lignes> Lignes = new ObservableCollection<Documents_Lignes>(); //Vide.
                    FormDocument maFenetre = new FormDocument(priseEnCharge, ID_TypeDocuments, Lignes);
                    maFenetre.Show();
                }
            }
            else
            {
                Alerte.SelectionVide();
            }
        }

        private void btnSAV_Click(object sender, RoutedEventArgs e)
        {
            if (RadGridView1.SelectedItem != null)
            {
                //SAV
                int ID_TypeDocuments = 6; //Représente le numéro de ce Type de Document dans la BDD
                Document document = GetDocument(ID_TypeDocuments);

                //Récupération de la prise en charge
                PriseEnCharge priseEnCharge = (PriseEnCharge)RadGridView1.SelectedItem;


                if (document != null)//Si le document existe déjà.
                {
                    //UPDATE
                    FormDocument maFenetre = new FormDocument(priseEnCharge, document);
                    maFenetre.Show();
                }
                else //Si le document n'existe pas encore.
                {
                    //INSERT
                    ObservableCollection<Documents_Lignes> Lignes = new ObservableCollection<Documents_Lignes>(); //Vide.
                    FormDocument maFenetre = new FormDocument(priseEnCharge, ID_TypeDocuments, Lignes);
                    maFenetre.Show();
                }
            }
            else
            {
                Alerte.SelectionVide();
            }
        }

        private Document GetDocument(int NumeroDuTypeDocumentDansLaBDD) //Cette fonction retourne un Document (si existant), lié à une prise en charge.
        {
            if (Connexion.CheckForInternetConnection())
            {
                PriseEnCharge priseEnCharge = (PriseEnCharge)RadGridView1.SelectedItem;

                //On récupère le document correspondant, s'il en existe un.
                Document document = Connexion.maBDD.GetAll<Document>().Where(x => x.ID_PriseEnCharge == priseEnCharge.ID && x.ID_TypeDocument == NumeroDuTypeDocumentDansLaBDD).FirstOrDefault();

                //Retourne le document correspondant 
                return document;
            }
            return null;
        }

        private void tabDevis_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (Connexion.CheckForInternetConnection())
            {
                RadTabbedWindow1.SelectedItem = RadTabLignes;
                int ID_typeDocument = 1; //SAV
                UpdateGridView(Connexion.maBDD.GetAll<Document>().Where(x => x.ID_TypeDocument == ID_typeDocument));
            }
        }
        private void tabConstatAssurance_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (Connexion.CheckForInternetConnection())
            {
                RadTabbedWindow1.SelectedItem = RadTabLignes;
                int ID_typeDocument = 2; //Devis Assurance
                UpdateGridView(Connexion.maBDD.GetAll<Document>().Where(x => x.ID_TypeDocument == ID_typeDocument));
            }
        }

        private void tabCommande_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (Connexion.CheckForInternetConnection())
            {
                RadTabbedWindow1.SelectedItem = RadTabLignes;
                int ID_typeDocument = 3; //Commande
                UpdateGridView(Connexion.maBDD.GetAll<Document>().Where(x => x.ID_TypeDocument == ID_typeDocument));
            }
        }

        private void tabReparation_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (Connexion.CheckForInternetConnection())
            {
                RadTabbedWindow1.SelectedItem = RadTabLignes;
                int ID_typeDocument = 4; //Réparation
                UpdateGridView(Connexion.maBDD.GetAll<Document>().Where(x => x.ID_TypeDocument == ID_typeDocument));
            }
        }

        private void tabFactures_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (Connexion.CheckForInternetConnection())
            {
                ////On vide le contenu de TabLignes (Grid)
                //TabLignes.Children.Clear();
                //GridViewDocument monControle = new GridViewDocument();
                //TabLignes.Children.Add(monControle);

                ////---------------------------------------------------------------------------------------
                //string SQL =
                //"SELECT Documents.Closed, Documents.Printed, Documents.Mailed,Documents.ID, Documents.ID_PriseEnCharge, Documents.Numero, PriseEnCharges.Nom, PriseEnCharges.DateDebut, PriseEnCharges.DateEcheance, SUM(Documents_Lignes.PrixTTC) as TotalTTC, SUM(DISTINCT Reglements.Montant) AS TotalRegle, SUM(Documents_Lignes.PrixTTC) -SUM(DISTINCT Reglements.Montant) AS NetAPayer " +
                //"FROM Documents " +
                //"INNER JOIN Documents_Lignes ON Documents.ID = Documents_Lignes.ID_Documents " +
                //"INNER JOIN PriseEnCharges ON Documents.ID_PriseEnCharge = PriseEnCharges.ID " +
                //"LEFT OUTER JOIN Reglements ON PriseEnCharges.ID = Reglements.ID_PriseEnCharges " +
                //"WHERE Documents.ID_TypeDocument = 5 " +
                //"GROUP BY Documents.ID " +
                //"LIMIT @Limit ";

                //var mesData = Connexion.maBDD.Query(SQL, new { Limit = Properties.Settings.Default.Limite });

                //monControle.RadGridView1.ItemsSource = mesData;


                //---------------------------------------------------------------------------------------


            }


        }

        private void tabSAV_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (Connexion.CheckForInternetConnection())
            {
                RadTabbedWindow1.SelectedItem = RadTabLignes;
                int ID_typeDocument = 6; //SAV
                UpdateGridView(Connexion.maBDD.GetAll<Document>().Where(x => x.ID_TypeDocument == ID_typeDocument));
            }
        }

        private void tabArticles_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (Connexion.CheckForInternetConnection())
            {
                RadTabbedWindow1.SelectedItem = RadTabLignes;
                UpdateGridView(Connexion.maBDD.GetAll<Article>());
            }
        }

        private void tabAccueil_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            RadTabbedWindow1.SelectedItem = RadTabAcceuil;
            Populate();
        }

        private void btnParametres_Click(object sender, RoutedEventArgs e)
        {
            FormParametre maFenetre = new FormParametre();
            maFenetre.ShowDialog();
        }

        private void tabSMS_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            RadTabbedWindow1.SelectedItem = RadTabSMS;
        }

        private void RadTabbedWindow1_PreviewTabClosed(object sender, PreviewTabChangedEventArgs e)
        {
            //Comme ça ça empêche la fermeture des tabs (vu qu'il n'y a pas de propriété pour le faire)
            e.Cancel = true;
        }

        private void btnDeconnexion_Click(object sender, RoutedEventArgs e)
        {
            Login maFenetre = new Login();
            maFenetre.Show();

            this.Close();

        }

        private void DocumentModifier_Click(object sender, RoutedEventArgs e)
        {
            if (RadGridView1.SelectedItem != null)
            {
                Document document = (Document)RadGridView1.SelectedItem;

                PriseEnCharge priseEnCharge = Connexion.maBDD.Get<PriseEnCharge>(document.ID_PriseEnCharge);

                if (document != null)//Si le document existe déjà.
                {
                    //UPDATE
                    FormDocument maFenetre = new FormDocument(priseEnCharge, document);
                    maFenetre.Show();
                }
            }
            else
            {
                RadWindow.Alert(new DialogParameters
                {
                    Header = "Attention",
                    Content = "Veuillez sélectionner un élément dans la liste.",
                    Theme = new CrystalTheme()
                });
            }
        }

        private void DocumentSupprimer_Click(object sender, RoutedEventArgs e)
        {
            if (RadGridView1.SelectedItem != null)
            {
                RadWindow.Confirm(new DialogParameters
                {
                    Header = "Attention",
                    Content = "Êtes-vous sûr de vouloir supprimer ce document ?\nCette action est définitive",
                    Closed = this.SupprimmerDocument_Click_OnClosed,
                    Theme = new CrystalTheme()
                });

            }
            else
            {
                RadWindow.Alert(new DialogParameters
                {
                    Header = "Attention",
                    Content = "Veuillez sélectionner un élément dans la liste.",
                    Theme = new CrystalTheme()
                });
            }
        }

        private void SupprimmerDocument_Click_OnClosed(object sender, WindowClosedEventArgs e)
        {
            if (Connexion.CheckForInternetConnection())
            {
                //Récupération du document
                Document documentASupprimer = (Document)RadGridView1.SelectedItem;

                //Si confirmation la supression, alors on supprime vraiment le document
                var result = e.DialogResult;
                if (result == true)
                {
                    Connexion.maBDD.Delete(documentASupprimer);
                }
            }
        }

        private void InsertArticle_Click(object sender, RoutedEventArgs e)
        {
            //Article Vide
            Article article = new Article();


            FormArticle maFenetre = new FormArticle(article);
            maFenetre.ShowDialog();

            //On actualise la liste à nouveau.
            RadTabbedWindow1.SelectedItem = RadTabLignes;
            UpdateGridView(Connexion.maBDD.GetAll<Article>());

        }

        private void UpdateArticle_Click(object sender, RoutedEventArgs e)
        {
            if (RadGridView1.SelectedItem != null)
            {
                Article article = (Article)RadGridView1.SelectedItem;

                if (article != null)//Si l'article existe déjà.
                {
                    //UPDATE
                    FormArticle maFenetre = new FormArticle(article);
                    maFenetre.ShowDialog();

                    //On actualise la liste à nouveau.
                    RadTabbedWindow1.SelectedItem = RadTabLignes;
                    UpdateGridView(Connexion.maBDD.GetAll<Article>());
                }
            }
            else
            {
                RadWindow.Alert(new DialogParameters
                {
                    Header = "Attention",
                    Content = "Veuillez sélectionner un élément dans la liste.",
                    Theme = new CrystalTheme()
                });
            }
        }

        private void DeleteArticle_Click(object sender, RoutedEventArgs e)
        {
            if (RadGridView1.SelectedItem != null)
            {
                RadWindow.Confirm(new DialogParameters
                {
                    Header = "Attention",
                    Content = "Êtes-vous sûr de vouloir supprimer cet article ?\nCette action est définitive",
                    Closed = this.DeleteArticle_Click_OnClosed,
                    Theme = new CrystalTheme()
                });

            }
            else
            {
                RadWindow.Alert(new DialogParameters
                {
                    Header = "Attention",
                    Content = "Veuillez sélectionner un élément dans la liste.",
                    Theme = new CrystalTheme()
                });
            }
        }
        private void DeleteArticle_Click_OnClosed(object sender, WindowClosedEventArgs e)
        {
            if (Connexion.CheckForInternetConnection())
            {
                //Récupération du document
                Article articleASupprimer = (Article)RadGridView1.SelectedItem;

                //Si confirmation la supression, alors on supprime vraiment le document
                var result = e.DialogResult;
                if (result == true)
                {
                    Connexion.maBDD.Delete(articleASupprimer);

                    //On actualise la liste à nouveau.
                    RadTabbedWindow1.SelectedItem = RadTabLignes;
                    UpdateGridView(Connexion.maBDD.GetAll<Article>());
                }
            }
        }

        private void btnIdentificateurAppareil_Click(object sender, RoutedEventArgs e)
        {
            FormIdentificateurAppareil maFenetre = new FormIdentificateurAppareil();
            maFenetre.Show();
        }

        private void btnSMS_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnParametresMail_Click(object sender, RoutedEventArgs e)
        {
            FormParametreMail maFenetre = new FormParametreMail();
            maFenetre.ShowDialog();
        }

        private void btnFacturesEnCours_Click(object sender, RoutedEventArgs e)
        {
            //On vide le contenu de TabLignes (Grid)
            TabLignes.Children.Clear();
            GridViewDocument monControle = new GridViewDocument();
            TabLignes.Children.Add(monControle);

            //---------------------------------------------------------------------------------------
            string SQL =
                "SELECT Documents.Closed, Documents.Printed, Documents.Mailed,Documents.ID, Documents.ID_PriseEnCharge, Documents.Numero, PriseEnCharges.Nom, PriseEnCharges.DateDebut, PriseEnCharges.DateEcheance, SUM(Documents_Lignes.PrixTTC) as TotalTTC, SUM(DISTINCT Reglements.Montant) AS TotalRegle, SUM(Documents_Lignes.PrixTTC) -SUM(DISTINCT Reglements.Montant) AS NetAPayer "
            +"FROM Documents " +
            "INNER JOIN Documents_Lignes ON Documents.ID = Documents_Lignes.ID_Documents " +
            "INNER JOIN PriseEnCharges ON Documents.ID_PriseEnCharge = PriseEnCharges.ID " +
            "LEFT OUTER JOIN Reglements ON PriseEnCharges.ID = Reglements.ID_PriseEnCharges " +
            "WHERE Documents.ID_TypeDocument = 5 " +
            "GROUP BY Documents.ID " +
            "HAVING TotalRegle < TotalTTC OR TotalRegle IS NULL " +
            "LIMIT @Limit ";

            var mesData = Connexion.maBDD.Query(SQL, new { Limit = Properties.Settings.Default.Limite });


            monControle.RadGridView1.ItemsSource = mesData;

        }

        private void btnFacturesAcquitees_Click(object sender, RoutedEventArgs e)
        {
            //On vide le contenu de TabLignes (Grid)
            TabLignes.Children.Clear();
            GridViewDocument monControle = new GridViewDocument();
            TabLignes.Children.Add(monControle);

            //---------------------------------------------------------------------------------------
            string SQL =
                "SELECT Documents.Closed, Documents.Printed, Documents.Mailed,Documents.ID, Documents.ID_PriseEnCharge, Documents.Numero, PriseEnCharges.Nom, PriseEnCharges.DateDebut, PriseEnCharges.DateEcheance, SUM(Documents_Lignes.PrixTTC) as TotalTTC, SUM(DISTINCT Reglements.Montant) AS TotalRegle, SUM(Documents_Lignes.PrixTTC) -SUM(DISTINCT Reglements.Montant) AS NetAPayer "
            +"FROM Documents "
            + "INNER JOIN Documents_Lignes ON Documents.ID = Documents_Lignes.ID_Documents "
            + "INNER JOIN PriseEnCharges ON Documents.ID_PriseEnCharge = PriseEnCharges.ID "
            + "LEFT OUTER JOIN Reglements ON PriseEnCharges.ID = Reglements.ID_PriseEnCharges "
            + "WHERE Documents.ID_TypeDocument = 5 "
            + "GROUP BY Documents.ID "
            + "HAVING TotalRegle >= TotalTTC "
            + "LIMIT @Limit ";

            var mesData = Connexion.maBDD.Query(SQL,new{Limit = Properties.Settings.Default.Limite});

            monControle.RadGridView1.ItemsSource = mesData;

        }

        private void btnFacturesImpayees_Click(object sender, RoutedEventArgs e)
        {
            //On vide le contenu de TabLignes (Grid)
            TabLignes.Children.Clear();
            GridViewDocument monControle = new GridViewDocument();
            TabLignes.Children.Add(monControle);

            //---------------------------------------------------------------------------------------
            string SQL =
                "SELECT Documents.Closed, Documents.Printed, Documents.Mailed,Documents.ID, Documents.ID_PriseEnCharge, Documents.Numero, PriseEnCharges.Nom, PriseEnCharges.DateDebut, PriseEnCharges.DateEcheance, SUM(Documents_Lignes.PrixTTC) as TotalTTC, SUM(DISTINCT Reglements.Montant) AS TotalRegle, SUM(Documents_Lignes.PrixTTC) -SUM(DISTINCT Reglements.Montant) AS NetAPayer "
            +"FROM Documents  "
            + "INNER JOIN Documents_Lignes ON Documents.ID = Documents_Lignes.ID_Documents "
            + "INNER JOIN PriseEnCharges ON Documents.ID_PriseEnCharge = PriseEnCharges.ID "
            + "LEFT OUTER JOIN Reglements ON PriseEnCharges.ID = Reglements.ID_PriseEnCharges   "
            + "WHERE Documents.ID_TypeDocument = 5  AND CURRENT_TIMESTAMP() > PriseEnCharges.DateEcheance  "
            + "GROUP BY Documents.ID  "
            + "HAVING TotalRegle < TotalTTC OR TotalRegle IS NULL "
            + "LIMIT 50 ";

            var mesData = Connexion.maBDD.Query(SQL, new { Limit = Properties.Settings.Default.Limite });


            monControle.RadGridView1.ItemsSource = mesData;
        }

        private void btnTEST_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
