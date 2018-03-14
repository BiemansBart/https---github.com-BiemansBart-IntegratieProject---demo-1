using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL {
  public class TweetFiles {

    //Eerste keer dat getDump opgeroepen wordt krijg je TextDump1.json terug
    //Tweede keer krijg je TextDump2.json
    //alsof wij 2 keer de meest recente data uit textgain krijgen
    static int teller = 0;
    public string getDump() {
      string path;
      if (teller == 0) {
        path = "../../../DAL/Resources/TextDump1.json";
      } else if (teller == 1) {
        path = "../../../DAL/Resources/TextDump2.json";
      } else {
        return String.Empty;
      }

      string json;
      using (StreamReader sr = new StreamReader(path)) {
        json = (sr.ReadToEnd());
      }
      teller++;
      return json;
    }
  }
}
