using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoPolitiekeBarometer
{
    public class Tweet
    {
        public long TweetId { get; set; }
        public string User_id { get; set; }
        public string Geo { get; set; }
        public List<string> Mentions { get; set; }
        public bool Retweet { get; set; }
        public DateTime Date { get; set; }
        public List<string> Words { get; set; }
        public int[] Sentiment { get; set; }
        public Arr MyProperty { get; set; }
    }
}
