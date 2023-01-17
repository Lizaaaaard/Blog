using Blog.Models;
using Blog.Models.Comments;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Blog.Data.Repository
{
    public interface IRepository
    {
        Post GetPost(int id);
        List<Post> GetAllPosts();
        List<Post> GetAllPosts(string Category);
        void RemovePost(int id);
        void UpdatePost(Post post);
        void AddPost(Post post);
        void AddSubComment(SubComment comment);
        Task<bool> SaveChangesAsync();
    }
}
