using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using static BanjoTwitterExercise.Helpers.Enums;

namespace BanjoTwitterExercise.Helpers
{
    public interface IHttpApiRequest<T>
    {
       string GetBaseAddress();
       string GetApiName();

        T GetRespons();

        string GetParametersAsQueryString();

        IHttpRequestHeader Header { get; set; }
    }
}