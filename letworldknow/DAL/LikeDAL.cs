using letworldknow.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace letworldknow.DAL
{
    public class LikeDAL : BaseDAL
    {

        public IEnumerable<Like> GetAllLike()
        {
            return db.Like.ToList();
        }

        public IEnumerable<Like> GetLikeById(int id)
        {
            return db.Like.Where(x => x.id == id).ToList();
        }

        public Like CreatedLike(Like like)
        {
            db.Like.Add(like);
            db.SaveChanges();
            return like;
        }

        public Like UpdateLike(Like like)
        {
            db.Entry(like).State = EntityState.Modified;
            //db.SaveChanges();
            return like;
        }

        public void DeleteLike(int id)
        {
            db.Like.Remove(db.Like.Find(id));
            db.SaveChanges();
        }

        public bool IsThereAnyLike(int id)
        {
            return db.Like.Any(x => x.id == id);
        }

    }
}