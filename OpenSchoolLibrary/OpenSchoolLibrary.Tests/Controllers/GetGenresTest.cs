using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using OpenSchoolLibrary.Controllers;
using OpenSchoolLibrary.Tests.Stubs;

namespace OpenSchoolLibrary.Tests.Controllers
{
    public class GetGenresTest
    {
        [Fact]
        public async Task A_Valid_List_Of_Genres_Is_Returned()
        {
            var stubGenre = new StubGetGenreList();

                
        }
    }
}
