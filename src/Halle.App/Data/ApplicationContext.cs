using Halle.App.Data.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Halle.App.Data
{
    public class ApplicationContext : IdentityDbContext<ApplicationUser, Role, Guid>
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) { }
    }
}
