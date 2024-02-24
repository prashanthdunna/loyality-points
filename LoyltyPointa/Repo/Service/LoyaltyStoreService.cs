using LoyltyPointa.Dto.userdetails;

namespace LoyltyPointa.Repo.Service.GravityService
{
    public interface LoyaltyStoreService
    {
        public Task<string> GenerateRandomUUID();
        public Task<UserInfo> GetUserDetailsFromHybris(string authToken);

    }
}
