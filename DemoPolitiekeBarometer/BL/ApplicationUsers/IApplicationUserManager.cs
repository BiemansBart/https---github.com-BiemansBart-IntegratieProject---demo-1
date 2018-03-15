using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
  public interface IApplicationUserManager
  {
    void AddApplicationUser(ApplicationUser user);
    ApplicationUser GetApplicationsUser(string id);
    IEnumerable<ApplicationUser> GetAllApplicationUsers();
  }
}
