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
  }
}
