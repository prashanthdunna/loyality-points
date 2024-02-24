using LoyltyPointa.Constants;
using LoyltyPointa.Dto.getLoyaltyPoints.request;
using LoyltyPointa.Dto.getLoyaltyPoints.response;
using LoyltyPointa.Dto.tokenResponse;
using LoyltyPointa.Dto.userdetails;
using LoyltyPointa.Models.LoyalityModels;
using LoyltyPointa.Repo.GravityService;
using LoyltyPointa.Repo.Service.GravityService;
using Microsoft.AspNetCore.WebUtilities;
using Newtonsoft.Json;
using Serilog;
using System.Text;

namespace LoyltyPointa.RepoImpl.ServiceImpl.GravityServiceImpl
{
    public class GravityServiceImpl : GravityService
    {
        private readonly HttpClient _httpClient;
        private readonly LoyaltyStoreService _loyaltyStoreService;

        public GravityServiceImpl(HttpClient httpClient, LoyaltyStoreService loyaltyStoreService)
        {
            _httpClient = httpClient;
            _loyaltyStoreService = loyaltyStoreService;
        }



        public async Task<GetGroupLoyaltyData> GetGroupLoyaltyPoints(LoyaltyRequest request)
        {
            Log.Information($"Request recieved to getGroupLoyaltyPoints with input :{JsonConvert.SerializeObject(request)}");
            var concreteRequest = await PrepareGroupLoyaltyPointsRequest(request);
            var getLoyaltyPointsUrl = $"{Constants.ConstantData.GRAVTY_HOST_V1_1_API}"+$"{Constants.ConstantData.GRAVTY_URI_GET_POINTS}";
            if (string.IsNullOrWhiteSpace(getLoyaltyPointsUrl))
            {
                throw new Exception("No Url/endpoint configured for getGroupLoyaltyPoints service from gravity...");
            }
            var accessToken = (await GetOrGenerateToken()).Access_Token;
             if (string.IsNullOrWhiteSpace(accessToken))
             {
                 throw new Exception("Invalid access-token generated from gravity.");
             }
            /*var queryParameters = new Dictionary<string, string>()
            {
                {"client_id","PerpuleGravtyUAT@shoppersstop.com" },
                {"client_secret","DzGmBZO8M" },

            };*/
            var requestMessage = new HttpRequestMessage(HttpMethod.Post, getLoyaltyPointsUrl);
            //requestMessage.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Authorization", bearer);
            requestMessage.Headers.Add("Authorization", $"JWT {accessToken}");
            requestMessage.Headers.Add("x-api-key", $"{Constants.ConstantData.GRAVTY_AUTH_TOKEN_X_API_KEY}");
            requestMessage.Headers.Add("User-Agent", $"{Constants.ConstantData.GRAVTT_USER_AGENT}");
            var json = JsonConvert.SerializeObject(concreteRequest);
            var content = new StringContent(json,Encoding.UTF8,"application/json");
            Log.Information($"Content Information : {content.ToString}");
            requestMessage.Content = content;
            Log.Information($"RequestMessage.Content Data : {requestMessage.Content}");
            var startTime = DateTime.Now;
            try
            {
                var response = await _httpClient.SendAsync(requestMessage);
                Log.Information($"Response data : {response}");
                response.EnsureSuccessStatusCode();
                Log.Information($"Response data: {response.StatusCode}");
                string responseContent = await response.Content.ReadAsStringAsync();
                Log.Information($"Responsecontent: {responseContent}");

                var getPointResponse = JsonConvert.DeserializeObject<GetGroupLoyaltyData>(responseContent);
                /*var getPointResponse = new GetGroupLoyaltyPointsResponse
                {
                    GetGroupLoyaltyPointsResponseData = JsonConvert.DeserializeObject<LoyaltyPoints>(responseContent),

                };*/
                var result = new GetGroupLoyaltyData(getPointResponse);

                /* if(hybrisUser != null  && hybrisUser.sslLoyaltyDetailData != null)
                 {
                     result.SslLoyaltyDetails = new SSLLoyaltyDetails
                     {
                         barcodeImage = hybrisUser.sslLoyaltyDetailData.barcodeImage,
                         cardDesc = hybrisUser.sslLoyaltyDetailData.cardDesc,
                         cardValidDate = hybrisUser.sslLoyaltyDetailData.cardValidDate,
                         dateOfLastLinkingAttempt = hybrisUser.sslLoyaltyDetailData.dateOfLastLinkingAttempt,
                         isLinked = hybrisUser.sslLoyaltyDetailData.isLinked,
                         isLocked = hybrisUser.sslLoyaltyDetailData.isLocked,
                         isTermsAccepted = hybrisUser.sslLoyaltyDetailData.isTermsAccepted,
                         nameOnCard = hybrisUser.sslLoyaltyDetailData.nameOnCard,
                         numberOfChildren = hybrisUser.sslLoyaltyDetailData.numberOfChildren,
                         optionEmail = hybrisUser.sslLoyaltyDetailData.optionEmail,
                         optionMobile = hybrisUser.sslLoyaltyDetailData.optionMobile,
                         optionTele = hybrisUser.sslLoyaltyDetailData.optionTele,
                         original16DigitCardNumber = hybrisUser.sslLoyaltyDetailData.original16DigitCardNumber,
                         original16DigitCardNumberFormatted = hybrisUser.sslLoyaltyDetailData.original16DigitCardNumberFormatted,
                         primaryCardNumber = hybrisUser.sslLoyaltyDetailData.primaryCardNumber,
                         selfEmployed = hybrisUser.sslLoyaltyDetailData.selfEmployed,
                         tier = hybrisUser.sslLoyaltyDetailData.tier,


                     };

             }*/
                Log.Information($"response received from gravty for getGroupLoyaltyPoints service is {JsonConvert.SerializeObject(result)}");
                return result;


            }
            catch (Exception ex)
            {
                Log.Error($"error while processing getGroupLoyaltyPoints with {ex.Message}");

                return new GetGroupLoyaltyData { ErrorMsg = ex.Message };

            }
        }

