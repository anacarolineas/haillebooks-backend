namespace Halle.Business.Entities
{
    public class Favorite : Entity
    {
        public Guid BookId { get; set; }
        public Guid UserId { get; set; }

        /*EF Relations */
        public Book Book { get; set; }
        //public ApplicationUser User { get; set; }
    }
}
