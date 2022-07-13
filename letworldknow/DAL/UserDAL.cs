using letworldknow.Models;  
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace letworldknow.DAL
{
    public class UserDAL : BaseDAL
    {
        public User GetBusinessByApiKey(string apiKey)
        {
            return db.User.FirstOrDefault(x => x.user_key.ToString() == apiKey);
        }
    }
}