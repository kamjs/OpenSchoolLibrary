using OpenSchoolLibrary.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OpenSchoolLibrary.Tests.Stubs
{
    public class StubCheckForExistingISBN: ICheckForExistingISBN
    {
        public async Task<bool> Exists(string isbn, string isbn13) => ExistingIsbns.Contains(isbn) || ExistingIsbn13s.Contains(isbn13);
        public IList<string> ExistingIsbns = new List<string>();
        public IList<string> ExistingIsbn13s = new List<string>();



    }
}