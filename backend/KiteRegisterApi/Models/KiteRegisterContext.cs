using Microsoft.EntityFrameworkCore;

namespace KiteRegisterApi.Models {
    public class KiteRegisterContext : DbContext {
        public KiteRegisterContext (DbContextOptions<KiteRegisterContext> options) : base (options) { }

        public DbSet<Kite> Kites { get; set; }
    }
}