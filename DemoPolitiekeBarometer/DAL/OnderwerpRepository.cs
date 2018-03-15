using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;

namespace DAL {
  public class OnderwerpRepository : IOnderwerpRepository {
    private List<Onderwerp> onderwerpen;
    public OnderwerpRepository() {
      seed();
    }

    private void seed() {
      onderwerpen = new List<Onderwerp>();

      Persoon persoon1 = new Persoon() {
        id = 1,
        isTrending = false,
        naam = "Imade Annouri"
      };
      Persoon persoon2 = new Persoon() {
        id = 2,
        isTrending = false,
        naam = "Caroline Bastiaens"
      };
      Persoon persoon3 = new Persoon() {
        id = 3,
        isTrending = false,
        naam = "Jan Bertels"
      };
      Persoon persoon4 = new Persoon() {
        id = 4,
        isTrending = false,
        naam = "Vera Celis"
      };
      Persoon persoon5 = new Persoon() {
        id = 5,
        isTrending = false,
        naam = "Dirk De Kort"
      };
      Persoon persoon6 = new Persoon() {
        id = 6,
        isTrending = false,
        naam = "Annick De Ridder"
      };
      Persoon persoon7 = new Persoon() {
        id = 7,
        isTrending = false,
        naam = "Caroline Gennez"
      };
      Persoon persoon8 = new Persoon() {
        id = 8,
        isTrending = false,
        naam = "Kathleen Helsen"
      };
      Persoon persoon9 = new Persoon() {
        id = 9,
        isTrending = false,
        naam = "Marc Hendrickx"
      };
      Persoon persoon10 = new Persoon() {
        id = 10,
        isTrending = false,
        naam = "Jan Hofkens"
      };
      Persoon persoon11 = new Persoon() {
        id = 11,
        isTrending = false,
        naam = "Yasmine Kherbache"
      };
      Persoon persoon12 = new Persoon() {
        id = 12,
        isTrending = false,
        naam = "Kathleen Krekels"
      };
      Persoon persoon13 = new Persoon() {
        id = 13,
        isTrending = false,
        naam = "Ingrid Pira"
      };

      onderwerpen.Add(persoon1);
      onderwerpen.Add(persoon2);
      onderwerpen.Add(persoon3);
      onderwerpen.Add(persoon4);
      onderwerpen.Add(persoon5);
      onderwerpen.Add(persoon6);
      onderwerpen.Add(persoon7);
      onderwerpen.Add(persoon8);
      onderwerpen.Add(persoon9);
      onderwerpen.Add(persoon10);
      onderwerpen.Add(persoon11);
      onderwerpen.Add(persoon12);
      onderwerpen.Add(persoon13);
    }

    public void CreateOnderwerp(Onderwerp onderwerp) {
      onderwerpen.Add(onderwerp);
    }

    public IEnumerable<Onderwerp> ReadOnderwerpen() {
      return onderwerpen;
    }

    public Onderwerp ReadOnderwerp(int id) {
      return onderwerpen.ElementAt(id - 1);
    }
  }
}
