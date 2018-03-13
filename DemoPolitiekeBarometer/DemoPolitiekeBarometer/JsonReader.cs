using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoPolitiekeBarometer {
  public class JsonReader {

    public List<Tweet> readJson(string path) {
      //heel de json file inlezen als string
      string json;
      using (StreamReader sr = new StreamReader(path)) {
        json = (sr.ReadToEnd());
      }
      //een tweetDump Object aanmaken van de json string (bevat een array van tweets)
      TweetDump tweetDump = JsonConvert.DeserializeObject<TweetDump>(json);
      //De array aan de tweet variabele doorgeven
      List<Tweet> tweets = new List<Tweet>(tweetDump.Tweet);
      return tweets;
    }
  }

}

