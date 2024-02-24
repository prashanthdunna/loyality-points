using LoyltyPointa.Dto.getLoyaltyPoints.request;
using LoyltyPointa.Dto.getLoyaltyPoints.response;
using LoyltyPointa.Dto.userdetails;
using LoyltyPointa.Models.LoyalityModels;
using LoyltyPointa.Repo.GravityService;
using LoyltyPointa.Repo.Service.GravityService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace LoyltyPointa.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class LoyaltyController : ControllerBase
    {
        private readonly GravityService _gravityService;
        private readonly LoyaltyStoreService _storeService;

        public LoyaltyController(GravityService gravityService,LoyaltyStoreService storeService)
        {
            _gravityService = gravityService;
            _storeService = storeService; 
        }
        [HttpPost]
        public async Task<ActionResult> GenerateToken()
        {
            var tokenData = await _gravityService.GetOrGenerateToken();
            return Ok(tokenData);
        }

        [HttpPost]
        [Route("getGroupLoyaltyPoints")]
        public async Task<ActionResult<GetGroupLoyaltyPoints>> GetGroupLoyaltyPoints([FromBody] LoyaltyRequest requst)
        {
          
            //string bearerToken = Request.Headers["Authorization"].ToString().Replace("Bearer","");
            //UserInfo hybrisUser = await _storeService.GetUserDetailsFromHybris(bearerToken);
            var response = await _gravityService.GetGroupLoyaltyPoints(requst);
            var groupLoyaltyPoints = new GetGroupLoyaltyData
            {

                ErrorMsg = response.ErrorMsg,
                GetGroupLoyaltyPointsResponse = new LoyaltyPoints
                {
                    Status = response.GetGroupLoyaltyPointsResponse.Status,
                    CustomerNumber = response.GetGroupLoyaltyPointsResponse.CustomerNumber,
                    RedeemablePointsValue = response.GetGroupLoyaltyPointsResponse.RedeemablePointsValue,
                    RegularPoints = response.GetGroupLoyaltyPointsResponse.RegularPoints != null && response.GetGroupLoyaltyPointsResponse.RegularPoints.Data != null
            ? new Dto.getLoyaltyPoints.response.RegularPoints
            {
                        Data = response.GetGroupLoyaltyPointsResponse.RegularPoints.Data,
                    }:null

            ,
                    Message = response.GetGroupLoyaltyPointsResponse.Message,
                    PromoPoints = response.GetGroupLoyaltyPointsResponse.PromoPoints != null && response.GetGroupLoyaltyPointsResponse.PromoPoints.Data != null
            ? new Dto.getLoyaltyPoints.response.PromoPoints
            {
                Data = response.GetGroupLoyaltyPointsResponse.PromoPoints.Data
            }
            : null
                }
                
            };


            return Ok(groupLoyaltyPoints);
        }
    }
}
