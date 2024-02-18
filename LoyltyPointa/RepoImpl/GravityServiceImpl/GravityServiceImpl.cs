using LoyltyPointa.Dto.tokenResponse;
using LoyltyPointa.Repo.GravityService;
using Newtonsoft.Json;
using Serilog;
using System.Text;

namespace LoyltyPointa.RepoImpl.GravityServiceImpl
{
    public class GravityServiceImpl : GravityService
    {
        private readonly HttpClient _httpClient;

        public GravityServiceImpl(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async  Task<AuthTokenResponse> GetOrGenerateToken()
        {
            string authTokenUrl = "https://shoppersstop.apm20.gravty.io/gis/loyalty/v1.1/token?client_id=PerpuleGravtyUAT@shoppersstop.com&client_secret=DzGmBZO8M";
            Log.Information($"access token url for the gravity is : {authTokenUrl}");
            string jsonPayload = JsonConvert.SerializeObject(new
            {
                client_id = "PerpuleGravtyUAT@shoppersstop.com",
                client_secret = "DzGmBZO8M",
                grant_type = "client_credentials"

            });
             var requestMessage = new HttpRequestMessage(HttpMethod.Post, authTokenUrl);
            requestMessage.Content = new StringContent(jsonPayload, Encoding.UTF8, "application/json");
            requestMessage.Headers.Add("x-api-key", "8oMbDyQ6ksO4nNGaVK1S8ObM2Nka0Ii4AWeRashi");
            requestMessage.Headers.Add("User-Agent", "PostmanRuntime/7.36.3");
            Log.Information($"Headers Information : {requestMessage.Headers}");
            var startTime = DateTime.Now;
            try
            {
                var response = await _httpClient.SendAsync(requestMessage);

                var responseContent = await response.Content.ReadAsStringAsync();
                Log.Information($"Time taken for auth token generation in gravity is  {(DateTime.Now - startTime).TotalMilliseconds}ms");
                var finalResponse = JsonConvert.DeserializeObject<AuthTokenResponse>(responseContent);
                return finalResponse;
            }
            catch (Exception ex)
            {
                Log.Information($"Error while generating access token with gravity : {ex.Message}");
                return new AuthTokenResponse { Error = ex.Message };
            }
        }
    }
}
