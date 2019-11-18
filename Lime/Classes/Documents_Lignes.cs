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


namespace Lime
{
    //Spécifie le nom de la table à Utiliser pour Dapper Contrib (Obligatoire)
    [Table("Documents_Lignes")]
    public class Documents_Lignes
    {
        [Computed]
        [Browsable(false)] //Permet de ne pas afficher la colonne dans les DataGrid par exemple. [Browsable(false)] //Permet de ne pas afficher la colonne dans les DataGrid par exemple.
        public int ID { get; set; }
        [Browsable(false)] //Permet de ne pas afficher la colonne dans les DataGrid par exemple. [Browsable(false)] //Permet de ne pas afficher la colonne dans les DataGrid par exemple.
        public int ID_Documents { get; set; }
        [Display(Name = "Code Article")]
        public string CodeArticle { get; set; }
        [Display(Name = "Libellé")]
        public string Libelle { get; set; }
        [Browsable(false)] //Permet de ne pas afficher la colonne dans les DataGrid par exemple. [Browsable(false)] //Permet de ne pas afficher la colonne dans les DataGrid par exemple.

        public int Ordre { get; set; }
        [Display(Name = "Quantité")]
        public int Quantite { get; set; }
        [Display(Name = "Prix achat")]
        [Browsable(false)] //Permet de ne pas afficher la colonne dans les DataGrid par exemple. [Browsable(false)] //Permet de ne pas afficher la colonne dans les DataGrid par exemple.
        public decimal? PrixAchatUnite { get; set; }
        [Display(Name = "Taux TVA")]
        [Browsable(false)] //Permet de ne pas afficher la colonne dans les DataGrid par exemple. [Browsable(false)] //Permet de ne pas afficher la colonne dans les DataGrid par exemple.
        public decimal? TauxTVA { get; set; }
        [Display(Name = "Taux Remise")]
        public decimal? TauxRemise { get; set; }
        [Display(Name = "Total TVA")]
        [Browsable(false)] //Permet de ne pas afficher la colonne dans les DataGrid par exemple. [Browsable(false)] //Permet de ne pas afficher la colonne dans les DataGrid par exemple.
        public decimal? TotalTVA { get; set; }
        [Display(Name = "Prix TTC")]
        public decimal PrixTotal { get; set; }
    }
}
