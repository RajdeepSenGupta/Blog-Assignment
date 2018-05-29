using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Blogging.Models
{
    public class BlogRepository : IDisposable, IBlogRepository
    {
        private ApplicationDbContext context;

        public BlogRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public IEnumerable<Blog> GetBlogs()
        {
            return context.Blogs.ToList();
        }

        public Blog GetBlogByID(int id)
        {
            return context.Blogs.Find(id);
        }

        public void InsertBlog(Blog blog)
        {
            context.Blogs.Add(blog);
        }

        public void DeleteBlog(int BlogId)
        {
            Blog blog = context.Blogs.Find(BlogId);
            context.Blogs.Remove(blog);
        }

        public void UpdateBlog(Blog blog)
        {
            context.Entry(blog).State = EntityState.Modified;
        }

        public void Save()
        {
            context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}