using Halle.Application.ViewModels.Tag;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Halle.Application.Interfaces
{
    public interface ITagService
    {
        Task<TagViewModel?> GetTag(Guid tagId);
        Task<IEnumerable<TagViewModel>> SearchTag(string tagName);
        Task CreateTag(TagViewModel tag);
        Task UpdateTag(Guid tagId, string tagName);
        Task DeleteTag(Guid tagId);
    }
}
