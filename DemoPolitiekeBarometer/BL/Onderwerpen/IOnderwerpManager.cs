using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public interface IOnderwerpManager
    {
        void AddOnderwerp(Onderwerp onderwerp);
        Onderwerp getOnderwerp(int id);
        IEnumerable<Onderwerp> getAllOnderwerpen();
        List<Alert> BerekenTrending(List<Tweet> lijst);
    }
}
