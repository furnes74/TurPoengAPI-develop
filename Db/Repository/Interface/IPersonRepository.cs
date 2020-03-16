using Db.ViewModels;

namespace Db.Repository
{
    public interface IPersonRepository
    {
        PersonVm GetPerson(int id);
    }
}
