using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BanjoTwitterExercise.Helpers
{
    public class HttpRequestHeader : IHttpRequestHeader
    {
        public string HeaderName { get; set; }
        public string HeaderValue { get; set; }

    }
}