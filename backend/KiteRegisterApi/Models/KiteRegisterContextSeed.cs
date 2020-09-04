using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KiteRegisterApi.Models
{
    public class KiteRegisterContextSeed
    {
        public static async Task SeedAsync(KiteRegisterContext kiteRegisterContext)
        {
            if (!await kiteRegisterContext.KiteBrands.AnyAsync())
            {
                await kiteRegisterContext.KiteBrands.AddRangeAsync(GetPreconfiguredKiteBrands());
            }
        }

        private static IEnumerable<KiteBrand> GetPreconfiguredKiteBrands()
        {
            return new List<KiteBrand>()
            {
                new KiteBrand("North", "https://www.northkb.com/"),
                new KiteBrand("Cabrinha", "https://www.cabrinha.com/"),
                new KiteBrand("Duotone", "https://www.duotonesports.com/"),
            };
        }
    }
}
