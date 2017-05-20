using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using OpenSchoolLibrary.Controllers;
using System.Web.Mvc;
using OpenSchoolLibrary.Tests.Stubs;

namespace OpenSchoolLibrary.Tests.Controllers
{
    public class Add_Book_ISBN_LookUp
    {
        StubCheckForExistingISBN stubCheck = new StubCheckForExistingISBN();
        private string isbnThatExistsAlready = "0198526636";
        private string isbn13ThatExistsAlready = "9780671027032";

        public Add_Book_ISBN_LookUp()
        {
            stubCheck.ExistingIsbns.Add(isbnThatExistsAlready);
            stubCheck.ExistingIsbn13s.Add(isbn13ThatExistsAlready);
        }

        [Fact]
        public async Task When_an_isbn10_is_entered_the_user_is_redirected_to_a_valid_page()
        {
            //Arrange
            await stubCheck.Exists(isbnThatExistsAlready, "");

            var redirect = new RedirectAddBookController(stubCheck);

            //Act
            var redirectResult = await redirect.Add(isbnThatExistsAlready, "");

            Assert.True(redirectResult.Url != null);
        }

        [Fact]
        public async Task When_an_isbn13_is_entered_the_user_is_redirected_to_a_valid_page()
        {
            //Arrange
            await stubCheck.Exists("", isbn13ThatExistsAlready);

            var redirect = new RedirectAddBookController(stubCheck);

            //Act
            var redirectResult = await redirect.Add("", isbn13ThatExistsAlready);

            Assert.True(redirectResult.Url != null);
        }


        [Fact]
        public async Task When_an_isbn10_number_exists_in_the_system_a_new_book_should_be_added_but_not_a_new_title()
        {
            //Arrange
            await stubCheck.Exists(isbnThatExistsAlready, "");

            var redirect = new RedirectAddBookController(stubCheck);

            //Act
            var redirectResult = await redirect.Add(isbnThatExistsAlready, "");

            Assert.Equal("/Books/IncrementBook/?isbn=0198526636&isbn13=", redirectResult.Url);
        }

        [Fact]
        public async Task When_an_isbn13_number_exists_in_the_system_a_new_book_should_be_added_but_not_a_new_title()
        {
            //Arrange
            await stubCheck.Exists("", isbn13ThatExistsAlready);

            var redirect = new RedirectAddBookController(stubCheck);

            //Act
            var redirectResult = await redirect.Add("", isbn13ThatExistsAlready);

            Assert.Equal("/Books/IncrementBook/?isbn=&isbn13=9780671027032", redirectResult.Url);
        }

        [Fact]
        public async Task When_an_isbn10_number_does_not_exists_in_the_system_a_new_book_and_title_should_be_added()
        {
            //Arrange
            await stubCheck.Exists("0198526637", "");

            var redirect = new RedirectAddBookController(stubCheck);

            //Act
            var redirectResult = await redirect.Add("0198526637", "");

            Assert.Equal("/Books/AddNewBook/?isbn=0198526637&isbn13=", redirectResult.Url);
        }

        [Fact]
        public async Task When_an_isbn13_number_does_not_exists_in_the_system_a_new_book_and_title_should_be_added()
        {
            //Arrange
            var stubCheck = new StubCheckForExistingISBN();
            await stubCheck.Exists("", "9783161484101");

            var redirect = new RedirectAddBookController(stubCheck);

            //Act
            var redirectResult = await redirect.Add("", "9783161484101");

            Assert.Equal("/Books/AddNewBook/?isbn=&isbn13=9783161484101", redirectResult.Url);
        }
    }
}
