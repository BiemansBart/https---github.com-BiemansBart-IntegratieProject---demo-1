using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public interface IOnderwerpRepository
    {
        void CreateOnderwerp(Onderwerp onderwerp);
        IEnumerable<Onderwerp> ReadOnderwerpen();
        Onderwerp ReadOnderwerp(int id);
        Onderwerp ReadOnderwerpString(string naam);

    }
}
