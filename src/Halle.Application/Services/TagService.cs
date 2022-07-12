using Halle.Application.Interfaces;
using Halle.Application.ViewModels.Tag;
using Halle.Business.Entities;
using Halle.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Halle.Application.Services
{
    public class TagService : BaseService, ITagService
    {
        private readonly IContext _context;

        public TagService(IContext context, INotification notification) : base(notification) =>
            _context = context;

        public async Task<TagViewModel?> GetTag(Guid tagId) =>
            await _context.Tags.AsNoTracking().Select(x => 
                new TagViewModel 
                { 
                    Id = x.Id,
                    Name = x.Name 
                }).FirstOrDefaultAsync(x => x.Id == tagId);

        public async Task<IEnumerable<TagViewModel>> SearchTag(string tagName) =>
                await _context.Tags.AsNoTracking()
                .Where(x => x.Name.Contains(tagName))
                .Select(x => new TagViewModel
                {
                    Id = x.Id,
                    Name = x.Name,
                }).ToListAsync();

        public async Task CreateTag(TagViewModel tag)
        {
            var tagExist = await _context.Tags.AsNoTracking()
                .AnyAsync(x => x.Name == tag.Name);

            if (tagExist) throw new Exception("Tag já existente."); //rever

            await _context.Tags.AddAsync(new Tag(tag.Name));
            await _context.SaveChangesAsync();
        }

        public async Task UpdateTag(Guid tagId, string tagName)
        {
            var tag = await TagExist(tagId);

            tag.Name = tagName;
            var tagModel = new Tag(tag.Id, tag.Name);

            _context.Tags.Update(tagModel);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteTag(Guid tagId)
        {
            var tag = await TagExist(tagId);

            _context.Tags.Remove(new Tag(tag.Id, tag.Name));
            await _context.SaveChangesAsync();
        }

        private async Task<TagViewModel?> GetTagById(Guid tagId) =>
            await _context.Tags.Select(x => 
                new TagViewModel { 
                    Id = x.Id,
                    Name = x.Name}
                ).FirstOrDefaultAsync(x => x.Id == tagId);

        private async Task<TagViewModel> TagExist(Guid tagId)
        {
            var tag = await GetTagById(tagId);

            if (tag == null) throw new Exception("Tag não encontrada."); //rever

            return tag;
        }
    
    }
}
