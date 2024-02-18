namespace LoyltyPointa.Models.LoyalityModels
{
    public class LoyaltyPointsData
    {
        public string Status { get; set; }

        public string CustomerNumber { get; set; }

        public string RedeemablePointsValue { get; set; }

        public string Message { get; set; }

        public Data RegularPoints { get; set; }

        public Data PromoPoints { get; set; }
    }
}
