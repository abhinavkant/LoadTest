using Microsoft.IdentityModel.Tokens;

namespace SampleApp
{
    public class JwtExtensions
    {
        public sealed class JwkList
        {
            public JwkList(JsonWebKeySet jwkTaskResult)
            {
                Jwks = jwkTaskResult;
                When = DateTime.Now;
            }

            public DateTime When { get; set; }
            public JsonWebKeySet Jwks { get; set; }
        }
    }
}