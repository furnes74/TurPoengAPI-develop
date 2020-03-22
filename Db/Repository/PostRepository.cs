using Db.Context;
using Db.Models;
using Db.Repository.Interface;
using Db.ViewModels;
using System;
using System.Collections.Generic;
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

        #region Admin - returns models for the moment
        public Post[] GetAllPosts()
        {
            return _context.Post.ToArray();
        }

        public Post GetPost(int id)
        {
            return _context.Post.SingleOrDefault();
        }

        #endregion


        #region API - returns viewmodels for the moment

        public PostVm[] GetAllPostVms()
        {
            return _context.Post
                .Select(p => CreatePostVm(p))
                .ToArray();
        }

        public PostVm GetPostVm(int id)
        {
            return CreatePostVm(_context.Post.SingleOrDefault(p => p.Id == id));
        }

        public PostVm[] SearchPostNearBy(SearchPostVm searchVm)
        {
            IEnumerable<Post> foundPosts = _context.Post.Where(p =>
                p.Longitude > (searchVm.Longitude - searchVm.Distance) &&
                p.Longitude < (searchVm.Longitude + searchVm.Distance) &&
                p.Latitude > (searchVm.Latitude - searchVm.Distance) &&
                p.Latitude < (searchVm.Latitude + searchVm.Distance)
                );

            return foundPosts.Select(p => CreatePostVm(p))
                .ToArray();
        }

        private PostVm CreatePostVm(Post post)
        {
            if (post == null)
            {
                return new PostVm();
            }

            return new PostVm
            {
                Id = post.Id,
                Name = post.Name,
                CallingName = post.CallingName,
                PostHeight = post.PostHeight,
                PostStartHeight = post.PostStartHeight,
                PostWalkDistance = post.PostWalkDistance,
                Latitude = post.Latitude,
                Longitude = post.Longitude,
                DefaultPoints = post.DefaultPoints
            };
        }
        #endregion
    }
}
