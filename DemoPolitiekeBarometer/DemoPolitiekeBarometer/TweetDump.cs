﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace DemoPolitiekeBarometer {
  class TweetDump {
    [JsonProperty("records")]
    public Tweet[] Tweet { get; set; }
  }
}