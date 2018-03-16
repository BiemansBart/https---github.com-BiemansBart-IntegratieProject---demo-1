using System;
using Domain;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL {
  public interface ITweetRepository {

    void CreateTweet(Tweet tweet);
    IEnumerable<Tweet> ReadTweets();


  }
}
