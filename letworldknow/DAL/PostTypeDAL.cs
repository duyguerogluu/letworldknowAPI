using letworldknow.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace letworldknow.DAL
{
    public class PostTypeDAL : BaseDAL
    {

        public IEnumerable<PostType> GetAllPostType()
        {
            return db.PostType.ToList();
        }

        public IEnumerable<PostType> GetPostTypeById(int id)
        {
            return db.PostType.Where(x => x.id == id).ToList();
        }

        public PostType CreatedPostType(PostType posttype)
        {
            db.PostType.Add(posttype);
            db.SaveChanges();
            return posttype;
        }

        public PostType UpdatePostType(PostType postType)
        {
            db.Entry(postType).State = EntityState.Modified;
            //db.SaveChanges();
            return postType;
        }

        public void DeletePostType(int id)
        {
            db.PostType.Remove(db.PostType.Find(id));
            db.SaveChanges();
        }

        public bool IsThereAnyPostType(int id)
        {
            return db.PostType.Any(x => x.id == id);
        }

    }
}