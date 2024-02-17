using ECoding_MVC_app.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace ECoding_MVC_app.DatabaseContext
{
    public class AppDbContext : DbContext, IAppDbContext
    {

        public DbSet<Contact> Contacts { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> dbContextOptions)
            : base(dbContextOptions)
        {

        }

        public DbSet<TEntity> Set<TEntity>() where TEntity : class => base.Set<TEntity>();
        public Task<int> SaveChangesAsync() => base.SaveChangesAsync();
    }
}
