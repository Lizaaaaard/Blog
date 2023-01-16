using Blog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
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

        Task<bool> SaveChangesAsync();
    }
}
