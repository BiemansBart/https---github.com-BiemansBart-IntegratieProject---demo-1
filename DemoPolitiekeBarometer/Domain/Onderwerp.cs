using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain {
  public abstract class Onderwerp {
    public string id { get; set; }
    public string naam { get; set; }
    public bool isTreding { get; set; }
  }
}
