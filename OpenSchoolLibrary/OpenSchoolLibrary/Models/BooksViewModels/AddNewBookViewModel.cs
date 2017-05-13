using OpenSchoolLibrary.Domain;
using System.Collections.Generic;
using static OpenSchoolLibrary.Controllers.AddNewBookController;

namespace OpenSchoolLibrary.Models.BooksViewModels
{
    public class AddNewBookViewModel
    {
        public string ISBN { get; set; }
        public string ISBN13 { get; set; }
        public List<Genre> Genres { get; set; }
        public List<BookConditions> Conditions { get; set; }
    }
}