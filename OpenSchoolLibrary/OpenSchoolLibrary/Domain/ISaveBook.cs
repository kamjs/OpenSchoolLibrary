using OpenSchoolLibrary.Models.BooksViewModels;
using System.Threading.Tasks;

namespace OpenSchoolLibrary.Domain
{
    public interface ISaveBook
    {
        Task<int> Create(BookCreationCommand cmd);
    }
}