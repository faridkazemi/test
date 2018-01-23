using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BanjoTwitterExercise.Helpers
{
    public interface IApiParameter
    {
        string Name { get; set; }
        object Value { get; set; }
    }
}