﻿using Newtonsoft.Json;
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

        public static void Main(string[] args)
        {
            //Laatste textDump1 ophalen
            List<Tweet> listTextDump1 = mgr.GetLatestTweetDump();

            //testjes
            //tellen hoeveel tweets er zijn in textdump1
            int teller = 0;
            foreach (Tweet tweet in listTextDump1)
            {
                //Console.WriteLine(tweet.ToString());
                teller++;
            }
            //tweets toevoegen aan databank
            mgr.AddAllTweets(listTextDump1);
            Console.WriteLine(teller);
            Console.ReadLine();

            //TextDump2 in databank zetten
            List<Tweet> listTextDump2 = mgr.GetLatestTweetDump();

            //Steek de laatste dump in de databank/repo
            //mgr.AddAllTweets(listTextDump2);

            //tellen hoeveel tweets er in totaal zijn
            //teller = 0;
            //List<Tweet> tweetList2 = mgr.GetTweets().ToList<Tweet>();
            //foreach (Tweet tweet in tweetList2)
            //{
            //    teller++;
            //}

           // Console.WriteLine(teller);
           // Console.ReadLine();

            OnderwerpMgr.BerekenTrending(listTextDump2);
            Console.ReadLine();
        }
    }
}


