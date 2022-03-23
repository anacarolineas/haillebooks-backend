using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Halle.Business.Entities
{
    public class Subcategory : Entity
    {
        public string Name { get; set; }
        public Guid CategoryId { get; set; }

        /* EF Relations */
        public Category Category { get; set; }
    }
}
