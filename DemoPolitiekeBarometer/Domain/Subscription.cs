using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain {
  public class Subscription {
    public string Id { get; set; }
    public Onderwerp Onderwerp { get; set; }
    public ApplicationUser ApplicationUser { get; set; }
    public AlertType AlertType {get; set;}

        public override string ToString()
        {
            return String.Format("{0} krijgt een alert over : {1} , want die is trending met {2}. Deze alert krijgt hij/zei via {3}", ApplicationUser.Voornaam, Onderwerp.naam, Onderwerp.TrendingScore,AlertType);
        }
    }
}
