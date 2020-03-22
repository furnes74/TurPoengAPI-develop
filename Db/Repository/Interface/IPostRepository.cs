using Db.Models;
using Db.ViewModels;

namespace Db.Repository.Interface
{
    public interface IPostRepository
    {
        // Returns models for the moment
        Post[] GetAllPosts();
        Post GetPost(int id);


        // For API - returns Viewmodels
        PostVm[] GetAllPostVms();

        PostVm GetPostVm(int id);

        PostVm[] SearchPostNearBy(SearchPostVm searchVm);
    }

}
