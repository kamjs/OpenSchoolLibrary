using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using OpenSchoolLibrary.Controllers;
using OpenSchoolLibrary.Models.BooksViewModels;
using System.Web.Mvc;

namespace OpenSchoolLibrary.Tests.Controllers
{
    public class Return_Error_When_Adding_A_New_Book_With
    {
        [Fact]
        public void Missing_A_Title()
        {
            var book = new AddNewBookPostViewModel()
            { 
                Title = "",
                SubTitle = "Subtitle",
                Author = "Someone",
                ISBN = "1885167776",
                Condition = "Good",
                CatalogID = "Something",
                GenreIDs = new List<int>() {1,2,3 }
            };
            var addNewBook = new AddNewBookController();

            var saveBook = addNewBook.AddNewBook(book) as ViewResult;

            Assert.True(saveBook != null);

        }

        [Fact]
        public void Missing_An_Author()
        {

        }

        [Fact]
        public void Invalid_ISBN_Or_ISBN13()
        {

        }

        [Fact]
        public void An_ISBN_That_Already_Exists_In_The_System()
        {

        }

        [Fact]
        public void An_ISBN13_That_Already_Exists_In_The_System()
        {

        }
    }
}
