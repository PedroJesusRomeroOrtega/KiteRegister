using System;

namespace KiteRegister.Core.Entities
{
    public class Kite:BaseEntity
    {
        public int Size { get; private set; }
        public int PrincipalColor { get; private set; }
        public DateTime PurchaseDate { get; private set; }

        public int KiteModelId { get; private set; }
        public KiteModel KiteModel { get; private set; }

        public Kite(int size, int principalColor, DateTime purchaseDate, int kiteModelId)
        {
            Size = size;
            PrincipalColor = principalColor;
            PurchaseDate = purchaseDate;
            KiteModelId = kiteModelId;
        }

        public void UpdateDetails(int size, int principalColor, DateTime purchaseDate)
        {
            Size = size;
            PrincipalColor = principalColor;
            PurchaseDate = purchaseDate;
        }

        public void UpdateKiteModel(int kiteModelId)
        {
            KiteModelId = kiteModelId;
        }
    }
}