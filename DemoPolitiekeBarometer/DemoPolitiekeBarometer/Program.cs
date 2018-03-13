using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoPolitiekeBarometer
{
    public class Program
    {

        public static void Main(string[] args)
        {
            JsonReader reader = new JsonReader();
            reader.readJson();

        }
}
}
