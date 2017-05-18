using OpenSchoolLibrary.Domain;
using System.Collections.Generic;
using static OpenSchoolLibrary.Controllers.AddNewBookController;

namespace OpenSchoolLibrary.Models.BooksViewModels
{
    public class AddNewBookViewModel
    {
        public string ISBN { get; set; }
        public string ISBN13 { get; set; }
        public IEnumerable<string> Errors { get; set; } = new List<string>();
        public IEnumerable<Genre> Genres { get; set; }
        public IEnumerable<BookConditions> Conditions { get; set; }
    }
}