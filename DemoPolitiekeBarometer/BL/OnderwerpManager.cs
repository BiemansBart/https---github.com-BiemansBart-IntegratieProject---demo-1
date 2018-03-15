using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Domain;

namespace BL {
  public class OnderwerpManager : IOnderwerpManager {
    private readonly IOnderwerpRepository repo;

    public OnderwerpManager() {
      repo = new OnderwerpRepository();
    }

    public void AddOnderwerp(Onderwerp onderwerp) {
      repo.CreateOnderwerp(onderwerp);
    }

    public IEnumerable<Onderwerp> getAllOnderwerpen() {
      return repo.ReadOnderwerpen();
      
    }

    public Onderwerp getOnderwerp(int id) {
      return repo.ReadOnderwerp(id);
    }
  }
}
