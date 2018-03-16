using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public abstract class Onderwerp
    {
        public int id { get; set; }
        public string naam { get; set; }
        public bool isTrending { get; set; }
        public double? TrendingScore { get; set; }
    }
}
