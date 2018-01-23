using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BanjoTwitterExercise.DTO
{
    public class Enitity
    {
        public List<Hashtag> hashtags { get; set; }
        public List<string> symbols { get; set; }
        public List<UserMention> user_mentions { get; set; }
    }
}