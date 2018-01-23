using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BanjoTwitterExercise.DTO
{
    public class Statuse
    {
        public string created_at { get; set; }
        public string id { get; set; }
        public string id_str { get; set; }
        public string texttruncated { get; set; }
        public string geo { get; set; }
        public string place { get; set; }
        public string contributors { get; set; }
        public string retweet_count { get; set; }
        public string favorit_count { get; set; }
        public string text { get; set; }
        public string truncated { get; set; }
        public User user { get; set; }
        public Enitity entities { get; set; }
        //public Metadata metadata { get; set; }
        public string lang { get; set; }

    }
}