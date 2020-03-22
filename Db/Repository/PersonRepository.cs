using Db.Context;
using Db.Models;
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
            return _context.Person
                .Include(person => person.IdrettslagMember)
                .Include(person => person.MyFriends)
                .ThenInclude(f => f.Friend)
                .Include(person => person.IdrettslagMember)
                .ThenInclude(im => im.Idrettslag)
                .Select(person => new PersonVm
                {
                    Id = person.Id,
                    Firstname = person.Firstname,
                    Lastname = person.Lastname,
                    Picture = person.Picture,
                    Idrettslag = person.IdrettslagMember
                    .Select(im => new IdrettslagVm
                    {
                        Id = im.Idrettslag.Id,
                        Name = im.Idrettslag.Name
                    }).ToArray(),
                    Friends = person.MyFriends.Select(mf => new FriendVm
                    {
                        Firstname = mf.Friend.Firstname,
                        Lastname = mf.Friend.Lastname,
                        FriendId = mf.FriendId,
                        Picture = mf.Friend.Picture,
                        Idrettslag = mf.Friend.IdrettslagMember
                        .Select(im => new IdrettslagVm
                        {
                            Id = im.Idrettslag.Id,
                            Name = im.Idrettslag.Name
                        }).ToArray()
                    })
                    .ToArray()
                })
                .SingleOrDefault(p => p.Id == id);
        }


        public Person GetPersonForAdmin(int id)
        {
            return _context.Person
                .SingleOrDefault(p => p.Id == id);
        }
    }
}
