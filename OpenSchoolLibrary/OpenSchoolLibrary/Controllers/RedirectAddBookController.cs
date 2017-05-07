using OpenSchoolLibrary.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace OpenSchoolLibrary.Controllers
{
    public class RedirectAddBookController : Controller
    {
        readonly ICheckForExistingISBN checkForIsbn;
        public RedirectAddBookController(ICheckForExistingISBN checkForIsbn)
        {
            this.checkForIsbn = checkForIsbn;
        }

        public RedirectAddBookController() : this( new CheckForExistingIsbnInDb( new LibraryContext() ) ) { }





        // POST: Books/Add
        [HttpPost, Route("books/add")]
        [ValidateAntiForgeryToken]
        public async Task<RedirectResult> Add(string isbn, string isbn13)
        {

            if (await checkForIsbn.Exists(isbn, isbn13))
            {
                return Redirect($@"/Books/IncrementBook/?isbn={HttpUtility.UrlEncode(isbn)}&isbn13={HttpUtility.UrlEncode(isbn13)}");
            }
            else
            {
                return Redirect($@"/Books/AddNewBook/?isbn={HttpUtility.UrlEncode(isbn)}&isbn13={HttpUtility.UrlEncode(isbn13)}");
            }
        }
    }
}