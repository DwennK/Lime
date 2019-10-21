using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Dapper.Contrib;
using Dapper.Contrib.Extensions;

namespace Lime
{
    //Spécifie le nom de la table à Utiliser pour Dapper Contrib (Obligatoire)
    [Table("Articles")]
    public class Article
    {
        public int ID { get; set; }
        public int ID_CodeArticles { get; set; }
        public int ID_Marques { get; set; }
        public int ID_Categories { get; set; }
        public string Libelle { get; set; }
        public double Prixvente { get; set; }
        public double PrixAchat { get; set; }
        public bool GererStock { get; set; }
        public int QuantiteStock { get; set; }
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
