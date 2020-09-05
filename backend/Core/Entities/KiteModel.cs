using System.Collections.Generic;

namespace KiteRegister.Core.Entities
{
    public class KiteModel: BaseEntity
    {
        public string Name { get; private set; }
        public string Url { get; private set; }
        public int? YearProduction { get; private set; }

        public int KiteBrandId { get; private set; }
        public KiteBrand KiteBrand { get; private set; }

        public List<Kite> Kites { get; private set; }

        public KiteModel(string name, string url, int? yearProduction, int kiteBrandId)
        {
            Name = name;
            Url = url;
            YearProduction = yearProduction;
            KiteBrandId = kiteBrandId;
        }
    }
}
