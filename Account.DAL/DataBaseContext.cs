using Account.Domain;
using Microsoft.EntityFrameworkCore;

namespace Account.DAL
{
    public class DataBaseContext : DbContext
    {
        public DataBaseContext(DbContextOptions<DataBaseContext> options)
            : base(options)
        {
        }

        public DbSet<AccountDTO> Accounts { get; set; }
    }
}
