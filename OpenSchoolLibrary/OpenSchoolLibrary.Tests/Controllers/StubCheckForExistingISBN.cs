using OpenSchoolLibrary.Domain;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OpenSchoolLibrary.Tests.Controllers
{
    public class StubCheckForExistingISBN: ICheckForExistingISBN
    {

        public async Task<bool> Exists(string isbn, string isbn13) => ExistingIsbns.Contains(isbn) || ExistingIsbn13s.Contains(isbn13);
        public IList<string> ExistingIsbns = new List<string>() {"0198526636"};
        public IList<string> ExistingIsbn13s = new List<string>() {"9783161484100"};



    }
}