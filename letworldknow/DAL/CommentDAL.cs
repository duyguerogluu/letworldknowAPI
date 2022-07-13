using letworldknow.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace letworldknow.DAL
{
    public class CommentDAL : BaseDAL
    {

        public IEnumerable<Comment> GetAllComment()
        {
            return db.Comment.ToList();
        }

        public IEnumerable<Comment> GetCommentById(int id)
        {
            return db.Comment.Where(x => x.id == id).ToList();
        }

        public Comment CreatedComment(Comment comment)
        {
            db.Comment.Add(comment);
            db.SaveChanges();
            return comment;
        }

        public Comment UpdateComment(Comment comment)
        {
            db.Entry(comment).State = EntityState.Modified;
            //db.SaveChanges();
            return comment;
        }

        public void DeleteComment(int id)
        {
            db.Comment.Remove(db.Comment.Find(id));
            db.SaveChanges();
        }

        public bool IsThereAnyComment(int id)
        {
            return db.Comment.Any(x => x.id == id);
        }

    }
}