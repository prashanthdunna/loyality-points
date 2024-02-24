using LoyltyPointa.Dto.userdetails;
using LoyltyPointa.Repo.GravityService;
using LoyltyPointa.Repo.Service.GravityService;
using Microsoft.AspNetCore.WebUtilities;
using Newtonsoft.Json;
using Serilog;

namespace LoyltyPointa.RepoImpl.ServiceImpl.GravityServiceImpl
{
    public class LoyaltyStoreServiceImpl : LoyaltyStoreService
    {
        private readonly HttpClient _httpClient;

        public LoyaltyStoreServiceImpl(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<string> GenerateRandomUUID()
        {
            return Guid.NewGuid().ToString();

        }

        public async Task<UserInfo> GetUserDetailsFromHybris(string authToken)
        {
            string userprofile = "https://uat4.shopper-stop.in/services/v2_1/ssl/users/current";
            Log.Information($"hybris getUser Service URL :{userprofile}");
            _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", authToken);

            var queryParameters = new Dictionary<string, string>
            {
                { "client_id" , "mobile_android" },
                { "client_secret" , "e6Xg$kMt" },
                { "grant_type" , "password"},
                {"password","password" },
                {"username","login" }
            };
            var fullUrl = QueryHelpers.AddQueryString(userprofile, queryParameters);
            Log.Information($"Full Url Information : {fullUrl}");

            Log.Information($"Authorization :{_httpClient.DefaultRequestHeaders.Authorization}");
            long startTime = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
            try
            {
                HttpResponseMessage response = await _httpClient.GetAsync(fullUrl);
                Log.Information("Response code :{ response.EnsureSuccessStatusCode()}");
                response.EnsureSuccessStatusCode();

                string responseBody = await response.Content.ReadAsStringAsync();
                Log.Information($"Time taken for fetching user information from hybris with uid:{"current"} and authToken:{authToken} is {DateTimeOffset.UtcNow.ToUnixTimeMilliseconds() - startTime}");
                return JsonConvert.DeserializeObject<UserInfo>(responseBody);
            }
            catch (Exception ex)
            {
                Log.Information($"The error in getting user details from hybris: {ex.Message}");
                return new UserInfo { errorMsg = ex.Message };

            }


        }
    }
}
