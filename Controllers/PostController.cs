using huyblog.Common.Utils;
using huyblog.Const;
using huyblog.Models.Dtos;
using huyblog.Models.ResponseModel;
using huyblog.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace huyblog.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class PostController : ControllerBase
    {
        private readonly IPostServices _postServices;
        public PostController(IPostServices postServices)
        {
            _postServices = postServices;
        }


        [Route("[action]")]
        [HttpPost]
        public async Task<string> AddPosts([FromBody] Post PostModels)
        {
            ResponseModel<string> rm = new ResponseModel<string> { Status = Status.FAILED, Message = "Posts not successfully created" };
            try
            {
                bool isError = false;

                if (PostModels != null && !isError)
                    isError = await _postServices.AddPost(PostModels);

                if (!isError)
                {
                    rm.Status = Status.SUCCESS;
                    rm.Message = "Posts successfully created";
                }
                return JsonUtils.FormatJson(rm);
            }
            catch (Exception e)
            {
                return JsonUtils.FormatJson(rm);
            }
        }
        [Route("[action]/{id}")]
        [HttpGet]
        public async Task<string> GetPost(int id)
        {
           
            ResponseModel<Post> rm = new ResponseModel<Post> { Status = Status.FAILED, Message = "Failed to get Post details" };
            try
            {
                Post PostModel = await _postServices.GetPostById(id);
                if (PostModel != null)
                {
                    rm.Status = Status.SUCCESS;
                    rm.Data = PostModel;
                    rm.Message = null;
                }
                return JsonUtils.FormatJson(rm);
            }
            catch (Exception e)
            {
                return JsonUtils.FormatJson(rm);
            }
        }

        [Route("[action]")]
        [HttpPost]
        public async Task<string> UpdatePost([FromBody] Post PostModel)
        {
            ResponseModel<string> rm = new ResponseModel<string> { Status = Status.FAILED, Message = "Post not successfully updated" };
            try
            {
                bool isError = false;

                if (PostModel != null && !isError)
                    isError = await _postServices.UpdatePost(PostModel);

                if (!isError)
                {
                    rm.Status = Status.SUCCESS;
                    rm.Message = "Post successfully updated";
                }
                return JsonUtils.FormatJson(rm);
            }
            catch (Exception e)
            {
                return JsonUtils.FormatJson(rm);
            }
        }

        [Route("[action]/{id}")]
        [HttpGet]
        public async Task<string> DeletePost(int id)
        {
            ResponseModel<string> rm = new ResponseModel<string> { Status = Status.FAILED, Message = "Failed to delete the Post" };
            try
            {
                bool isError = await _postServices.DeletePostById(id);
                if (!isError)
                {
                    rm.Status = Status.SUCCESS;
                    rm.Message = "Successfully Delete Post";
                }
                return JsonUtils.FormatJson(rm);
            }
            catch (Exception e)
            {
                return JsonUtils.FormatJson(rm);
            }
        }
    }
}