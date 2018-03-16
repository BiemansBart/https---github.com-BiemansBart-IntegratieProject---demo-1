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

        public List<Alert> GenereerAlerts(List<Tweet> NieuweTweets)
        {
            List<Tweet> OudeTweets = Tweetmgr.GetTweets().ToList();
            Dictionary<string, int> onderwerpenMapNieuwBinnengekomenData = new Dictionary<string, int>();
            Dictionary<string, int> onderwerpenMapOudeData = new Dictionary<string, int>();

            // Hierin voegen we onderwerpen toe aan de juiste dictionaries.
            foreach (var Onderwerp in repo.ReadOnderwerpen())
            {
                onderwerpenMapNieuwBinnengekomenData.Add(Onderwerp.naam, 0);
                onderwerpenMapOudeData.Add(Onderwerp.naam, 0);
            }
            // Hier wordt gekeken hoeveel keer de politieker voorkomt wordt in de nieuwe data
            foreach (var Politicus in NieuweTweets)
            {
                if (onderwerpenMapNieuwBinnengekomenData.ContainsKey(Politicus.Naam))
                {
                    // Hier tellen 1 bij de value per keer dat de politieker voorkomt in de nieuwe data. Zo weten het totaal aantal keer dat en politieke voorkomt in de nieuwe data.
                    onderwerpenMapNieuwBinnengekomenData[Politicus.Naam]++;
                }

            }
            //TODO : Niet in alle tweets gaan zien, maar zoeken in de tweets van nu tot een week geleden.
            foreach (var Politicus in Tweetmgr.GetTweets())
            {
                if (onderwerpenMapOudeData.ContainsKey(Politicus.Naam))
                {
                    onderwerpenMapOudeData[Politicus.Naam]++;
                }

            }

            return BerekenTrending(onderwerpenMapOudeData, onderwerpenMapNieuwBinnengekomenData);
        }

        // Gaat alle subscriptions ophalen voor de onderwerpen die op dit moment trending zijn
        private List<Alert> BerekenTrending(Dictionary<string, int> onderwerpenMapOudeData, Dictionary<string, int> onderwerpenMapNieuwBinnengekomenData)
        {
            int teller;
            int noemer;
            // Hoe hoger het arbitrair getal, hoe minder politiekers er trending zijn.

            double trendingScore = 0;
            List<Subscription> subscriptionsTrendingOnderwerpen = new List<Subscription>();

            // TODO : Filteren op datum!
            foreach (var key in onderwerpenMapNieuwBinnengekomenData.Keys)
            {
                teller = onderwerpenMapNieuwBinnengekomenData[key];
                noemer = onderwerpenMapOudeData[key];

                trendingScore = VoerTrendingBerekeningUit(teller, noemer);
                repo.ReadOnderwerpString(key).TrendingScore = trendingScore;

                if (trendingScore >= 0.13)
                {
                    repo.ReadOnderwerpString(key).isTrending = true;
                    foreach (var item in subscriptionRepo.ReadSubscriptionsMetNaamOnderwerp(key))
                    {
                        item.Onderwerp.TrendingScore = trendingScore;
                        item.Onderwerp.isTrending = true;
                    }
                }

            }


            List<Onderwerp> trendingOnderwerpen = repo.ReadOnderwerpen().Where(x => x.isTrending == true).ToList();
            // Gaat per Trending onderwerp alle subscriptions halen, en daar in die repo de isTrending ook op true zetten, zodat de alerts geactiveerd worden.
            foreach (var item in trendingOnderwerpen)
            {
                if (item.isTrending)
                {
                    foreach (var item2 in subscriptionRepo.Readsubscriptions().ToList())
                    {
                        if (item.id == item2.Onderwerp.id)
                        {
                            item2.Onderwerp.isTrending = true;
                            subscriptionsTrendingOnderwerpen.Add(item2);
                        }
                    }
                }
            }
            // hierin worden de alerts aangemaakt die terug worden gestuurd

            List<Alert> AlertList = new List<Alert>();

            foreach (var item in subscriptionsTrendingOnderwerpen)
            {
                Alert alert = new Alert()
                {
                    Subscription = item,
                    text = item.Onderwerp.ToString()

                };
                AlertList.Add(alert);
            }
            return AlertList;
        }


        public IEnumerable<Onderwerp> getAllOnderwerpen()
        {
            return repo.ReadOnderwerpen();

        }

        public Onderwerp getOnderwerp(int id)
        {
            return repo.ReadOnderwerp(id);
        }

        private double VoerTrendingBerekeningUit(double tellerScore, double noemerScore)
        {
            double ArbitrairGetal = 10;
            return tellerScore / (noemerScore + ArbitrairGetal);
        }
    }
}
