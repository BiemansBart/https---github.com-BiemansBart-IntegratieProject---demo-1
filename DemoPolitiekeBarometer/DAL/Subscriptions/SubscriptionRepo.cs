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
    private ApplicationUserRepository userRepository;
    private OnderwerpRepository onderwerpRepository;

    public SubscriptionRepo()
    {
      userRepository = new ApplicationUserRepository();
      onderwerpRepository = new OnderwerpRepository();
      if (subscriptions == null)
      {
        subscriptions = new List<Subscription>();

        MaakSubscriptionAan();
      }
    }

    private void MaakSubscriptionAan()
    {
      //User 1 - Geen trending alerts
      Subscription subscription1 = new Subscription
      {
        Id = "1",
        AlertType = AlertType.BROWSER,
        ApplicationUser = userRepository.ReadUser("1"),
        Onderwerp = onderwerpRepository.ReadOnderwerp(2)
      };
      subscriptions.Add(subscription1);

      Subscription subscription2 = new Subscription
      {
        Id = "2",
        AlertType = AlertType.BROWSER,
        ApplicationUser = userRepository.ReadUser("1"),
        Onderwerp = onderwerpRepository.ReadOnderwerp(3)
      };
      subscriptions.Add(subscription2);


      Subscription subscription3 = new Subscription
      {
        Id = "3",
        AlertType = AlertType.BROWSER,
        ApplicationUser = userRepository.ReadUser("1"),
        Onderwerp = onderwerpRepository.ReadOnderwerp(5)
      };
      subscriptions.Add(subscription3);


      //User 2 - 1 trending 1 niet trending
      Subscription subscription4 = new Subscription
      {
        Id = "4",
        AlertType = AlertType.BROWSER,
        ApplicationUser = userRepository.ReadUser("2"),
        Onderwerp = onderwerpRepository.ReadOnderwerp(1)
      };
      subscriptions.Add(subscription4);

      Subscription subscription5 = new Subscription
      {
        Id = "5",
        AlertType = AlertType.BROWSER,
        ApplicationUser = userRepository.ReadUser("2"),
        Onderwerp = onderwerpRepository.ReadOnderwerp(5)
      };
      subscriptions.Add(subscription5);

      // User 3 - 2 trending
      Subscription subscription6 = new Subscription
      {
        Id = "6",
        AlertType = AlertType.BROWSER,
        ApplicationUser = userRepository.ReadUser("3"),
        Onderwerp = onderwerpRepository.ReadOnderwerp(1)
      };
      subscriptions.Add(subscription6);

      Subscription subscription7 = new Subscription
      {
        Id = "7",
        AlertType = AlertType.BROWSER,
        ApplicationUser = userRepository.ReadUser("3"),
        Onderwerp = onderwerpRepository.ReadOnderwerp(6)
      };
      subscriptions.Add(subscription7);


    }

    public void CreateSubscription(Subscription subscription)
    {
            subscriptions.Add(subscription);
    }

    public IEnumerable<Subscription> Readsubscriptions()
    {
      return subscriptions;
    }

    public Subscription Readsubscription(string id)
    {
      return subscriptions.Find(x => x.Id == id);
    }
  }
}
