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
        public void readJson()
        {
            JsonTextReader reader = new JsonTextReader(new StringReader(File.ReadAllText("../../Resources/TextDump.json")));
            while (reader.Read())
            {
                /*Console.WriteLine(reader.TokenType + " TokenType");
                if (reader.TokenType.ToString().Equals("StartArray")){
                    while (reader.TokenType.Equals("String"))
                    {
                        Console.WriteLine("In while loop: " + reader.Value);
                    }
                }*/
                if (reader.Value != null)
                {
                    if (reader.Value.ToString().Equals("records"))
                    {
                        Console.WriteLine("Start alle tweets");
                    }
                    else
                    {
                        Console.WriteLine(reader.Value);
                    }
                }
                else
                {
                    if (reader.TokenType.ToString().Equals("StartObject"))
                    {
                        Console.WriteLine("Begin Tweet");
                    }
                    
                }
                Console.ReadLine();


            }


        }

    }
}
