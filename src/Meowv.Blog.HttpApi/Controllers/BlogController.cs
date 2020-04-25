using Meowv.Blog.Application.Blog;
using Meowv.Blog.Application.Contracts;
using Meowv.Blog.Application.Contracts.Blog;
using Meowv.Blog.ToolKits.Base;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.AspNetCore.Mvc;
using static Meowv.Blog.Domain.Shared.MeowvBlogConsts;

namespace Meowv.Blog.HttpApi.Controllers
{
    [ApiController]
    [AllowAnonymous]
    [Route("[controller]")]
    [ApiExplorerSettings(GroupName = Grouping.GroupName_v1)]
    public class BlogController : AbpController
    {
        private readonly IBlogService _blogService;

        public BlogController(IBlogService blogService)
        {
            _blogService = blogService;
        }

        /// <summary>
        /// ����URL��ȡ��������
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("post")]
        public async Task<ServiceResult<PostDetailDto>> GetPostDetailAsync(string url)
        {
            return await _blogService.GetPostDetailAsync(url);
        }

        /// <summary>
        /// ��ҳ��ѯ�����б�
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("posts")]
        public async Task<ServiceResult<PagedList<QueryPostDto>>> QueryPostsAsync([FromQuery] PagingInput input)
        {
            return await _blogService.QueryPostsAsync(input);
        }

        /// <summary>
        /// ͨ����ǩ���Ʋ�ѯ�����б�
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("posts/tag")]
        public async Task<ServiceResult<IEnumerable<QueryPostDto>>> QueryPostsByTagAsync(string name)
        {
            return await _blogService.QueryPostsByTagAsync(name);
        }

        /// <summary>
        /// ͨ���������Ʋ�ѯ�����б�
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("posts/category")]
        public async Task<ServiceResult<IEnumerable<QueryPostDto>>> QueryPostsByCategoryAsync(string name)
        {
            return await _blogService.QueryPostsByCategoryAsync(name);
        }

        /// <summary>
        /// ��ȡ��ǩ����
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("tag")]
        public async Task<ServiceResult<string>> GetTagAsync(string name)
        {
            return await _blogService.GetTagAsync(name);
        }

        /// <summary>
        /// ��ѯ��ǩ�б�
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("tags")]
        public async Task<ServiceResult<IEnumerable<QueryTagDto>>> QueryTagsAsync()
        {
            return await _blogService.QueryTagsAsync();
        }

        /// <summary>
        /// ��ȡ��������
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("category")]
        public async Task<ServiceResult<string>> GetCategoryAsync(string name)
        {
            return await _blogService.GetCategoryAsync(name);
        }

        /// <summary>
        /// ��ѯ�����б�
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("categories")]
        public async Task<ServiceResult<IEnumerable<QueryCategoryDto>>> QueryCategoriesAsync()
        {
            return await _blogService.QueryCategoriesAsync();
        }
    }
}