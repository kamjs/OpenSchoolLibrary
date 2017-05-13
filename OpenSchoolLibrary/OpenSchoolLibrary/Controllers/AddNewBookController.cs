using OpenSchoolLibrary.Domain;
using OpenSchoolLibrary.Models.BooksViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using OpenSchoolLibrary.Domain.Validations;

namespace OpenSchoolLibrary.Controllers
{
    public class AddNewBookController: Controller
    {
        readonly IGetGenreList genreList;
        public AddNewBookController(IGetGenreList genreList)
        {
            this.genreList = genreList;
        }

        public AddNewBookController() : this( new GetGenreList( new LibraryContext() ) ) { }

        public enum BookConditions
        {
            Excellent,
            Good,
            Fair,
            Used,
            Bad
        }

        [HttpGet, Route("books/addnewbook")]
        public async Task<ViewResult> AddNewBook(string isbn, string isbn13)
        {

            var model = new AddNewBookViewModel()
            {

                Genres = await genreList.GenreList().ToListAsync(),
                Conditions = Enum.GetValues(typeof(BookConditions)).OfType<BookConditions>().ToList(),
                ISBN = isbn,
                ISBN13 = isbn13
            };

            return View("~/Views/Books/AddNewBook.cshtml", model);
        }

        [HttpPost, Route("books/addnewbook")]
        [ValidateAntiForgeryToken]
        public ActionResult AddNewBook(AddNewBookPostViewModel book)
        {
            string errorMessage = String.Empty;
            var bookValidation = new BookValidations();

            if(bookValidation.ValidateBook(book).ToString() == "")
            {
                /* TODO: Create a method to find out the book's
                 * ID so we can redirect the user to that page.
                 */
                return Redirect($"~/Views/Books/Details.cshtml");
            }
            else
            {
                //TODO: Add in error message and book...somehow.
                return View("~/Views/Books/AddNewBook.cshtml");
            }
        }
    }
}