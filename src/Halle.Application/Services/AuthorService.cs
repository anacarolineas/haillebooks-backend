using Halle.App.ViewModels;
using Halle.Application.Interfaces;
using Halle.Application.Services;
using Halle.Application.Validations;
using Halle.Business.Entities;
using Halle.Business.Interfaces;
using Halle.Data;
using Microsoft.EntityFrameworkCore;

namespace Halle.Business.Services
{
    public class AuthorService : BaseService, IAuthorService
    {
        private readonly IContext _context;

        public AuthorService(
            IContext context,
            INotification notification) : base(notification)
        {
            _context = context;
        }

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
            .Where(x => x.Id == authorId)
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
 

        public async Task<bool> CreateAuthor(AuthorViewModel authorVm)
        {
            if (!ValidateModel(new AuthorValidation(), authorVm)) return false;

            var authorExit = await AuthorExist(authorVm.Name);
            if (authorExit) throw new Exception("Author já existente."); //rever depois, criar exception específica

            await _context.Authors.AddAsync(new Author(authorVm.Name));
            await _context.SaveChangesAsync();

            return true;
        }

        private async Task<bool> AuthorExist(string name) =>
            await _context.Authors.AsNoTracking()
            .AnyAsync(x => x.Name == name);

       
    }
}
