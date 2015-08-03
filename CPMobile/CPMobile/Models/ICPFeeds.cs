using System.Collections.Generic;
using System.Threading.Tasks;

namespace CPMobile.Models
{
    public interface ICPFeeds
    {
        Task Init();

        Task<CPFeed> GetArticleAsync(int page);

        Task<CPFeed> GetForumAsync();

        Task<bool> GetAccessToken(string username, string password);

        Task<MyProfile> GetMyProfile();

        Task<CPFeed> MyArticles(int page);

        Task<CPFeed> GetForumAsync(int tag);
        Task<CPFeed> MyMessage(int page);
        Task<CPFeed> MyTips(int page);
        Task<CPFeed> MyBlogs(int page);
        Task<CPFeed> MyComments(int page);
    }

}
