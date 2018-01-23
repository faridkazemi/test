
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using BanjoTwitterExercise.Helpers;
using BanjoTwitterExercise.DTO;
using System;

namespace BanjoTwitterExercise.Repository
{
    public class TweetRepository : ITweetRepository
    {
        
        public async Task<TwitterTweetDTO> GetRecentTweetsByHashtagAsync(string hashtag)
        {
           
            IOAuthHelper oauth = new OAuthHelper();
            var token = await oauth.GetToken();

            //TODO Need to set in constractor and pas through interfaces and Autofac
            ////////////////////////////////////////////////
            IApiParameter parameter = new ApiParameter();
            IOAuthHelper auth = new OAuthHelper();
            IHttpRequestHeader header = new Helpers.HttpRequestHeader();
            header.HeaderName = "Authorization";
            header.HeaderValue = $"Bearer {token.access_token}";
            List<IApiParameter> parameters = new List<IApiParameter>();
            parameters.Add(new ApiParameter()
            {
                Name = "q",
                Value = hashtag,
            });
            parameters.Add(new ApiParameter()
            {
                Name = "since",
                Value = DateTime.Now.AddDays(-7).ToString("yyyy-MM-dd"),
            });
            parameters.Add(new ApiParameter()
            {
                Name = "count",
                Value = "100",
            });

            IHttpApiRequest<Token> request = new HttpApiRequest<Token>(Enums.APIsListEnum.SearchForTweets, parameters, header);
            HttpClientHelper<Token> clientHelper = new HttpClientHelper<Token>(request);

            HttpResponseMessage response = new HttpResponseMessage();
            var tweets = await clientHelper.GettAsync<TwitterTweetDTO>();

            return tweets;
        }
    }
}