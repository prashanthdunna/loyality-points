using LoyltyPointa.Dto.tokenResponse;
using Microsoft.AspNetCore.Mvc;

namespace LoyltyPointa.Repo.GravityService
{
    public interface GravityService
    {
        public Task<AuthTokenResponse> GetOrGenerateToken();
    }
}
