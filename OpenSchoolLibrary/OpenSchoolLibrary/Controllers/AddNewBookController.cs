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
        readonly ISaveBook saveBook;
        readonly BookValidations validateBook;

        public AddNewBookController(IGetGenreList genreList, BookValidations validateBook, ISaveBook saveBook)
        {
            this.genreList = genreList;
            this.validateBook = validateBook;
            this.saveBook = saveBook;
        }

        public AddNewBookController() : this( 
            new GetGenreList( new LibraryContext() ),
            new BookValidations( new CheckForExistingIsbnInDb(new LibraryContext())),
            new SaveBook( new LibraryContext() )
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
        public async Task<ActionResult> AddNewBook(BookCreationCommand book)
        {
            var model = new AddNewBookViewModel()
            {
                Errors = await validateBook.ValidateBook(book),
                Genres = await genreList.GenreList().ToListAsync(),
                Conditions = Enum.GetValues(typeof(BookConditions)).OfType<BookConditions>().ToList(),
                ISBN = book.ISBN,
                ISBN13 = book.ISBN13
            };                

            if (model.Errors.Any())
            {
                return View("~/Views/Books/AddNewBook.cshtml", model);
            }
            else
            {
                var bookId = await saveBook.Create(book);

                return Redirect($"/book/details/{bookId}");
            }
            

        }
    }
}