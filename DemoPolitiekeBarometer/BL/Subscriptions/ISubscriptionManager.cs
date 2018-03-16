using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
  public interface ISubscriptionManager
  {
    IEnumerable<Subscription> GetUserSubscription(string id);
    void AddSubscription(Subscription subscription);
    IEnumerable<Subscription> GetSubscriptions();
  }
}
