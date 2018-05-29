

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Blogging.Models;

using Microsoft.AspNet.Identity;

namespace Blogging.Controllers
{
    [Authorize]
    public class BlogsController : Controller
    {
    //normal Implement
        //private ApplicationDbContext db = new ApplicationDbContext();


    //Using Blog repository
        //private IBlogRepository blogRepository;
        //public BlogsController()
        //{
        //    this.blogRepository = new BlogRepository(new ApplicationDbContext());
        //}


    //Using Generic Repository
        private IRepository<Blog> repository;
        public BlogsController(IRepository<Blog> repository)
        {
            this.repository = repository;
        }
        



        // GET: Blogs
        public ActionResult Index(string searchString, string searchUser)
        {
            var userList = new List<string>();

         //Normal Implement
            //var userQuery = db.Blogs.OrderBy(b => b.User.UserName).Select(b => b.User.UserName);    
           
         //Using Blog Repository
            //var userQuery = blogRepository.GetBlogs().OrderBy(b => b.User.UserName).Select(b => b.User.UserName);

         //Generic Repository
            //var userQuery = from m in repository.List()
            //                orderby m.User.UserName
            //                select m.User.UserName;
            var userQuery = repository.List().OrderBy(b => b.User.UserName).Select(b => b.User.UserName);

            userList.AddRange(userQuery.Distinct());
            ViewBag.searchUser = new SelectList(userList);

         //Normal Implement
            //var blogs = db.Blogs.Select(b => b);

         //using Blog repository
            //var blogs = blogRepository.GetBlogs();

         //Generic Repository
            var blogs = repository.List();


            if (!string.IsNullOrEmpty(searchString))
            {
                blogs = blogs.Where(b => b.BlogTitle.StartsWith(searchString));
            }
            if (!string.IsNullOrEmpty(searchUser))
            {
                blogs = blogs.Where(b => b.User.UserName == searchUser);
            }

            return View(blogs);
        }

        // Get: Login Index Page
        public ActionResult MyBlogs()                                                           //New for My Blogs only
        {
         //Normal Implement
            //return View(db.Blogs.ToList());

         //using Blog repository
            //return View(blogRepository.GetBlogs());

         //Using Generic Repository
            return View(repository.List());
        }

        // GET: Blogs/Details/5
        public ActionResult Details(int id)
        {
         //Normal Implement
            //Blog blog = db.Blogs.Find(id);

         //Using Blog Repository
            //Blog blog = blogRepository.GetBlogByID(id);

         //Generic Repository
            Blog blog = repository.GetById(id);

            if (blog == null)
            {
                return HttpNotFound();
            }
            return View(blog);
        }

        // GET: Blogs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Blogs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BlogId,BlogTitle,BlogContent")] Blog blog)
        {
            if (ModelState.IsValid)
            {
            //Normal implement
                //db.Blogs.Add(blog);
                //blog.OnCreated = DateTime.Now.Date;
                //blog.UserId = User.Identity.GetUserId();
                //db.SaveChanges();

            //Using Blog Repository
                //blogRepository.InsertBlog(blog);
                //blog.OnCreated = DateTime.Now.Date;
                //blog.UserId = User.Identity.GetUserId();
                //blogRepository.Save();

             //Generic Repository
                //repository.Add(blog);
                blog.OnCreated = DateTime.Now.Date;
                repository.Add(blog);
                blog.UserId = User.Identity.GetUserId();
                repository.Save();

                return RedirectToAction("Index");
            }

            return View(blog);
        }

        // GET: Blogs/Edit/5
        public ActionResult Edit(int? id)
        {
        //Normal Implement
            //Blog blog = db.Blogs.Find(id);

        //using Blog Repository
            //Blog blog = blogRepository.GetBlogByID(id);

        //Generic Repository
            Blog blog = repository.GetById(id);

            if (blog == null)
            {
                return HttpNotFound();
            }
            return View(blog);
        }

        // POST: Blogs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BlogId,BlogTitle,BlogContent")] Blog blog)
        {
            if (ModelState.IsValid)
            {
             //Normal implement
                //db.Entry(blog).State = EntityState.Modified;
                //db.SaveChanges();

            //Using Blog Repository
                //blogRepository.UpdateBlog(blog);
                //blogRepository.Save();

            //Generic Repository
                blog.UserId = User.Identity.GetUserId();
                blog.OnCreated = DateTime.Now.Date;
                repository.Edit(blog);
                repository.Save();

                return RedirectToAction("Index");
            }
            return View(blog);
        }

        // GET: Blogs/Delete/5
        public ActionResult Delete(int? id)
        {
        //Normal Implement
            //Blog blog = db.Blogs.Find(id);

        //Using Blog repository
            //Blog blog = blogRepository.GetBlogByID(id);

        //Generic Repository
            Blog blog = repository.GetById(id);

            if (blog == null)
            {
                return HttpNotFound();
            }
            return View(blog);
        }

        // POST: Blogs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
        //Normal Implemnt
            //Blog blog = db.Blogs.Find(id);
            //db.Blogs.Remove(blog);
            //db.SaveChanges();

        //Using Blog Repository
            //blogRepository.DeleteBlog(id);
            //blogRepository.Save();

        //Generic Repository
            repository.Delete(id);
            repository.Save();

            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
            //Normal Implement
                //db.Dispose();

            //Using Blog Repository
                //blogRepository.Dispose();

            //Generic Repository
                repository.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
