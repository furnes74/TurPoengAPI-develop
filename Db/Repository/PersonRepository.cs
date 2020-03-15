using Db.Context;
using Db.Models;
using System;
using System.Linq;

namespace Db.Repository
{
    public class PersonRepository : IPersonRepository, IDisposable
    {
        private readonly TurPoengContext _context;

        public PersonRepository(TurPoengContext context)
        {
            _context = context;
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public Person[] GetPersoner()
        {
            return _context.Person.ToArray();
        }
    }
}