        public async Task<AuthTokenResponse> GetOrGenerateToken()
        {
            string authTokenUrl = $"{Constants.ConstantData.GRAVTY_AUTH_TOKEN_URL}";
            Log.Information($"access token url for the gravity is : {authTokenUrl}");
            string jsonPayload = JsonConvert.SerializeObject(new
            {
                client_id = "PerpuleGravtyUAT@shoppersstop.com",
                client_secret = "DzGmBZO8M",
                grant_type = "client_credentials"

            });

            var queryParameters = new Dictionary<string, string>
            {
                { "client_id" , "PerpuleGravtyUAT@shoppersstop.com" },
                { "client_secret" , "DzGmBZO8M" },
                { "grant_type" , "client_credentials"}
            };
            var fullUrl = QueryHelpers.AddQueryString(authTokenUrl, queryParameters);
            Log.Information($"access token url for the gravity is : {fullUrl}");
            var requestMessage = new HttpRequestMessage(HttpMethod.Post, fullUrl);
            requestMessage.Content = new StringContent(jsonPayload, Encoding.UTF8, "application/json");
            requestMessage.Headers.Add("x-api-key", $"{Constants.ConstantData.GRAVTY_AUTH_TOKEN_X_API_KEY}");
            requestMessage.Headers.Add("User-Agent", $"{Constants.ConstantData.GRAVTT_USER_AGENT}");
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

        public async Task<LoyaltyRequest> PrepareGroupLoyaltyPointsRequest(LoyaltyRequest request)
        {
            LoyaltyRequest loyaltyRequest = new LoyaltyRequest();
            LoyaltyPointsRequest groupLoyaltyPoints = new LoyaltyPointsRequest();
            groupLoyaltyPoints.PromoFlag = request.GetGroupLoyaltyPointsRequest.PromoFlag;
            groupLoyaltyPoints.BusinessUnit = "SSL";
            groupLoyaltyPoints.CustomerNumber = request.GetGroupLoyaltyPointsRequest.CustomerNumber;
            groupLoyaltyPoints.EmailAddress = request.GetGroupLoyaltyPointsRequest.EmailAddress;
            groupLoyaltyPoints.CorrelationID = await _loyaltyStoreService.GenerateRandomUUID();
            groupLoyaltyPoints.MobileNumber = request.GetGroupLoyaltyPointsRequest.MobileNumber;
            loyaltyRequest.GetGroupLoyaltyPointsRequest = groupLoyaltyPoints;

            return loyaltyRequest;

        }
    }
}
