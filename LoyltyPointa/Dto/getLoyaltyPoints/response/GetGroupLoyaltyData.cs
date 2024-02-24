using LoyltyPointa.Models.LoyalityModels;
using System.Text.Json.Serialization;

namespace LoyltyPointa.Dto.getLoyaltyPoints.response
{
    public class GetGroupLoyaltyData
    {
        public LoyaltyPoints GetGroupLoyaltyPointsResponse {  get; set; }

      // public LoyaltyExample loyaltyData {  get; set; }

     
        public string ErrorMsg { get; set; }

          public GetGroupLoyaltyData()
          {
          }

        
        public GetGroupLoyaltyData(GetGroupLoyaltyData data)
        {
            if (data != null)
            {
                this.GetGroupLoyaltyPointsResponse = data.GetGroupLoyaltyPointsResponse;
                this.ErrorMsg = data.ErrorMsg;
            }

        }
  }
}
