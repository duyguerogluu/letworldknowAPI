using letworldknow.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace letworldknow.DAL
{
    public class FollowDAL : BaseDAL
    {
        public IEnumerable<Follow> GetAllLike()
        {
            return db.Follow.ToList();
        }

        public IEnumerable<Follow> GetFollowById(int id)
        {
            return db.Follow.Where(x => x.id == id).ToList();
        }

        public Follow CreatedFollow(Follow follow)
        {
            db.Follow.Add(follow);
            db.SaveChanges();
            return follow;
        }

        public Follow UpdateFollow(Follow follow)
        {
            db.Entry(follow).State = EntityState.Modified;
            //db.SaveChanges();
            return follow;
        }

        public void DeleteFollow(int id)
        {
            db.Like.Remove(db.Like.Find(id));
            db.SaveChanges();
        }

        public bool IsThereAnyFollow(int id)
        {
            return db.Like.Any(x => x.id == id);
        }

    }
}