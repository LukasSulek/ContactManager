using ECoding_MVC_app.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace ECoding_MVC_app.DatabaseContext
{
    public interface IAppDbContext
    {
        DbSet<Contact> Contacts { get; set; }
        DbSet<TEntity> Set<TEntity>() where TEntity : class;
        Task<int> SaveChangesAsync();
    }
}
