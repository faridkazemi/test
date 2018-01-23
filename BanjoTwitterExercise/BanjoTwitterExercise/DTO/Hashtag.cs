using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BanjoTwitterExercise.DTO
{
    public class Hashtag
    {
        public string text { get; set; }
        public List<string> indices { get; set; }

    }
}