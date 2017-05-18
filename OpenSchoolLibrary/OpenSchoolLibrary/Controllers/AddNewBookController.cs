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
        readonly BookValidations validateBook;

        public AddNewBookController(IGetGenreList genreList, BookValidations validateBook)
        {
            this.genreList = genreList;
            this.validateBook = validateBook;
        }

        public AddNewBookController() : this( 
            new GetGenreList( new LibraryContext() ),
            new BookValidations( new CheckForExistingIsbnInDb(new LibraryContext()) )
            ) { }

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
        public async Task<ActionResult> AddNewBook(PostAddNewBookViewModel book)
        {
            var model = new AddNewBookViewModel();

            model.Errors = await validateBook.ValidateBook(book);

            return View(model);

        }
    }
}