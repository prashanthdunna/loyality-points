using LoyltyPointa.Dto.getLoyaltyPoints.request;
using LoyltyPointa.Dto.getLoyaltyPoints.response;
using LoyltyPointa.Dto.tokenResponse;
using LoyltyPointa.Dto.userdetails;
using Microsoft.AspNetCore.Mvc;

namespace LoyltyPointa.Repo.GravityService
{
    public interface GravityService
    {
        public Task<AuthTokenResponse> GetOrGenerateToken();
        public Task<GetGroupLoyaltyData> GetGroupLoyaltyPoints(LoyaltyRequest request);

    }
}
