using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Domain;

namespace BL
{
  public class OnderwerpManager : IOnderwerpManager
  {
    private readonly IOnderwerpRepository repo;
    private readonly ISubscriptionRepo subscriptionRepo;
    private readonly TweetManager Tweetmgr;

    public OnderwerpManager()
    {
      repo = new OnderwerpRepository();
      Tweetmgr = new TweetManager();
      subscriptionRepo = new SubscriptionRepo();
    }

    public void AddOnderwerp(Onderwerp onderwerp)
    {
      repo.CreateOnderwerp(onderwerp);
    }

    public List<Subscription> BerekenTrending(List<Tweet> NieuweTweets)
    {
      List<Tweet> OudeTweets = Tweetmgr.GetTweets().ToList();
      Dictionary<string, int> onderwerpenMapNieuwBinnengekomenData = new Dictionary<string, int>();
      Dictionary<string, int> onderwerpenMapOudeData = new Dictionary<string, int>();

      int teller = 0;
      foreach (var Onderwerp in repo.ReadOnderwerpen())
      {
        onderwerpenMapNieuwBinnengekomenData.Add(Onderwerp.naam, 0);
        onderwerpenMapOudeData.Add(Onderwerp.naam, 0);
      }
      foreach (var Politicus in NieuweTweets)
      {
        Politicus.ZetPoliticusNaamOm();
        if (onderwerpenMapNieuwBinnengekomenData.ContainsKey(Politicus.Naam))
        {
          onderwerpenMapNieuwBinnengekomenData[Politicus.Naam]++;
        }

      }
      foreach (var Politicus in Tweetmgr.GetTweets())
      {
        Politicus.ZetPoliticusNaamOm();
        if (onderwerpenMapOudeData.ContainsKey(Politicus.Naam))
        {
          onderwerpenMapOudeData[Politicus.Naam]++;
        }

      }


      //Console.WriteLine("Nieuwe lijst");
      //foreach (var key in onderwerpenMapNieuwBinnengekomenData.Keys)
      //{
      //    Console.WriteLine(key + " " + onderwerpenMapNieuwBinnengekomenData[key]);
      //}

      //Console.WriteLine("Oude lijst");
      //foreach (var key in onderwerpenMapOudeData.Keys)
      //{
      //    Console.WriteLine(key + " " + onderwerpenMapOudeData[key]);
      //}

      List<Subscription> returnWaardere =  GetSubscriptionsVoorTrendingOnderwerpen(onderwerpenMapOudeData, onderwerpenMapNieuwBinnengekomenData);
      return  returnWaardere;
    }

    private List<Subscription> GetSubscriptionsVoorTrendingOnderwerpen(Dictionary<string, int> onderwerpenMapOudeData, Dictionary<string, int> onderwerpenMapNieuwBinnengekomenData)
    {
      int teller;
      int noemer;
      // Hoe hoger het arbitrair getal, hoe minder politiekers er trending zijn.
      int arbitrairGetal = 10;
      double trendingScore;
      List<Subscription> subscriptionsTrendingOnderwerpen = new List<Subscription>(); ;

      foreach (var key in onderwerpenMapNieuwBinnengekomenData.Keys)
      {
        teller = onderwerpenMapNieuwBinnengekomenData[key];
        noemer = onderwerpenMapOudeData[key];

        trendingScore = (double)teller / (double)(noemer + arbitrairGetal);
        Console.WriteLine(key + " " + trendingScore);
        if (trendingScore >= 0.20)
        {
          repo.ReadOnderwerpString(key).isTrending = true;
          //List<Subscription> TesLijstMagVerwijderdWorden = subscriptionRepo.Readsubscriptions().Where(x => x.Onderwerp.id == repo.ReadOnderwerpString(key).id).ToList();
          //Console.WriteLine(TesLijstMagVerwijderdWorden.Count + " Count van testlijst");
          foreach (var item in subscriptionRepo.Readsubscriptions().Where(x => x.Onderwerp.id == repo.ReadOnderwerpString(key).id).ToList())
          {
            
          }
          
          //Console.WriteLine(key + " is trending");
          //Console.WriteLine(repo.ReadOnderwerpString(key).naam + " " + repo.ReadOnderwerpString(key).isTrending);
        }
      }
      List<Subscription> AlleSubscriptions = subscriptionRepo.Readsubscriptions().ToList();
      List<Onderwerp> trendingOnderwerpen = repo.ReadOnderwerpen().Where(x => x.isTrending == true).ToList();

      foreach (var item in trendingOnderwerpen) {
        if (item.isTrending)
        {
          foreach (var item2 in AlleSubscriptions)
          {
            if (item.id == item2.Onderwerp.id) {
              item2.Onderwerp.isTrending = true;
              Console.WriteLine(item2.ApplicationUser.Voornaam + " " + item2.Onderwerp.naam);
            }
          }
        }
      }    
      return subscriptionsTrendingOnderwerpen;
    }


    public IEnumerable<Onderwerp> getAllOnderwerpen()
    {
      return repo.ReadOnderwerpen();

    }

    public Onderwerp getOnderwerp(int id)
    {
      return repo.ReadOnderwerp(id);
    }
  }
}
