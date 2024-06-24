using AuthenticationLoginAndRegistration.Data.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AuthenticationLoginAndRegistration.Data
{
    public class ApplicationDbContext : IdentityDbContext<AppIdentityUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }


        public virtual DbSet<Todo> Todos { get; set; }
    }


}
