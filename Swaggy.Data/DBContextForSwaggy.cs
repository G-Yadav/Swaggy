using Microsoft.EntityFrameworkCore;
using Swaggy.Core;

namespace Swaggy.Data
{
    public class DBContextForSwaggy: DbContext
    {
        public DbSet<Restaurant> Restaurants { get; set; }
        public DBContextForSwaggy(DbContextOptions<DBContextForSwaggy> options) : base(options)
        {

        }
    }
}
