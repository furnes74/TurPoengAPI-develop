using Db.Models;
using Db.ViewModels;

namespace Db.Repository
{
    public interface IPersonRepository
    {
        PersonVm GetPerson(int id);
        Person GetPersonForAdmin(int id);

        FriendVm[] GetFriends(int id);
    }
}
