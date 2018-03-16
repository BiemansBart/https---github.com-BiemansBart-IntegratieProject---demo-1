using Newtonsoft.Json;
using BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;

namespace DemoPolitiekeBarometer {
  public class Program {
    private static readonly ITweetManager tweetManager = new TweetManager();
    private static readonly IOnderwerpManager onderwerpManager = new OnderwerpManager();

    public static void Main(string[] args) {
      //Haal startdata uit de json en zet in de startlijst
      //Laatste textDump1 ophalen
      List<Tweet> listTextDump1 = tweetManager.GetLatestTweetDump();

      //Hier begint de effectieve methode om de alerts te genereren 
      //TextDump2 in databank zetten
      List<Tweet> listTextDump2 = tweetManager.GetLatestTweetDump();

      List<Alert> LijstMetALerts = onderwerpManager.BerekenTrending(listTextDump2);
      foreach (var item in LijstMetALerts) {
        Console.WriteLine(item);
      }

      Console.ReadLine();

    }
  }
}


