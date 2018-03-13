using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoPolitiekeBarometer {
  public class JsonReader {
    private List<Tweet> tweets = new List<Tweet>();
    public void readJson() {

      //heel de json file inlezen als string
      string json;
      using (StreamReader sr = new StreamReader("../../Resources/TextDump.json")) {
        json = (sr.ReadToEnd());
      }

      //een tweetDump Object aanmaken van de json string (bevat een array van tweets)
      TweetDump tweetDump = JsonConvert.DeserializeObject<TweetDump>(json);
      //De array aan de tweet variabele doorgeven
      tweets = new List<Tweet>(tweetDump.Tweet);
      //tests cw tab tab
      foreach (Tweet tweet in tweetDump.Tweet) {
        Console.WriteLine(tweet.ToString());
      }

      Console.WriteLine(tweetDump.Tweet.Length);

      Console.ReadLine();
    }
  }

}

