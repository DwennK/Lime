﻿using System;
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
    [Table("Articles")]
    public class Article
    {
        
        public int ID { get; set; }
        [Display(Name = "Code Article")]
        public int ID_CodeArticles { get; set; }
        public int ID_Marques { get; set; }
        public int ID_Categories { get; set; }
        [Display(Name = "Libellé")]
        public string Libelle { get; set; }
        [Display(Name = "Prix de vente")]
        public double Prixvente { get; set; }
        [Display(Name = "Prix d'achat")]
        public double PrixAchat { get; set; }
        [Display(Name = "Gérer le stock ?")]
        public bool GererStock { get; set; }
        [Display(Name = "Quantité en stock")]
        public int QuantiteStock { get; set; }
        [Display(Name = "Seuil d'alerte stock")]
        public int SeuilAlerte { get; set; }


        public static IEnumerable<Article> GetAllArticles()
        {
            if (Connexion.CheckForInternetConnection())
            {
                IEnumerable<Article> Articles = Connexion.maBDD.Query<Article>("" +
                "SELECT * " +
                "FROM Articles " +
                "LIMIT @Limit " +
                ";"
                , new
                {
                    Limit = Properties.Settings.Default.Limite
                });
                return Articles;
            }
            else
            {
                //Retourne vide
                return Enumerable.Empty<Article>();
            }
        }
    }
}
