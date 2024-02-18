namespace LoyltyPointa.Dto.getLoyaltyPoints.request
{
    public class LoyaltyPointsRequest
    {
        public string CorrelationID { get; set; }

        public string BusinessUnit { get; set; }

        public string CustomerNumber { get; set; }

        public string MobileNumber { get; set; }

        public string EmailAddress { get; set; }

        public string PromoFlag { get; set; }
    }
}
