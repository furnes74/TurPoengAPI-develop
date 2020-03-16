using Db.Context;
using Db.ViewModels;
using Microsoft.EntityFrameworkCore;
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

        public PersonVm GetPerson(int id)
        {
            var personVm = _context.Person
                .Include(person => person.IdrettslagMember)
                .Select(person => new PersonVm
                {
                    Id = person.Id,
                    Firstname = person.Firstname,
                    Lastname = person.Lastname,
                    Picture = person.Picture
                })
                .SingleOrDefault(p => p.Id == id);

            
            personVm.Idrettslag = _context.IdrettslagMember
                .Include(im => im.Idrettslag)
                .Where(im => im.PersonId == id
                ).Select(im => new IdrettslagVm
                {
                    Id = im.Idrettslag.Id,
                    Name = im.Idrettslag.Name
                })
                .ToArray();

            return personVm;
        }
    }
}
