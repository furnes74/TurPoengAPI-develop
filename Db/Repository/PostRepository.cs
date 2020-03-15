using Db.Context;
using Db.Models;
using Db.Repository.Interface;
using System;
using System.Linq;

namespace Db.Repository
{
    public class PostRepository : IPostRepository, IDisposable
    {
        private readonly TurPoengContext _context;

        public PostRepository(TurPoengContext context)
        {
            _context = context;
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public Post[] GetPost()
        {
            return _context.Post.ToArray();
        }
    }
}
