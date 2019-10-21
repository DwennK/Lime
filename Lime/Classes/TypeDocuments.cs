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
    [Table("TypeDocuments")]
    class TypeDocuments
    {
        public int ID { get; set; }
        public string Libelle { get; set; }


    }
}
