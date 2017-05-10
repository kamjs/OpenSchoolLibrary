using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using OpenSchoolLibrary.Domain;

namespace OpenSchoolLibrary.Tests.Stubs
{
    class StubGetGenreList : IGetGenreList
    {
        public IQueryable<Genre> GenreList()
        {
            throw new NotImplementedException();
        }
    }
}
