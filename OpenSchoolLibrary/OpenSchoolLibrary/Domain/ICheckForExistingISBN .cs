using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenSchoolLibrary.Domain
{
    public interface ICheckForExistingISBN
    {
        Task<bool> Exists(string isbn, string isbn13);
    }
}
