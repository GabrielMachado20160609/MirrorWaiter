using Microsoft.EntityFrameworkCore;
using MirrorWaiter.Domain.Model.PostAggregate;
using MirrorWaiter.Domain.Model.ProfileAggregate;

namespace MirrorWaiter.Infrastructure
{
    public class ConnectionContext: DbContext
    {
        public DbSet<Profile> Profiles { get; set; }
        public DbSet<Post> Posts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseNpgsql(
                "Server=localhost;" +
                "Port=5432;Database=MirrorDb;" +
                "User Id=postgres;" +
                "Password=Gister2019!"
            );
    }
}
