using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;

namespace DAL {
  public class TweetRepository : ITweetRepository {

    private List<Tweet> tweets;

    public TweetRepository() {
      tweets = new List<Tweet>();
    }

    public void CreateTweet(Tweet tweet) {
      tweets.Add(tweet);
    }

    public IEnumerable<Tweet> ReadTweets() {
      return tweets;
    }
  }
}
