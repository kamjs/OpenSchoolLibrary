using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace OpenSchoolLibrary.Tests.Controllers
{
    class BooksControllerTests
    {
        [Theory]
        [InlineData(1566199093)]
        [InlineData(1402894627)]
        public void ValidISBN(string isbn)
        {

        }

        [Theory]
        [InlineData(9781566199094)]
        [InlineData(9781402894626)]
        public void ValidISBN13(long isbn13)
        {

        }
    }
}
