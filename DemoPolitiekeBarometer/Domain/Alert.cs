using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Alert
    {
        public Subscription Subscription { get; set; }
        public string text { get; set; }

        public override string ToString()
        {
            return String.Format("{0}", Subscription);
        }
    }
}
