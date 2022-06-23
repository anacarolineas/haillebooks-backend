using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Halle.Business.Entities
{
    public class Tag : Entity
    {
        public string Name { get; set; }

        /*EF Relations */
        public IEnumerable<Book> Books { get; set; } = null!;

        public Tag(Guid id, string name)
        {
            Id = id;
            Name = name;
        }

        public Tag(string name)
        {
            Name = name;
        }
    }
}
