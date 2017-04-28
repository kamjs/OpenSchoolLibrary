using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OpenSchoolLibrary.Domain
{
    public class Book
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string SubTitle { get; set; }
        public string Author { get; set; }
        public string ISBN { get; set; }
        public long ISBN13 { get; set; }
        public int Condition { get; set; }
        public string CatalogID { get; set; }
        public int Genre { get; set; }
    }
}