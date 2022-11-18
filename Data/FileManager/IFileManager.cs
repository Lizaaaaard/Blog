using Microsoft.AspNetCore.Http;
using System.IO;
using System.Threading.Tasks;

namespace Blog.Data.FileManager
{
    public interface IFileManager
    {
        FileStream ImageStream(string image);
        Task<string> SaveImage(IFormFile image);
    }
}
