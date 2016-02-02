﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Blogging.Models
{
    public interface IBlogRepository : IDisposable
    {
        IEnumerable<Blog> GetBlogs();
        Blog GetBlogByID(int BlogId);
        void InsertBlog(Blog blog);
        void DeleteBlog(int BlogId);
        void UpdateBlog(Blog blog);
        void Save();
    }
}