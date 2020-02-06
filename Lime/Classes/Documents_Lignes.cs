using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Dapper.Contrib;
using Dapper.Contrib.Extensions;
using System.ComponentModel; //Sert à changer l'affichage du nom de la propritéé dans la BDD par un texte(Last Name au lieu de lastname par exemple)
using System.ComponentModel.DataAnnotations;
using System.Configuration;
using MySql.Data.MySqlClient;

namespace Lime
{
    [Serializable]
    //Spécifie le nom de la table à Utiliser pour Dapper Contrib (Obligatoire)
    [System.ComponentModel.DataAnnotations.Schema.Table("Documents_Lignes")]
    public class Documents_Lignes : ICloneable
    {
        [Computed]
        [Browsable(false)] //Permet de ne pas afficher la colonne dans les DataGrid par exemple. [Browsable(false)] //Permet de ne pas afficher la colonne dans les DataGrid par exemple.
        public int ID { get; set; }
        [Browsable(false)] //Permet de ne pas afficher la colonne dans les DataGrid par exemple. [Browsable(false)] //Permet de ne pas afficher la colonne dans les DataGrid par exemple.
        public int ID_Documents { get; set; }
        [Display(Name = "Code Article")]
        public string CodeArticle { get; set; }
        [Display(Name = "Libellé")]
        [DataType(DataType.MultilineText)]
        public string Libelle { get; set; }
        [Browsable(false)] //Permet de ne pas afficher la colonne dans les DataGrid par exemple. [Browsable(false)] //Permet de ne pas afficher la colonne dans les DataGrid par exemple.
        public int Ordre { get; set; }
        [Display(Name = "Quantité")]
        public int Quantite { get; set; }
        [Display(Name = "Prix achat")]
        [Browsable(false)] //Permet de ne pas afficher la colonne dans les DataGrid par exemple. [Browsable(false)] //Permet de ne pas afficher la colonne dans les DataGrid par exemple.
        [DisplayFormat(DataFormatString = "{0:C}")]
        public double? PrixAchatUnite { get; set; }
        [Display(Name = "Taux TVA")]
        [Browsable(false)] //Permet de ne pas afficher la colonne dans les DataGrid par exemple. [Browsable(false)] //Permet de ne pas afficher la colonne dans les DataGrid par exemple.
        [DisplayFormat(DataFormatString = "{0:C}")]
        public double? TauxTVA { get; set; }
        [Display(Name = "Taux Remise")]
        [DisplayFormat(DataFormatString = "{0:N}")]
        public double TauxRemise { get; set; }
        [Display(Name = "Total TVA")]
        [DisplayFormat(DataFormatString = "{0:C}")]
        [Browsable(false)] //Permet de ne pas afficher la colonne dans les DataGrid par exemple. [Browsable(false)] //Permet de ne pas afficher la colonne dans les DataGrid par exemple.
        public double? TotalTVA { get; set; }
        [Display(Name = "Prix Unité TTC")]
        [DisplayFormat(DataFormatString = "{0:C}")]
        public double PrixUniteTTC { get; set; }
        [Display(Name = "Prix TTC")]
        [DisplayFormat(DataFormatString = "{0:C}")]
        [Editable(false)] //Vu que ce champ est calculé (Prix Unite * Quantité), on le rend non modifiable.
        public double PrixTTC { get; set; }


        public Documents_Lignes()
        {
            this.TauxRemise = 0;
            this.Quantite = 1; //Valeur par défaut lors de la création d'une nouvelle ligne


            //Récupération de la TVA depuis les paramètres, dans la BDD
            string strConnexionString = ConfigurationManager.ConnectionStrings["ConnexionString"].ConnectionString;
            MySqlConnection connexion = new MySqlConnection(strConnexionString);
            this.TauxTVA = connexion.Get<Parametre>(1).TauxTVAParDefaut;
            connexion.Close();
        }

        public Documents_Lignes(int ID_Documents) //Constructeur avec l'identifiant pour le lier directement à un document.
        {
            this.ID_Documents = ID_Documents;
            this.TauxRemise = 0;
            this.Quantite = 1; //Valeur par défaut lors de la création d'une nouvelle ligne


            //Récupération de la TVA depuis les paramètres, dans la BDD
            string strConnexionString = ConfigurationManager.ConnectionStrings["ConnexionString"].ConnectionString;
            MySqlConnection connexion = new MySqlConnection(strConnexionString);
            this.TauxTVA = connexion.Get<Parametre>(1).TauxTVAParDefaut;
            connexion.Close();
        }


        public virtual object Clone()
        {
            //On stocke le clone dans un Dynamic
            dynamic temp = this.MemberwiseClone();

            //On retire l'ID
            temp.ID = 0;

            //On renvoie le clone de la ligne, mais sans l'ID.
            return temp;
        }
    }


}
