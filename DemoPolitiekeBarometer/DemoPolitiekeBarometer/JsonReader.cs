using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoPolitiekeBarometer
{
    public class JsonReader
    {

        private List<Tweet> tweets = new List<Tweet>();

        private List<string> words = new List<string>();
        private List<string> hashtags = new List<string>();
        private bool inArray = false;
        private string tokentypevalue = null;
        private StringBuilder politican = new StringBuilder();

        public void readJson()
        {
            JsonTextReader reader = new JsonTextReader(new StringReader(File.ReadAllText("../../Resources/TextDump.json")));
            while (reader.Read())
            {
                if (reader.TokenType.ToString().Equals("StartObject")) {
                    Console.WriteLine("Start Tweet");
                }
                if (reader.TokenType.ToString().Equals("PropertyName") && reader.Value.ToString().Equals("words")) {
                    inArray = true;
                    tokentypevalue = "words";
                }
                if (reader.TokenType.ToString().Equals("PropertyName") && reader.Value.ToString().Equals("politician"))
                {
                    inArray = true;
                    tokentypevalue = "politician";
                }
                if (reader.TokenType.ToString().Equals("PropertyName") && reader.Value.ToString().Equals("hashtags"))
                {
                    inArray = true;
                    tokentypevalue = "hashtags";
                }
                if (reader.TokenType.ToString().Equals("StartArray")) {
                        Console.WriteLine("Start Array");
                }
                if (reader.TokenType.ToString().Equals("EndArray")){
                    inArray = false;

                }


                if (reader.TokenType.ToString().Equals("String") && inArray && tokentypevalue.Equals("words")) {
                    words.Add(reader.Value.ToString());
                }
                if (reader.TokenType.ToString().Equals("String") && inArray && tokentypevalue.Equals("politician"))
                {
                    politican.Append(reader.Value.ToString());
                    politican.Append(" ");
                }
                if (reader.TokenType.ToString().Equals("String") && inArray && tokentypevalue.Equals("hashtags"))
                {
                    hashtags.Add(reader.Value.ToString());
                }
                if (reader.TokenType.ToString().Equals("EndObject"))
                {
                    Console.WriteLine("End Tweet");
                    Console.ReadLine();
                    Console.WriteLine("WORDS: ");
                    for (int i = 0; i < words.Count; i++)
                    {
                        Console.Write(words[i] + ", ");
                    }
                    Console.WriteLine("HASHTAGS: ");
                    for (int i = 0; i < hashtags.Count; i++)
                    {
                        Console.Write(words[i] + ", ");
                    }
                    Console.WriteLine("POLITICIAN: ");
                    Console.WriteLine(politican.ToString());
                    Console.ReadLine();
                    words = new List<string>();
                    politican = new StringBuilder();
                    hashtags = new List<string>();
                }
                //Console.ReadLine();
            }   
            Console.ReadLine();
        }
    }
}