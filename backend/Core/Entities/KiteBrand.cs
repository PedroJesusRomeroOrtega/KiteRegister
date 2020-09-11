using System.Collections.Generic;

namespace KiteRegister.Core.Entities
{
    public class KiteBrand : BaseEntity
    {
        public string Name { get; set; }
        public string Url { get; set; }

        public List<KiteModel> KiteModels { get; set; }

        public KiteBrand(string name, string url = null)
        {
            Name = name;
            Url = url;
        }
    }
}
