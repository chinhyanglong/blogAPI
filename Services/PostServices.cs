using huyblog.Data;
using huyblog.Models.Dtos;
using huyblog.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace huyblog.Services
{
    public class PostServices : IPostServices
    {
        private readonly ApplicationDbContext _dbContext;
        public PostServices(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<bool> AddPost(Post posts)
        {
            posts.Id = (posts.Id != 0) ? posts.Id : 0;
            await _dbContext.Posts.AddAsync(posts);
            bool isError = await _dbContext.SaveChangesAsync() <= 0;
            return isError;
        }

        public async Task<bool> DeletePostById(int id)
        {
            bool isError = true;
            Post post = _dbContext.Posts.FirstOrDefault(m => m.Id == id);

            if (post != null)
            {
                _dbContext.Posts.Remove(post);
                isError = await _dbContext.SaveChangesAsync() <= 0;
            }
            return isError;
        }

        public async Task<Post> GetPostById(int id)
        {
            Post post = await _dbContext.Posts
                                .Where(s => s.Id == id)
                                .AsNoTracking()
                                .FirstOrDefaultAsync();
            return post;
        }

        public async Task<bool> UpdatePost(Post posts)
        {
            _dbContext.Posts.Update(posts);
            bool isError = await _dbContext.SaveChangesAsync() <= 0;

            return isError;
        }
    }
}
