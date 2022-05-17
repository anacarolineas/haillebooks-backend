using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Halle.Business.Entities
{
    public class Book : Entity
    {
        public string Name { get; set; }
        public string Description { get; set; }

        /*EF Relations */
        public IEnumerable<Category> Categories { get; set; }
        public IEnumerable<Author> Authors { get; set; }
        public IEnumerable<Tag> Tags { get; set; }
        public IEnumerable<Favorite> Favorites { get; set; }

    }
}
