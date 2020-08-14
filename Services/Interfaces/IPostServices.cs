using huyblog.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace huyblog.Services.Interfaces
{
    public interface IPostServices
    {
        Task<bool> AddPost(Post posts);
        Task<Post> GetPostById(int id);
        Task<bool> UpdatePost(Post posts);
        Task<bool> DeletePostById(int id);
    }
}
