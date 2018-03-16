using Newtonsoft.Json;
using BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;

namespace DemoPolitiekeBarometer
{
  public class Program
  {
    private static readonly ITweetManager mgr = new TweetManager();
    private static readonly IOnderwerpManager OnderwerpMgr = new OnderwerpManager();
    private static readonly IApplicationUserManager applicationUserManager = new ApplicationUserManager();
    private static readonly ISubscriptionManager subscriptionManager = new SubscriptionManager();

    public static void Main(string[] args)
    {
      //Laatste textDump1 ophalen
      List<Tweet> listTextDump1 = mgr.GetLatestTweetDump();
      //tweets toevoegen aan databank
      mgr.AddAllTweets(listTextDump1);
      //TextDump2 in databank zetten
      List<Tweet> listTextDump2 = mgr.GetLatestTweetDump();

      List<Alert> LijstMetALerts = OnderwerpMgr.BerekenTrending(listTextDump2);
            foreach (var item in LijstMetALerts)
            {
                Console.WriteLine(item);
            }
      
      Console.ReadLine();

    }
  }
}


