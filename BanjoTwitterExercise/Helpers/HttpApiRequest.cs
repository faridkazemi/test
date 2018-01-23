using BanjoTwitterExercise.Helpers;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using static BanjoTwitterExercise.Helpers.Enums;

namespace BanjoTwitterExercise.Helpers
{

    public class HttpApiRequest<T>: IHttpApiRequest<T>
    {
        APIsListEnum _apiName;
        List<IApiParameter> _parameters;
        public IHttpRequestHeader Header { get; set; }
         
        public HttpApiRequest(APIsListEnum api, List<IApiParameter> parameters, IHttpRequestHeader header)
        {
            _apiName = api;
            _parameters = parameters;
            this.Header = header;
        }

        public HttpApiRequest(APIsListEnum api, IHttpRequestHeader header)
        {
            _apiName = api;
            
            this.Header = header;
        }

        public string GetBaseAddress()
        {
            return ConfigurationManager.AppSettings["twitterAddress"];
        }

        public string GetApiName()
        {
            return ConfigurationManager.AppSettings[_apiName.ToString()];
        }

        public T GetRespons()
        {
            throw new NotImplementedException();
        }

        public string GetParametersAsQueryString()
        {
            if (_parameters == null)
                return null;

            var query = HttpUtility.ParseQueryString(string.Empty);
            _parameters.ForEach(p => query[p.Name] = p.Value.ToString());

            return query.ToString();
          

        }

    }
}