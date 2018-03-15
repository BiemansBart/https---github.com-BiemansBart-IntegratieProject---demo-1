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
        private readonly TweetManager Tweetmgr;

        public OnderwerpManager()
        {
            repo = new OnderwerpRepository();
            Tweetmgr = new TweetManager();
        }

        public void AddOnderwerp(Onderwerp onderwerp)
        {
            repo.CreateOnderwerp(onderwerp);
        }

        public void BerekenTrending(List<Tweet> NieuweTweets)
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

            trendingAloritme(onderwerpenMapOudeData, onderwerpenMapNieuwBinnengekomenData);            

        }

        private void trendingAloritme(Dictionary<string, int> onderwerpenMapOudeData, Dictionary<string, int> onderwerpenMapNieuwBinnengekomenData)
        {
            int teller;
            int noemer;
            // Hoe hoger het arbitrair getal, hoe minder politiekers er trending zijn.
            int arbitrairGetal = 10;
            double trendingScore;
            foreach (var key in onderwerpenMapNieuwBinnengekomenData.Keys) 
            {
                teller = onderwerpenMapNieuwBinnengekomenData[key];
                noemer = onderwerpenMapOudeData[key];

                trendingScore = (double)teller / (double)(noemer + arbitrairGetal);
                Console.WriteLine(key + " " + trendingScore);
                if(trendingScore >= 0.20){
                    Console.WriteLine(key + " is trending");
                    Console.WriteLine(repo.ReadOnderwerpString(key).naam + " " + repo.ReadOnderwerpString(key).isTrending);
                }
            }
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
