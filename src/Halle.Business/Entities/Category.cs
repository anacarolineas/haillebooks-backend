using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Halle.Business.Entities
{
    public class Category : Entity
    {
        public string Name { get; set; }

        /*EF Relations */
        public IEnumerable<Book> Books { get; set; }
        public IEnumerable<Subcategory> Subcategories { get; set; }
    }
}
