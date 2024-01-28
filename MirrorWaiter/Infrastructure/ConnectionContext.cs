using Microsoft.EntityFrameworkCore;

namespace MirrorWaiter.Infrastructure
{
    public class ConnectionContext: DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseNpgsql(
                "Server=localhost;" +
                "Port=5432;Database=MirrorDb;" +
                "User Id=postgres;" +
                "Password=Gister2019!"
            );
    }
}
