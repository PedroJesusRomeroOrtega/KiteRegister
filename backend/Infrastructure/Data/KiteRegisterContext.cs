using KiteRegister.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace KiteRegister.Infrastructure.Data
{
    public class KiteRegisterContext : DbContext
    {
        public KiteRegisterContext(DbContextOptions<KiteRegisterContext> options) : base(options) { }

        public DbSet<KiteBrand> KiteBrands { get; set; }
        public DbSet<KiteModel> KiteModels { get; set; }
        public DbSet<Kite> Kites { get; set; }

    }
}