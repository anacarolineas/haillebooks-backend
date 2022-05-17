using Halle.App.ViewModels;
using Halle.Business.Entities;
using Halle.Business.Interfaces;
using Halle.Data;
using Microsoft.EntityFrameworkCore;

namespace Halle.Business.Services
{
    public class AuthorService : IAuthorService
    {
        private readonly IContext _context;

        public AuthorService(IContext context) => _context = context;

        public async Task<IEnumerable<AuthorViewModel>> GetAuthors() =>
            await _context.Authors.AsNoTracking()
            .Select(x => new AuthorViewModel
            {
                Id = x.Id,
                Name = x.Name
            }).ToListAsync();

        public async Task<AuthorViewModel?> GetAuthorBooksById(Guid authorId) =>
            await _context.Authors.AsNoTracking()
            .Include(x => x.Books)
            .Select(x => new AuthorBookViewModel
            {
                Id = x.Id,
                Name = x.Name,
                Books = x.Books.Select(x => new BookViewModel
                {
                    Id= x.Id,
                    Name = x.Name
                })
            }).FirstOrDefaultAsync();
 

        public Task CreateAuthor(AuthorViewModel author)
        {
            throw new NotImplementedException();
        }
    }
}
