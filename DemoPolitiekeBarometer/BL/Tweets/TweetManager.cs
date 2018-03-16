using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;
using DAL;
using Newtonsoft.Json;

namespace BL {
  public class TweetManager : ITweetManager {
    private readonly ITweetRepository repo;
    private readonly TweetFiles dataReader;

    public TweetManager() {
      repo = new TweetRepository();
      dataReader = new TweetFiles();
    }

    public void AddTweet(Tweet tweet) {
     repo.CreateTweet(tweet);
    }

    public void AddAllTweets(List<Tweet> tweets) {
      for (int i = 0; i < tweets.Count; i++) {
        repo.CreateTweet(tweets[i]);
      }
    }

    public IEnumerable<Tweet> GetTweets() {
      return repo.ReadTweets();
    }

    public List<Tweet> GetLatestTweetDump() {
      //heel de json file ophalen uit de database van textgain
      string json = dataReader.getDump();

      //een tweetDump Object aanmaken van de json string (bevat een array van tweets)
      TweetDump tweetDump = JsonConvert.DeserializeObject<TweetDump>(json);
      //De array aan de tweet variabele doorgeven
      List<Tweet> tweets = new List<Tweet>(tweetDump.Tweet);
            foreach (var item in tweets)
            {
                item.ZetPoliticusNaamOm();
            }
      return tweets;
    }

  }
}
