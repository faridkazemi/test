using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace BanjoTwitterExercise.Helpers
{
    public class OAuthHelper: IOAuthHelper
    {
        public IHttpRequestHeader GenerateHeader()
        {
            
            var OAuthConsumerKey = "XqhN67iGbyqJTaGLcRnqmick0";
            var OAuthConsumerSecret = "6vDkHAv0AE9KORyvQrfm7uBZyul1AQ5nEOxZop3lD9r6hwjgdD";
            var userInfo = Convert.ToBase64String(new UTF8Encoding().GetBytes(OAuthConsumerKey + ":" + OAuthConsumerSecret));
            return new HttpRequestHeader()
            {
                HeaderName = "Authorization",
                HeaderValue = $"Basic {userInfo}"
            };
        }
        
       public async Task<Token> GetToken()
        {

            IApiParameter parameters = new ApiParameter();
            IHttpRequestHeader header = GenerateHeader();
            IHttpApiRequest<Token> request = new HttpApiRequest<Token>(Enums.APIsListEnum.Oath, header);
            HttpClientHelper<Token> clientHelper = new HttpClientHelper<Token>(request);
            var token = await clientHelper.PostAsync<Token>();
            return token;
        }
    }
}