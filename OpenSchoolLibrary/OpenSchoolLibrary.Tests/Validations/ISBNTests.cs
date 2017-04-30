using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using OpenSchoolLibrary.Domain.Validations;

namespace OpenSchoolLibrary.Tests.Validations
{
    public class ISBNTests
    {
        [Fact]
        public void Proper_ISBN10_Will_Validate()
        {
            string isbn = "1402894627";

            var sut = ISBNValidation.ValidateISBN10(isbn);

            Assert.True(sut);

        }

        [Fact]
        public void Proper_ISBN10_Using_X_Will_Validate()
        {
            string isbn = "061826941X";

            var sut = ISBNValidation.ValidateISBN10(isbn);

            Assert.True(sut);

        }

        [Fact]
        public void Improper_ISBN10_Will_Fail_To_Validate()
        {
            string isbn = "1402894628";

            var sut = ISBNValidation.ValidateISBN10(isbn);

            Assert.False(sut);

        }

        [Fact]
        public void Improper_ISBN10_Using_X_Will_Fail_To_Validate()
        {
            string isbn = "061826942X";

            var sut = ISBNValidation.ValidateISBN10(isbn);

            Assert.False(sut);

        }

        //[Fact]
        //[InlineData(9781566199094)]
        //[InlineData(9781402894626)]
        //public void ValidISBN13(long isbn13)
        //{

        //}
    }
}
