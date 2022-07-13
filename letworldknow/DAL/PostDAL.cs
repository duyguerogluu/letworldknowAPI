using letworldknow.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace letworldknow.DAL
{
    public class PostDAL : BaseDAL
    {

        public IEnumerable<Post> GetAllPosts()
        {
            return db.Post.ToList();
        }

        public IEnumerable<Post> GetPostsById(int id)
        {
            return db.Post.Where(x => x.id == id).ToList();
        }

       /* public IEnumerable<Post> GetPostsByCategoryId(int categoryId)
        {
            return db.Post.Where(x => x.category_id == categoryId).ToList();
        }*/

        public Post CreatePost(Post post)
        {
            db.Post.Add(post);
            db.SaveChanges();
            return post;
        }

        
        public Post UpdatePost(Post post)
        {
            db.Entry(post).State = EntityState.Modified;
            //db.SaveChanges();
            return post;
        }

        public void DeletePost(int id)
        {
            db.Post.Remove(db.Post.Find(id));
            db.SaveChanges();
        }

        public bool IsThereAnyPost(int id)
        {
            return db.Post.Any(x => x.id == id);
        }

    }
}