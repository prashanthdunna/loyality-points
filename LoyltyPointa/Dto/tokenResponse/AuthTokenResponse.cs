namespace LoyltyPointa.Dto.tokenResponse
{
    public class AuthTokenResponse
    {
        public string Access_Token { get; set; }
        public string Scope { get; set; }
        public string Token_Type { get; set; }
        public int Expires_In { get; set; }
        public string Error { get; set; }
/*
        public AuthTokenResponse() { }

        public AuthTokenResponse(AuthTokenResponse authResponse)
        {
            if (authResponse != null)
            {
                Access_Token = authResponse.Access_Token;
                Scope = authResponse.Scope;
                Token_Type = authResponse.Token_Type;
                Expires_In = authResponse.Expires_In;
                Error = authResponse.Error;
            }
        }*/

    }
}
