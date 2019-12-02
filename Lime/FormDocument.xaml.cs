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
        public FormDocument(PriseEnCharge priseEnCharge, int ID_TypeDocuments)
        {
            InitializeComponent();
            this.action = "Insert";
            this.priseEnCharge = priseEnCharge;
            client = Connexion.maBDD.Get<Client>(this.priseEnCharge.ID_Clients);
            this.typeDocument = Connexion.maBDD.GetAll<TypeDocuments>().Where(x => x.ID == ID_TypeDocuments).FirstOrDefault();



            var xx = Connexion.maBDD.GetAll<Documents_Lignes>().Where(x => x.ID_Documents == document.ID && document.ID_PriseEnCharge == priseEnCharge.ID);


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

            //Lignes.Clear();
            //foreach (Documents_Lignes value in Lignes)
            //{
            //    Lignes.Add(value);
            //}


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



            foreach(var item in Lignes) //Ces variables sont dans le DataContext
            {
                //ITEM/////////////////////

                //Total TTC ITEM
                if (item.TauxRemise > 0)
                {
                    item.PrixTTC = (item.PrixUniteTTC * item.Quantite);
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

                    //TotalRéglé
                    TotalRegle = 0; //TODO TO DO To-DO

                    //NetAPayer
                    NetAPayer = 0; //TODO TO DO To-DO

                //FIN GOBAL DOCUMENT///////

            }
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
    }
}

