using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BanjoTwitterExercise.Helpers
{
    public interface IHttpRequestHeader
    {
        string HeaderName { get; set; }
        string HeaderValue { get; set; }
    }
}