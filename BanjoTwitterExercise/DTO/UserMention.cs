using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BanjoTwitterExercise.DTO
{
    public class UserMention
    {
        public string screen_name { get; set; }
        public string id { get; set; }
        public string id_str { get; set; }
        public string name { get; set; }
        public List<string> indices { get; set; }

    }
}