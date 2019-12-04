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
    [Table("Reglements")]
    public class Reglement : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;


        [Computed]
        [Browsable(false)] //Permet de ne pas afficher la colonne dans les DataGrid par exemple.
        public int ID { get; set; }
        [Browsable(false)] //Permet de ne pas afficher la colonne dans les DataGrid par exemple.

        public int ID_Documents { get; set; }
        [Browsable(false)] //Permet de ne pas afficher la colonne dans les DataGrid par exemple.

        public int ID_MethodePaiement { get; set; }
        public double Montant { get; set; }
        public DateTime Date { get; set; }


        public Reglement()
        {
            this.Date = DateTime.Now;
        }

        public Reglement(int ID_Documents_, int ID_MethodePaiement_, double Montant_, DateTime Date_)
        {
            this.ID_Documents = ID_Documents_;
            this.ID_MethodePaiement = ID_MethodePaiement_;
            this.Montant = Montant_;
            this.Date = Date_;
        }

        public Reglement(int ID_, int ID_Documents_, int ID_MethodePaiement_, double Montant_, DateTime Date_)
        {
            this.ID = ID_;
            this.ID_Documents = ID_Documents_;
            this.ID_MethodePaiement = ID_MethodePaiement_;
            this.Montant = Montant_;
            this.Date = Date_;
        }
    }


}
