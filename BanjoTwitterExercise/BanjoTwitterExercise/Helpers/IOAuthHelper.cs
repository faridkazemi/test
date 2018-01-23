using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace BanjoTwitterExercise.Helpers
{
    public interface IOAuthHelper
    {
        IHttpRequestHeader GenerateHeader();
        Task<Token> GetToken();
    }
}