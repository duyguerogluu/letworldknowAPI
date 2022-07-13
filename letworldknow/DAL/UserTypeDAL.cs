using letworldknow.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace letworldknow.DAL
{
    public class UserTypeDAL :BaseDAL
    {

        public IEnumerable<UserType> GetAllUserType()
        {
            return db.UserType.ToList();
        }

        public IEnumerable<UserType> GetUserTypeById(int id)
        {
            return db.UserType.Where(x => x.id == id).ToList();
        }

        public UserType CreateUserType(UserType userType)
        {
            db.UserType.Add(userType);
            db.SaveChanges();
            return userType;
        }

        public UserType UpdateUserType(UserType userType)
        {
            db.Entry(userType).State = EntityState.Modified;
            //db.SaveChanges();
            return userType;
        }

        public void DeleteUserType(int id)
        {
            db.UserType.Remove(db.UserType.Find(id));
            db.SaveChanges();
        }

        public bool IsThereAnyUserType(int id)
        {
            return db.UserType.Any(x => x.id == id);
        }

    }
}