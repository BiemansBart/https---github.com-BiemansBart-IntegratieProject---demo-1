using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;

namespace DAL
{
  public class SubscriptionRepo : ISubscriptionRepo
  {

    private static List<Subscription> subscriptions;

    public SubscriptionRepo()
    {
      subscriptions = new List<Subscription>();
      MaakSubscriptionAan();
    }

    private void MaakSubscriptionAan()
    {
      //User 1 - Geen trending alerts
      Subscription subscription1 = new Subscription
      {
          Id = "1",
          AlertType = AlertType.BROWSER,
          ApplicationUser = new ApplicationUser {
              UserId = "99",
              Achternaam = "Vermeulen",
              Voornaam = "Jos"
          },
      };
      subscriptions.Add(subscription1);
    }

    public void CreateSubscription(Subscription subscription)
    {
      throw new NotImplementedException();
    }

    public IEnumerable<Subscription> Readsubscriptions()
    {
      return subscriptions;
    }



  }
}
