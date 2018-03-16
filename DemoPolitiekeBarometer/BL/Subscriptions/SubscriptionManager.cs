using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;
using DAL;

namespace BL
{
  public class SubscriptionManager : ISubscriptionManager
  {
    private readonly ISubscriptionRepo repo;
    public SubscriptionManager()
    {
      repo = new SubscriptionRepo();
    }


    public void AddSubscription(Subscription subscription)
    {
      throw new NotImplementedException();
    }

    public IEnumerable<Subscription> GetSubscriptions()
    {
      return repo.Readsubscriptions();
    }

    public IEnumerable<Subscription> GetUserSubscription(string id)
    {
      throw new NotImplementedException();
    }
  }
}
