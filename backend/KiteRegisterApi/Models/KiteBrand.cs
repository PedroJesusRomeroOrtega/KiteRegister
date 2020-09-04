using System.Collections.Generic;

namespace KiteRegisterApi.Models
{
    public class KiteBrand
    {
        public int KiteBrandId { get; set; }
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
