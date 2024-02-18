namespace LoyltyPointa.Dto.getLoyaltyPoints.response
{
    public class LoyaltyPoints
    {
        public string Status { get; set; }

        public string CustomerNumber { get; set; }

        public string RedeemablePointsValue { get; set; } = "undefined";

        public string Message { get; set; } = "undefined";

        public Data RegularPoints { get; set; }

        public Data PromoPoints { get; set; }

        public string ErrorMsg { get; set; } = "undefined";

        public LoyaltyPoints() { }

        public LoyaltyPoints(LoyaltyPoints loyaltypoints)
        {
            if (loyaltypoints != null)
            {
                Status = loyaltypoints.Status;
                CustomerNumber = loyaltypoints.CustomerNumber;
                RedeemablePointsValue = loyaltypoints.RedeemablePointsValue;
                Message = loyaltypoints.Message;
                RegularPoints = loyaltypoints.RegularPoints;
                PromoPoints = loyaltypoints.PromoPoints;
                ErrorMsg = loyaltypoints.ErrorMsg;
            }
        }
    }

}

