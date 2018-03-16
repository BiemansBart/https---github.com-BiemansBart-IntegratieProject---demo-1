using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public interface ISubscriptionRepo
    {
        void CreateSubscription(Subscription subscription);
        IEnumerable<Subscription> Readsubscriptions();
        Subscription Readsubscription(string id);
        List<Subscription> ReadSubscriptionsMetNaamOnderwerp(string id);
    }
}
