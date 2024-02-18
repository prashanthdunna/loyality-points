using LoyltyPointa.Models.LoyalityModels;

namespace LoyltyPointa.Dto.getLoyaltyPoints.response
{
    public class GetGroupLoyaltyPointsResponse
    {
        public LoyaltyPointsData GetGroupLoyaltyPointsResponseData {  get; set; }

        public SSLLoyaltyDetails SslLoyaltyDetails { get; set; }

        public string ErrorMsg { get; set; }

        public GetGroupLoyaltyPointsResponse()
        {
            
        }

        public GetGroupLoyaltyPointsResponse(GetGroupLoyaltyPointsResponse data)
        {
            if (data != null)
            {
                this.GetGroupLoyaltyPointsResponseData = data.GetGroupLoyaltyPointsResponseData;
                this.SslLoyaltyDetails = data.SslLoyaltyDetails;
                this.ErrorMsg = data.ErrorMsg;
            }
            
        }
    }
}
