using OpenSchoolLibrary.Controllers;
using OpenSchoolLibrary.Models.BooksViewModels;
using OpenSchoolLibrary.Domain;
using OpenSchoolLibrary.Tests.Stubs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Xunit;

namespace OpenSchoolLibrary.Tests.Controllers
{
    public class When_adding_a_new_book
    {
        private StubBookSaver stubBookSaver;
        private AddNewBookController addNewBookController;

        public When_adding_a_new_book()
        {
            stubBookSaver = new StubBookSaver();
            addNewBookController = new AddNewBookController(new StubGenreList(), new Domain.Validations.BookValidations(new StubCheckForExistingISBN()), stubBookSaver);
        }

        BookCreationCommand book = new BookCreationCommand()
        {
            Title = "A Title",
            SubTitle = "Subtitle",
            Author = "Someone",
            ISBN = "0198526636",
            ISBN13 = "9780141042138",
            Condition = "Good",
            CatalogID = "Something",
            GenreIDs = new List<int>() { 1, 2, 3 }
        };


        [Fact]
        public async Task save_new_book_entity()
        {
            RedirectResult saveBook = await AddNewBook(book);
  
            Assert.Equal(1, stubBookSaver.TimesCalled);

        }

        [Fact]
        public async Task redirect_to_book_details_after_saving()
        {
            RedirectResult saveBook = await AddNewBook(book);

            Assert.Equal("/book/details/1", saveBook.Url);
        }
        
        private async Task<RedirectResult> AddNewBook(BookCreationCommand book)
        {
            return await addNewBookController.AddNewBook(book) as RedirectResult;
        }
    }
}
