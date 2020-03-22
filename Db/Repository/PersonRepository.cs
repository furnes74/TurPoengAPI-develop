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
                    .Select(im => CreateIdrettslagVm(im)).ToArray(),
                    Friends = person.MyFriends.Select(mf => CreateFriendVm(mf)).ToArray()
                })
                .SingleOrDefault(p => p.Id == id);
        }

        public FriendVm[] GetFriends(int id)
        {
            return _context.MyFriend
                .Include(mf => mf.Friend)
                .ThenInclude(person => person.IdrettslagMember)
                .ThenInclude(im => im.Idrettslag)
                .Where(mf => mf.PersonId == id)
                .Select(mf => CreateFriendVm(mf))
                .ToArray();
        }

        public Person GetPersonForAdmin(int id)
        {
            return _context.Person
                .SingleOrDefault(p => p.Id == id);
        }


        private static FriendVm CreateFriendVm(MyFriend friend)
        {
            return new FriendVm
            {
                Firstname = friend.Friend.Firstname,
                Lastname = friend.Friend.Lastname,
                FriendId = friend.FriendId,
                Picture = friend.Friend.Picture,
                Idrettslag = friend.Friend.IdrettslagMember
                .Select(im => CreateIdrettslagVm(im))
                .ToArray()
            };
        }

        private static IdrettslagVm CreateIdrettslagVm(IdrettslagMember im)
        {
            return new IdrettslagVm
            {
                Id = im.Idrettslag.Id,
                Name = im.Idrettslag.Name
            };
        }

    }
}
