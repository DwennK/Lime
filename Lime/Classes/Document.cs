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
    [Table("Documents")]
    public class Document
    {
        [Computed]
        [Browsable(false)] //Permet de ne pas afficher la colonne dans les DataGrid par exemple. [Browsable(false)] //Permet de ne pas afficher la colonne dans les DataGrid par exemple.

        public int ID { get; set; }
        [Computed]
        [Browsable(false)] //Permet de ne pas afficher la colonne dans les DataGrid par exemple. [Browsable(false)] //Permet de ne pas afficher la colonne dans les DataGrid par exemple.

        public int ID_PriseEnCharge { get; set; }
        [Computed]
        [Browsable(false)] //Permet de ne pas afficher la colonne dans les DataGrid par exemple. [Browsable(false)] //Permet de ne pas afficher la colonne dans les DataGrid par exemple.

        public int ID_TypeDocument { get; set; }
        [Display(Name = "Numéro")]
        public string Numero { get; set; }
        [Display(Name = "Clôturé")]
        public string Cloture { get; set; }

        public Document()
        {

        }

        public Document(int ID_, int ID_PriseEnCharge_, int ID_TypeDocument_, string Numero_, string Cloture_)
        {
            this.ID = ID_;
            this.ID_PriseEnCharge = ID_PriseEnCharge_;
            this.ID_TypeDocument = ID_TypeDocument_;
            this.Numero = Numero_;
            this.Cloture = Cloture_;
        }
    }
}
