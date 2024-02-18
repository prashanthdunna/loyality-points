namespace LoyltyPointa.Models.LoyalityModels
{
    public class GetGroupLoyaltyPoints
    {
        public LoyaltyPointsData GetGroupLoyalityPointsResponse {get; set;}

        public string ErrorMsg { get; set;}

        public SSLLoyaltyDetails SSLLoyaltyDetails { get; set;}
    }
}
