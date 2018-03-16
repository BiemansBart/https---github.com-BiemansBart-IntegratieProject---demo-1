using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL {
  public interface ITweetManager {
    IEnumerable<Tweet> GetTweets();
    void AddTweet(Tweet tweet);
    void AddAllTweets(List<Tweet> tweets);
    List<Tweet> GetLatestTweetDump();
  }
}
