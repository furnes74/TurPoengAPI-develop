using Db.Models;

namespace Db.Repository
{
    public interface IIdrettslagRepository
    {
        Idrettslag[] GetIdrettslag();
    }
}
