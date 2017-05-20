using System.Collections.Generic;

namespace OpenSchoolLibrary.Domain
{
    public class Book
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Subtitle { get; set; }
        public string Author { get; set; }
        public string ISBN { get; set; }
        public string ISBN13 { get; set; }
        public string Condition { get; set; }
        public string CatalogID { get; set; }
        public List<int> GenreIDs { get; set; }
    }
}