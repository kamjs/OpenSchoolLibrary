using System.Collections.Generic;

namespace OpenSchoolLibrary.Models.BooksViewModels
{
    public class AddNewBookPostViewModel
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string SubTitle { get; set; }
        public string Author { get; set; }
        public string ISBN { get; set; }
        public string ISBN13 { get; set; }
        public string Condition { get; set; }
        public string CatalogID { get; set; }
        public List<int> GenreIDs { get; set; }
    }
}