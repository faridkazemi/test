using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BanjoTwitterExercise.Helpers
{
    public class Credential:ICredential
    {
        public string OAuthConsumerKey { get; set; }
        public string OAuthConsumerSecret { get; set; }

    }
}