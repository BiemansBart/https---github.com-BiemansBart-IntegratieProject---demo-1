using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoPolitiekeBarometer {

  public class Tweet {

    [JsonProperty("id")]
    public long TweetId { get; set; }
    [JsonProperty("user_id")]
    public string User_id { get; set; }
    [JsonProperty("geo")]
    public string Geo { get; set; }
    [JsonProperty("mentions")]
    public List<string> Mentions { get; set; }
    [JsonProperty("retweet")]
    public bool Retweet { get; set; }
    [JsonProperty("date")]
    public DateTime Date { get; set; }
    [JsonProperty("words")]
    public List<string> Words { get; set; }
    [JsonProperty("sentiment")]
    public double[] Sentiment { get; set; }
    [JsonProperty("hashtags")]
    public List<string> Hashtags { get; set; }
    [JsonProperty("urls")]
    public List<string> Urls { get; set; }
    [JsonProperty("politician")]
    public string[] politicus { get; set; }

    public override string ToString() {
      string naam = String.Format("{0} {1}", politicus[0], politicus[1]);
      string keywords = Words[0];
      for (int i = 1; i < Words.Count; i++) {
        keywords = String.Format("{0} {1}", keywords, Words[i]);
      }
      return String.Format("tweet id:{0} - van:{1} - keywords:{2}", TweetId, naam, keywords);
    }
  }
}
