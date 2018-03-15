using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
  public interface IApplicationUserRepository
  {
    void Create(ApplicationUser user);
    ApplicationUser ReadUser(string id);
    IEnumerable<ApplicationUser> ReadAlleUsers();
  }
}
