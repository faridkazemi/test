using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BanjoTwitterExercise.Helpers
{
    public class ApiParameter:IApiParameter
    {
        public string Name { get; set; }

        public object Value { get; set; }
    }
}