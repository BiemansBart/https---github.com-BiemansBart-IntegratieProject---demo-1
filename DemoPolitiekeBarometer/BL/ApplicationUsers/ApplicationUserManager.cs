using BL;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;

namespace BL
{
  public class ApplicationUserManager : IApplicationUserManager
  {
    private readonly IApplicationUserRepository applicationUserRepository;
    public ApplicationUserManager()
    {
      applicationUserRepository = new ApplicationUserRepository();
    }

    public void AddApplicationUser(ApplicationUser user)
    {
      throw new NotImplementedException();
    }

    public IEnumerable<ApplicationUser> GetAllApplicationUsers()
    {
      return applicationUserRepository.ReadAlleUsers();
    }

    public ApplicationUser GetApplicationsUser(string id)
    {
      throw new NotImplementedException();
    }
  }
}
