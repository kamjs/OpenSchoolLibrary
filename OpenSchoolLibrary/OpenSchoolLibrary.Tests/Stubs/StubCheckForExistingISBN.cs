﻿using OpenSchoolLibrary.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OpenSchoolLibrary.Tests.Stubs
{
    public class StubCheckForExistingISBN: ICheckForExistingISBN
    {

        public async Task<bool> Exists(string isbn, string isbn13) => ExistingIsbns.Contains(isbn) || ExistingIsbn13s.Contains(isbn13);
        private IList<string> ExistingIsbns = new List<string>() {"0198526636"};
        private IList<string> ExistingIsbn13s = new List<string>() {"9783161484100"};



    }
}