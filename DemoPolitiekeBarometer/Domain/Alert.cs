﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain {
  public class Alert {
    public string id { get; set; }
    public Onderwerp onderwerp { get; set; }
    public ApplicationUser applicationUser { get; set; }
  }
}