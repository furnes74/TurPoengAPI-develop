using Db.Models;

namespace Db.Repository
{
    public interface IPersonRepository
    {
        Person[] GetPersoner();
    }
}
