using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
  public class ApplicationUserRepository : IApplicationUserRepository
  {
    private static List<ApplicationUser> UserList;

    public ApplicationUserRepository()
    {
      UserList = new List<ApplicationUser>();
      MaakApplicationUsersAan();
    }

    private void MaakApplicationUsersAan()
    {
      ApplicationUser user1 = new ApplicationUser()
      {
        Achternaam = "Smoots",
        UserId = "1",
        Voornaam = "Rému"
      };
      ApplicationUser user2 = new ApplicationUser()
      {
        Achternaam = "Peeters",
        UserId = "2",
        Voornaam = "Robbe"
      };
      ApplicationUser user3 = new ApplicationUser()
      {
        Achternaam = "Sladkov",
        UserId = "3",
        Voornaam = "Ivan"
      };
      ApplicationUser user4 = new ApplicationUser()
      {
        Achternaam = "Biemans",
        UserId = "4",
        Voornaam = "Bart"
      };
      UserList.Add(user1);
      UserList.Add(user2);
      UserList.Add(user3);
      UserList.Add(user4);
    }

    public void Create(ApplicationUser user)
    {
      throw new NotImplementedException();
    }

    public IEnumerable<ApplicationUser> ReadAlleUsers()
    {
      return UserList;
    }

    public ApplicationUser ReadUser(string id)
    {
      throw new NotImplementedException();
    }
  }
}
