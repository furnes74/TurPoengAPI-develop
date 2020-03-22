using Db.Context;
using Db.Models;
using Db.Repository.Interface;
using Db.ViewModels;
using Microsoft.EntityFrameworkCore;
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
                .Include(p => p.SuggestedByPerson)
                .Select(p => CreatePostVm(p))
                .ToArray();
        }

        public PostVm GetPostVm(int id)
        {
            return CreatePostVm(_context.Post
                .Include(p => p.SuggestedByPerson)
                .SingleOrDefault(p => p.Id == id));
        }

        public PostVm[] SearchPostNearBy(SearchPostVm searchVm)
        {
            IEnumerable<Post> foundPosts = _context.Post
                .Include(p => p.SuggestedByPerson)
                .Where(p =>
                    p.Approved &&
                    p.Longitude > (searchVm.Longitude - searchVm.Distance) &&
                    p.Longitude < (searchVm.Longitude + searchVm.Distance) &&
                    p.Latitude > (searchVm.Latitude - searchVm.Distance) &&
                    p.Latitude < (searchVm.Latitude + searchVm.Distance)
                );

            return foundPosts.Select(p => CreatePostVm(p))
                .ToArray();
        }


        // oppretter og endrer kun poster som ikke er approved
        public bool AddOrUpdatePost(PostVm postVm)
        {
            // bruke samme for ny og i en eventuell update??

            Post efPost = null;
            if (postVm.Id == 0)
            {
                // new
                efPost = new Post
                {
                    Id = 0,
                    Approved = false
                };
                _context.Post.Add(efPost);
            }
            else
            {
                // update exsisting ? må sikre at denne ikke er approved og at person som forelår er samme som har foreslått
                efPost = _context.Post.SingleOrDefault(p => p.Id == postVm.Id && !p.Approved);
            }

            if (efPost != null)
            {
                UpdatePost(efPost, postVm);
                _context.SaveChanges();
                return true;
            }

            return false;
        }

        public Post[] GetSuggestedPosts()
        {
            return _context.Post
                .Include(p => p.SuggestedByPerson)
                .Where(p => !p.Approved)
                .ToArray();
        }

        public bool ApprovePost(int id)
        {
            var efPost = _context.Post.SingleOrDefault(p => p.Id == id && !p.Approved);

            if (efPost != null)
            {
                efPost.Approved = true;
                _context.SaveChanges();
                return true;
            }

            return false;
        }


        #endregion

        #region Private methods

        private static PostVm CreatePostVm(Post post)
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
                DefaultPoints = post.DefaultPoints,
                SuggestedByPersonId = post.SuggestedByPersonId,
                SuggestedByPersonName = $"{post.SuggestedByPerson.Lastname}, {post.SuggestedByPerson.Firstname}"
            };
        }

        private static void UpdatePost(Post efPost, PostVm postVm)
        {
            efPost.Name = postVm.Name;
            efPost.CallingName = postVm.CallingName;
            efPost.Latitude = postVm.Latitude;
            efPost.Longitude = postVm.Longitude;
            efPost.PostHeight = postVm.PostHeight;
            efPost.PostStartHeight = postVm.PostStartHeight;
            efPost.PostWalkDistance = postVm.PostWalkDistance;
            efPost.DefaultPoints = postVm.DefaultPoints;
            efPost.SuggestedByPersonId = postVm.SuggestedByPersonId;
        }

        #endregion
    }
}
