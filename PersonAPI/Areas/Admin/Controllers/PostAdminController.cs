﻿using Microsoft.AspNetCore.Mvc;
using Db.Models;
using Db.Repository.Interface;
using Microsoft.Extensions.Logging;

namespace TurPoengAPI.Admin.Controllers
{
    public class PostAdminController : AdminControllerBase
    {
        private readonly IPostRepository _postRepo;

        public PostAdminController(IPostRepository postRepo, ILogger<AdminControllerBase> logger) : base(logger)
        {
            _postRepo = postRepo;
        }

        [HttpGet("{action}")]
        public Post[] GetAllPosts() 
        {
            return  _postRepo.GetAllPosts();
        }

        [HttpGet("{action}/{id}")]
        public Post GetPost(int id)
        {
            return _postRepo.GetPost(id);
        }
    }
}