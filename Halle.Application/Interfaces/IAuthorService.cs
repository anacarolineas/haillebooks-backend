using Halle.App.ViewModels;
using Halle.Business.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Halle.Business.Interfaces
{
    public interface IAuthorService
    {
        Task<IEnumerable<AuthorViewModel>> GetAuthors();
        Task<AuthorViewModel?> GetAuthorBooksById(Guid authorId);
        Task CreateAuthor(AuthorViewModel author);
    }
}
