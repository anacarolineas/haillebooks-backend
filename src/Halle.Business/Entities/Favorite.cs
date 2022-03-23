using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Halle.Business.Entities
{
    public class Favorite : Entity
    {
        public Guid BookId { get; set; }
        public Guid UserId { get; set; }

        /*EF Relations */
        public Book Book { get; set; }
    }
}
