using System;

namespace KiteRegisterApi.Models
{
    public class KiteDto
    {
        public int KiteId { get; set; }
        public int Size { get; set; }
        public int PrincipalColor { get; set; }
        public DateTime PurchaseDate { get; set; }
        public int KiteModelId { get; set; }
    }
}
