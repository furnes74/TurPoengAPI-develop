using Db.Context;
using Db.Models;
using System;
using System.Linq;

namespace Db.Repository
{
    public class IdrettslagRepository : IIdrettslagRepository, IDisposable
    {
        private readonly TurPoengContext _context;

        public IdrettslagRepository(TurPoengContext context)
        {
            _context = context;
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public Idrettslag[] GetIdrettslag()
        {
            return _context.Idrettslag.ToArray();
        }
    }
}
