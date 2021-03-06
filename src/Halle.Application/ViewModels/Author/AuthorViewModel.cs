namespace Halle.App.ViewModels
{
    public class AuthorViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
    }

    public class AuthorBookViewModel : AuthorViewModel
    {
        public IEnumerable<BookViewModel> Books { get; set; } = null!;
    }
}
