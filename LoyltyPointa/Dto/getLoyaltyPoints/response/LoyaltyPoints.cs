using System.Text.Json.Serialization;

namespace LoyltyPointa.Dto.getLoyaltyPoints.response
{
    public class LoyaltyPoints
    {
        public string Status { get; set; }
        public string? CustomerNumber { get; set; }
        public string? RedeemablePointsValue { get; set; }
        public string? Message { get; set; }
        public RegularPoints? RegularPoints { get; set; }
        public PromoPoints? PromoPoints { get; set; }
        public string? CorrelationID { get; set; }
        public string? error { get; set; }
        public string httpResponseCode { get; set; }

          public LoyaltyPoints() { 

           }
   
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
                CorrelationID = loyaltypoints.CorrelationID;
                error = loyaltypoints.error;
                httpResponseCode = loyaltypoints.httpResponseCode;
            }
        }
  
   }

}

