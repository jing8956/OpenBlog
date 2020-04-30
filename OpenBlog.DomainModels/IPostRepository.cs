﻿using Niusys.Extensions.ComponentModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OpenBlog.DomainModels
{
    public interface IPostRepository
    {
        Task<string> CreatePostAsync(Post post);
        Task<Page<Post>> SearchPost(int pageIndex, int pageSize);
        Task<Post> GetPost(string postId);
        Task<Post> GetPostBySlug(string slug);
    }
}
